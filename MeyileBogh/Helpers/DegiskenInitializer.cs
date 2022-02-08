using MeyileBogh.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutlookApp = Microsoft.Office.Interop.Outlook.Application;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using Exception = System.Exception;
using MeyileBogh.Helpers.Abstract;
using System.CodeDom;
using MeyileBogh.Models.Results;

namespace MeyileBogh.Helpers
{
    public static class DegiskenInitializer
    {
        public static IDataResult<List<DegiskenBase>> Initialize(string excelPath, string oftPath, DegiskenBaseOptions degiskenBaseOptions)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();            
            
            Worksheet excelSheet;

            int subjectSutunNo = 0;
            int subjectSutunSayisi = 0;
            int mailSutunNo = 0;
            int mailSutunSayisi = 0;
            List<int> ccSutunNolari = new List<int>();

            List<DegiskenBase> degiskencikler = new List<DegiskenBase>();

            Workbook wb = excel.Workbooks.Open(excelPath);
            excelSheet = wb.ActiveSheet;

            try
            {                
                //excelden basliklari al.
                List<string> basliklar = GetHeadings(excelSheet);

                var loopNo = 1;
                //değişken adı kontrollerini yap 
                foreach (var baslik in basliklar)
                {
                    loopNo++;

                    //subject/konu var mı?
                    //oto subject açıksa --> içerisinde subject veya konu yazan başlığı bul:
                    if (degiskenBaseOptions.AutoSubjectOn)
                    {                        
                        if (baslik.ToLower().Equals("subject") || baslik.ToLower().Equals("konu"))
                        {
                            subjectSutunNo = loopNo -1;
                            subjectSutunSayisi++;                            
                            continue;
                        }
                    }

                    //eğer CC'ye eklenecek mailler excelden gelecekse, CC sütununu bul :
                    if (degiskenBaseOptions.AutoCCOn && baslik.ToLower().Equals("cc"))
                    {
                        ccSutunNolari.Add(loopNo - 1);
                        continue;
                    }

                    //Mail sütununu bul.
                    if (baslik.ToLower().Equals("mail") || baslik.ToLower().Equals("email") || baslik.ToLower().Equals("e-mail"))
                    {
                        mailSutunNo = loopNo - 1;
                        mailSutunSayisi++;
                        continue;
                    }
                }
                
                //Başlıklar şartları sağlıyor mu kontrolleri
                if (degiskenBaseOptions.AutoSubjectOn)
                {
                    if (subjectSutunSayisi > 1 )
                    {
                        throw new Exception("Excelde birden fazla başlık bulundu. Lütfen sadece bir başlık ekleyeniz");
                    }

                    if (subjectSutunSayisi == 0)
                    {
                        throw new Exception("Excelde konu sütunu bulunamadı. Lütfen konu sütununuzu 'konu' veya 'subject' şeklinde isimlendiriniz.");
                    }
                }

                if (mailSutunSayisi > 1)
                {
                    throw new Exception(Messages.MoreThan1Mail);
                }

                if (mailSutunSayisi == 0)
                {
                    throw new Exception("Excelde mail sütunu bulunmadı. Lütfen mail sütununu 'mail' veya 'email' veya 'e-mail' şeklinde isimlendiriniz.");
                }

                if (degiskenBaseOptions.AutoCCOn && ccSutunNolari.Count == 0)
                {
                    throw new Exception("Excelde CC sütunu bulunmadı. Lütfen CC sütunlarınızı 'cc' veya 'Cc' veya 'CC' şeklinde isimlendiriniz.");
                }


                //Değişkenleri atamak için kullanacağımız sütun numaralarını 1den sutun sayısına kadar yazıyoruz.
                List<int> sayilarBase = new List<int>();
                for (int i = 1; i <= basliklar.Count; i++)
                {
                    sayilarBase.Add(i);
                }
                List<int> sayilarTmp;

                int sonSatir = excelSheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing).Row;

                //Dosyadan her satırı oku ve bir değişkene ata:
                for (int i = 2; i <= sonSatir; i++)
                {
                    sayilarTmp = new List<int>(sayilarBase);
                    var tmpDegiskenBase = new DegiskenBase();

                    //excelden gelecekse subject atanır
                    if (degiskenBaseOptions.AutoSubjectOn)
                    {
                        if (string.IsNullOrWhiteSpace(excelSheet.Cells[i, subjectSutunNo].Value))
                        {
                            throw new Exception("Konu/Subject sütununda " + ExcelHelper.ToExcelCoordinates(i, subjectSutunNo) + " hücresi boş kalmış. Lütfen mail için konu yazınız.");
                        }
                        tmpDegiskenBase.Subject = excelSheet.Cells[i, subjectSutunNo].Value.ToString().Trim();
                        sayilarTmp.Remove(subjectSutunNo);
                    }

                    //mail atanır
                    if (string.IsNullOrWhiteSpace(excelSheet.Cells[i, mailSutunNo].Value))
                    {
                        throw new Exception("Mail sütununda " + ExcelHelper.ToExcelCoordinates(i, mailSutunNo) + " hücresi boş kalmış. Lütfen excelde boş mail hücresi bırakmayanız");
                    }

                    if (!ValidationHelper.EmailIsValid(excelSheet.Cells[i, mailSutunNo].Value.ToString().Trim()))
                    {
                        throw new Exception("Mail sütununda " + ExcelHelper.ToExcelCoordinates(i, mailSutunNo) + " hücresi geçerli bir mail adresi değildir.");
                    }
                    tmpDegiskenBase.MailAddress = excelSheet.Cells[i, mailSutunNo].Value.ToString().Trim();
                    sayilarTmp.Remove(mailSutunNo);

                    //varsa CCler atanır
                    if (degiskenBaseOptions.AutoCCOn)
                    {                        
                        var tmpCCs = "";
                        foreach (var ccSutunNo in ccSutunNolari)
                        {
                            if (!string.IsNullOrWhiteSpace(excelSheet.Cells[i, ccSutunNo].Value))
                            {
                                tmpCCs = tmpCCs + excelSheet.Cells[i, ccSutunNo].Value.ToString().Trim() + "; ";
                            }
                            sayilarTmp.Remove(ccSutunNo);
                        }
                        tmpDegiskenBase.CCs = tmpCCs;
                        
                    }

                    //kalan sutun noları değişken olmalı, değişkenler atanır
                    foreach (var degiskenSutunNo in sayilarTmp)
                    {
                        var tmpDegisken = new Degisken();
                        tmpDegisken.degiskenAdi = excelSheet.Cells[1, degiskenSutunNo].Value.ToString().Trim();
                        if (string.IsNullOrWhiteSpace(excelSheet.Cells[i, degiskenSutunNo].Value) )
                        {
                            tmpDegisken.degiskenText = "";
                        }
                        else
                        {
                            tmpDegisken.degiskenText = excelSheet.Cells[i, degiskenSutunNo].Value.ToString().Trim();
                        }
                        
                        tmpDegiskenBase.Degiskenler.Add(tmpDegisken);
                    }

                    degiskencikler.Add(tmpDegiskenBase);
                }

                //Değişkenlerden OFT dosyası içerisinde olmayan var mı?
                var oftDegiskenResult = OftContainsAllDegiskens(oftPath, degiskencikler[0].Degiskenler);
                if(oftDegiskenResult != null)
                {
                    throw new Exception("Oft dosyanızda " + oftDegiskenResult + " isimli değişken bulunamadı. Lütfen kontrol ediniz.");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return new ErrorDataResult<List<DegiskenBase>>(e.Message);
            }
            finally
            {
                //excel dosyası kaydedilir ve kapatılır
                wb.Save();
                wb.Close();
            }

            return new SuccessDataResult<List<DegiskenBase>>(degiskencikler);
                 
        }
        
        public static IDataResult<DegiskenBase> Test(string excelPath, string oftPath, DegiskenBaseOptions degiskenBaseOptions)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            Worksheet excelSheet;

            int subjectSutunNo = 0;
            int subjectSutunSayisi = 0;
            int mailSutunNo = 0;
            int mailSutunSayisi = 0;
            List<int> ccSutunNolari = new List<int>();

            DegiskenBase degiskencik = new DegiskenBase();

            Workbook wb = excel.Workbooks.Open(excelPath);
            excelSheet = wb.ActiveSheet;

            try
            {
                //excelden basliklari al.
                List<string> basliklar = GetHeadings(excelSheet);

                var loopNo = 1;
                //değişken adı kontrollerini yap 
                foreach (var baslik in basliklar)
                {
                    loopNo++;
                    //subject/konu var mı?
                    //oto subject açıksa --> içerisinde subject veya konu yazan başlığı bul:
                    if (degiskenBaseOptions.AutoSubjectOn)
                    {                        
                        if (baslik.ToLower().Equals("subject") || baslik.ToLower().Equals("konu"))
                        {
                            subjectSutunNo = loopNo - 1;
                            subjectSutunSayisi++;
                            continue;
                        }
                    }

                    //eğer CC'ye eklenecek mailler excelden gelecekse, CC sütununu bul :
                    if (degiskenBaseOptions.AutoCCOn && baslik.ToLower().Equals("cc"))
                    {
                        ccSutunNolari.Add(loopNo - 1);
                        continue;
                    }

                    //Mail sütununu bul.
                    if (baslik.ToLower().Equals("mail") || baslik.ToLower().Equals("email") || baslik.ToLower().Equals("e-mail"))
                    {
                        mailSutunNo = loopNo - 1;
                        mailSutunSayisi++;
                        continue;
                    }
                }

                //Başlıklar şartları sağlıyor mu kontrolleri
                if (degiskenBaseOptions.AutoSubjectOn)
                {
                    if (subjectSutunSayisi > 1)
                    {
                        throw new Exception("Excelde birden fazla başlık bulundu. Lütfen sadece bir başlık ekleyeniz");
                    }

                    if (subjectSutunSayisi == 0)
                    {
                        throw new Exception("Excelde konu sütunu bulunamadı. Lütfen konu sütununuzu 'konu' veya 'subject' şeklinde isimlendiriniz.");
                    }
                }

                if (mailSutunSayisi > 1)
                {
                    throw new Exception(Messages.MoreThan1Mail);
                }

                if (mailSutunSayisi == 0)
                {
                    throw new Exception("Excelde mail sütunu bulunamadı. Lütfen mail sütununu 'mail' veya 'email' veya 'e-mail' şeklinde isimlendiriniz.");
                }

                if (degiskenBaseOptions.AutoCCOn && ccSutunNolari.Count == 0)
                {
                    throw new Exception("Excelde CC sütunu bulunamadı. Lütfen CC sütunlarınızı 'cc' veya 'Cc' veya 'CC' şeklinde isimlendiriniz.");
                }

                //Değişkenleri atamak için kullanacağımız sütun numaralarını 1den sutun sayısına kadar yazıyoruz.
                List<int> sayilarBase = new List<int>();
                for (int i = 1; i <= basliklar.Count; i++)
                {
                    sayilarBase.Add(i);
                }
                List<int> sayilarTmp;

                //Dosyadan ikinci satırı oku ve bir değişkene ata:
                sayilarTmp = new List<int>(sayilarBase);

                //varsa subject atanır
                if (degiskenBaseOptions.AutoSubjectOn)
                {
                    if (string.IsNullOrWhiteSpace(excelSheet.Cells[2, subjectSutunNo].Value))
                    {
                        throw new Exception("Konu/Subject sütununda " + ExcelHelper.ToExcelCoordinates(2, subjectSutunNo) + " hücresi boş kalmış. Lütfen mail için konu yazınız.");
                    }
                    degiskencik.Subject = excelSheet.Cells[2, subjectSutunNo].Value.ToString().Trim();
                    sayilarTmp.Remove(subjectSutunNo);
                }

                //mail atanır
                if (string.IsNullOrWhiteSpace(excelSheet.Cells[2, mailSutunNo].Value))
                {
                    throw new Exception("Mail sütununda " + ExcelHelper.ToExcelCoordinates(2, mailSutunNo) + " hücresi boş kalmış. Lütfen excelde boş mail hücresi bırakmayanız");
                }

                if (!ValidationHelper.EmailIsValid(excelSheet.Cells[2, mailSutunNo].Value.ToString()))
                {
                    throw new Exception("Mail sütununda " + ExcelHelper.ToExcelCoordinates(2, mailSutunNo) + " hücresi geçerli bir mail adresi değildir.");
                }
                sayilarTmp.Remove(mailSutunNo);

                //varsa CCler atanır
                if (degiskenBaseOptions.AutoCCOn)
                {
                    var tmpCCs = "";
                    foreach (var ccSutunNo in ccSutunNolari)
                    {
                        if (!string.IsNullOrWhiteSpace(excelSheet.Cells[2, ccSutunNo].Value))
                        {
                            tmpCCs = tmpCCs + excelSheet.Cells[2, ccSutunNo].Value.ToString().Trim() + "; ";
                        }
                        sayilarTmp.Remove(ccSutunNo);
                    }
                    degiskencik.CCs = tmpCCs;
                }

                //kalan sutun noları değişken olmalı, değişkenler atanır
                foreach (var degiskenSutunNo in sayilarTmp)
                {
                    var tmpDegisken = new Degisken();
                    tmpDegisken.degiskenAdi = excelSheet.Cells[1, degiskenSutunNo].Value.ToString().Trim();
                    if (string.IsNullOrWhiteSpace(excelSheet.Cells[2, degiskenSutunNo].Value))
                    {
                        tmpDegisken.degiskenText = "";
                    }
                    else
                    {
                        tmpDegisken.degiskenText = excelSheet.Cells[2, degiskenSutunNo].Value.ToString().Trim();
                    }

                    degiskencik.Degiskenler.Add(tmpDegisken);
                }

                //Değişkenlerden OFT dosyası içerisinde olmayan var mı?
                var oftDegiskenResult = OftContainsAllDegiskens(oftPath, degiskencik.Degiskenler);
                if (oftDegiskenResult != null)
                {
                    throw new Exception("Oft dosyanızda " + oftDegiskenResult + " isimli değişken bulunamadı. Lütfen kontrol ediniz.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new ErrorDataResult<DegiskenBase>(e.Message);
            }
            finally
            {
                //excel dosyası kaydedilir ve kapatılır
                wb.Save();
                wb.Close();
            }

            return new SuccessDataResult<DegiskenBase>(degiskencik);
        }

        private static List<string> GetHeadings(Worksheet excelSheet)
        {
            List<string> basliklar = new List<string>();
            int blankCellCount = 0;
            var blankCellFound = false;
            int loopIndex = 1;
            
            while (blankCellCount < 4)
            {
                //eğer hücre boş ise
                if (string.IsNullOrWhiteSpace(excelSheet.Cells[1, loopIndex].Value) )
                {
                    blankCellFound = true;
                    blankCellCount++;
                    loopIndex++;
                    continue;
                }

                //boş hücre bulunduktan sonra kod buraya geliyorsa isimlendirilmemiş sütun var demektir.
                if (blankCellFound)
                {
                    throw new Exception(Messages.EmptyHeading);
                }
                
                var baslikToAdd = excelSheet.Cells[1, loopIndex].Value.ToString().Trim();

                //aynı değişkenden duplicate var mı?
                if (basliklar.Contains(baslikToAdd))
                {
                    if(baslikToAdd == "konu" || baslikToAdd == "subject")
                    {
                        throw new Exception("Excelde birden fazla konu sütunu bulundu. Lütfen sadece bir konu sütunu ekleyeniz");
                    }

                    if (baslikToAdd == "mail" || baslikToAdd == "email" || baslikToAdd == "e-mail")
                    {
                        throw new Exception("Excelde birden fazla mail sütunu bulundu. Lütfen sadece bir mail sütunu ekleyeniz");
                    }

                    if (baslikToAdd.ToLower() == "cc" )
                    {

                    }
                    else
                    {
                        throw new Exception("Excelde aynı değişkenden birden fazla bulunmaktadır. Lütfen mükerrer değişkenleri kaldırınız.");
                    }
                    
                }
                basliklar.Add(baslikToAdd);
                loopIndex++;
            }           

            return basliklar;
        }

        private static string OftContainsAllDegiskens(string oftFileAddress, List<Degisken> degiskenler )
        {
            OutlookApp outlookApp = new OutlookApp();
            Microsoft.Office.Interop.Outlook.Folder folder = outlookApp.Session.GetDefaultFolder(
                        Outlook.OlDefaultFolders.olFolderDrafts) as Outlook.Folder;
            Outlook.MailItem mail = outlookApp.CreateItemFromTemplate(
                oftFileAddress, folder) as Outlook.MailItem;
            mail.BodyFormat = OlBodyFormat.olFormatHTML;

            foreach (var degisken in degiskenler)
            {
                if (!mail.HTMLBody.Contains(degisken.degiskenAdi) ) 
                {
                    mail.Close(OlInspectorClose.olDiscard);
                    return degisken.degiskenAdi;
                } 
            }
            //kaydetmeden kapat.
            mail.Close(OlInspectorClose.olDiscard);
            return null;
        }

    }
}
