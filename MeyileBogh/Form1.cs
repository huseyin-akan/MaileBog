using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OutlookApp = Microsoft.Office.Interop.Outlook.Application;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Outlook;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using MeyileBogh.Helpers;
using MeyileBogh.Models;
using MeyileBogh.Helpers.Abstract;

namespace MeyileBogh
{
    public partial class Form1 : Form
    {        
        //Global Variables
        MailTemplate mailTemplate = new MailTemplate();

        private int gonderilenMailSayisi = 0, gonderilecekMailSayisi = 0, kalanMailSayisi = 0, arsivlenenMailSayisi = 0, 
            kalanArsivMailSayisi = 0, arsivlenecekMailSayisi = 0;
        private double yuzde = 0;
        long gecenSure = 0, ortMailSuresi = 0, tahminiBitis = 0, ortArsivSuresi = 543;

        OutlookApp outlookApp = new OutlookApp();
        
        Stopwatch watch = new Stopwatch();
        Stopwatch watch2 = new Stopwatch();
        int sleepingTime = 2300;
        
        long oftFileSize;
        Outlook.MAPIFolder oSource = null, oTarget = null;
        TimeSpan elapsed = new TimeSpan();
        List<DegiskenBase> degiskenBase;
        BackgroundWorker worker;

        bool arsivlemeYapilacak = true;
        int otoArsivKotasi = 50;
        bool advancedSettingsChanged = false;

        public int SubjectColumnNo = 0;
        public string excelCC = "";
        List<int> ccSutunNos = new List<int>();
        ILogger logger;

        public Form1()
        {
            InitializeComponent();

            //Bu butonu şimdilik saklıyoruz, pause işlemi daha eklenmedi.
            btn_pause.Hide();

            ScreenSaver.Activate();

            logger = new TextBoxLogger(tb_LogPanel);

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            //Disable the maximize screen button on the right top
            MaximizeBox = false;

            //Some starting Values
            lbl_yuzde.Text = "%0";
            lbl_n_tobeSent.Text = "0";
            lbl_n_sent.Text = "0";
            lbl_n_kalan.Text = "0";
            lbl_kalan_tahmini.Text = "0";
        }

        //maile boğ butonuna tıklayınca kontrolleri yapar ve uygunsa mail gönderme işlemi başlar
        private void button1_Click(object sender, EventArgs e)
        {
            logger.Log("Mail başlatımı için genel kontroller başlatıldı");
            if (!CheckIfMailRequirementsValid() )
            {
                return;
            }            

            //Yardımcı metot ile exceldeki değişkenleri otomatik alıyoruz ve hata kontrolü yapıyoruz.
            var degiskenOptions = new DegiskenBaseOptions();
            degiskenOptions.AutoCCOn = cb_autoCC.Checked;
            degiskenOptions.AutoSubjectOn = cb_autoSubject.Checked;
            logger.Log("Excelden değişken tanımlama işlemi başlatıldı");

            var result= DegiskenInitializer.Initialize(mailTemplate.excelPath, mailTemplate.oftAdresi, degiskenOptions);
            if (result.Success == false)
            {
                logger.Log("Excelden değişken tanımlama işlemi başarısız sonuçlandı", false);
                return;
            }
            degiskenBase = result.Data;
            logger.Log("Excelden değişken tanımlama işlemi başarıyla sonuçlandı. Mail gönderimi başlatılıyor", true);

            gonderilecekMailSayisi = degiskenBase.Count;

            //Arşivleme yapılsın mı değerlendirir.
            if (cb_otoArsiv.Checked)
            {
                EvaluateArchiving();
            } 

            //kronometre ve timer nesnesi başlar
            timer1.Start();
            watch.Start();

            //disabled edilecek kısımlar
            cb_autoSubject.Enabled = false;
            cb_autoCC.Enabled = false;
            cb_otoArsiv.Enabled = false;
            cb_manuelArsiv.Enabled = false;
            tb_sleepingTime.Enabled = false;
            tb_otoArsivKota.Enabled = false;
            tb_manuelArsivKotasi.Enabled = false;
            tb_MailSubject.Enabled = false;
            tb_CC.Enabled = false;

            //arka plan işlemleri başlar
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        //sürecin başlayabilmesi için gerekli kontroller:
        public bool CheckIfMailRequirementsValid()
        {
            if (advancedSettingsChanged)
            {
                string message = "Gelişmiş ayarlarda yaptığınız değişiklikler kaydedilmedi. Devam etmek istiyor musunuz?";
                string title = "Uyarı";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    logger.Log("Gelişmiş ayarları kaydetmediğiniz için program çalışmayı durdurdu", false);
                    return false;
                }
            }

            if (tb_MailSubject.Text.Trim() == "" && !cb_autoSubject.Checked)
            {
                MessageBox.Show("Mail Konusu boş geçilemez!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Log("Mail kutusu boş bırakıldığı için program çalışmayı durdurdu.", false);
                return false;
            }

            if (tb_mailSender.Text.Trim() == "")
            {
                MessageBox.Show("Gönderen kutusu boş geçilemez!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Log("Gönderen kutusu boş bırakıldığı için program çalışmayı durdurdu.", false);
                return false;
            }

            if (!ValidationHelper.EmailIsValid(tb_mailSender.Text))
            {
                MessageBox.Show("Lütfen geçerli bir mail adresi yazınız!!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Log("Geçerli bir mail yazılmadığı için program çalışmayı durdurdu.", false);
                return false;
            }
            logger.Log("Gönderici mail geçerlilik kontrolü başarılı");

            if (mailTemplate.excelPath == null)
            {
                MessageBox.Show("Excel dosyası yüklemeniz gerekmektedir!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Log("Excel dosyası yüklenmediği için program çalışmayı durdurdu.", false);
                return false;
            }
            else if (ExcelHelper.ExcelIsOpen(mailTemplate.excelPath))
            {
                MessageBox.Show("Excel dosyanız açık kalmış. Lütfen excel dosyasını kapatıp tekrar deneyin", "Excel Açık", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Log("Excel dosyası açık kaldığı için program çalışmayı durdurdu.", false);
                return false;
            }
            else if (mailTemplate.oftAdresi == null)
            {
                MessageBox.Show("Oft dosyası yüklemeniz gerekmektedir!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Log("Oft dosyası yüklenmediği için program çalışmayı durdurdu.", false);
                return false;
            }
            logger.Log("Dosya yüklemeleri kontrolü başarılı");

            return true;
        }

        //Creates a mail from .oft template and sends the email
        public void CreateItemFromTemplate()
        {
            //the number of sent mail
            int gidenKutusuMevcutMail = outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderSentMail).Items.Count;

            //eğer arşivleme yapılacaksa arşivlenecek mail sayısı hesaplanır ve ekrana yazdırılır
            if (arsivlemeYapilacak)
            {
                if (gonderilecekMailSayisi < otoArsivKotasi)
                {
                    arsivlenecekMailSayisi = gidenKutusuMevcutMail;
                }
                else if (gonderilecekMailSayisi >= otoArsivKotasi)
                {
                    arsivlenecekMailSayisi = (int)gonderilecekMailSayisi / otoArsivKotasi;
                    arsivlenecekMailSayisi = arsivlenecekMailSayisi * otoArsivKotasi + gidenKutusuMevcutMail;
                }
            }

            try
            {
                //degiskenBase objelerini dönüyoruz:
                foreach (var degiskencik in degiskenBase)
                {
                    //arşivleme yapılacaksa ve belirli kotaya ulaşıldıysa arşivlemeyi başlat
                    if (arsivlemeYapilacak && gonderilenMailSayisi % otoArsivKotasi == 0 && gonderilenMailSayisi != 0)
                    {
                        Arsivle();
                    }

                    //gönderilecek adresi al
                    mailTemplate.gonderilecekAdres = degiskencik.MailAddress;

                    //gönderici adres
                    mailTemplate.gonderenAdres = tb_mailSender.Text;

                    //eğer mail konusu excelden alınacaksa, excelden al.
                    if (cb_autoSubject.Checked == true)
                    {
                        mailTemplate.mailKonusu = degiskencik.Subject;
                    }
                    else
                    {
                        mailTemplate.mailKonusu = tb_MailSubject.Text;
                    }

                    //eğer CC'ye eklenecek mailler excelden gelecekse
                    if (cb_autoCC.Checked == true)
                    {
                        mailTemplate.CCAdres = degiskencik.CCs;
                    }
                    else
                    {
                        mailTemplate.CCAdres = tb_CC.Text;
                    }

                    //Taslak mailden mail oluşturma
                    Outlook.Folder folder = outlookApp.Session.GetDefaultFolder(
                        Outlook.OlDefaultFolders.olFolderDrafts) as Outlook.Folder;
                    Outlook.MailItem mail = outlookApp.CreateItemFromTemplate(
                        mailTemplate.oftAdresi, folder) as Outlook.MailItem;

                    //gönderilecek mail ile ilgili düzenlemeler
                    mail.BodyFormat = OlBodyFormat.olFormatHTML;
                    mail.SentOnBehalfOfName = mailTemplate.gonderenAdres;
                    mail.To = mailTemplate.gonderilecekAdres;
                    mail.Subject = mailTemplate.mailKonusu;
                    if (mailTemplate.CCAdres != "")
                    {
                        mail.CC = mailTemplate.CCAdres;
                    }

                    //mail gövdesinde değiştirilecek değişkenler
                    foreach (var degisken in degiskencik.Degiskenler)
                    {
                        mail.HTMLBody = mail.HTMLBody.Replace(degisken.degiskenAdi, degisken.degiskenText);
                    }
                    mail.Send();

                    //istatistiksel hesaplamaları yapar
                    gonderilenMailSayisi++;
                    yuzde = gonderilenMailSayisi * 100 / gonderilecekMailSayisi;
                    kalanMailSayisi = gonderilecekMailSayisi - gonderilenMailSayisi;

                    //outlook daha yavaş çalıştığı için programı uyutuyoruz
                    Thread.Sleep(sleepingTime);

                    //istatistiksel hesaplamalar
                    gecenSure = watch.ElapsedMilliseconds;
                    ortMailSuresi = gecenSure / gonderilenMailSayisi;

                    //ekrandaki verileri yenileme talimatı verir, 69 olması önemli değil. Ekranı yeniliyoruz.
                    worker.ReportProgress(69, mailTemplate.gonderilecekAdres);
                }

            }
            catch (System.Exception ex)
            {
                //Result yapısını getir ve burda ve yukarıda result gönder
                //worker.ReportProgress(69, mailTemplate.gonderilecekAdres);
                MessageBox.Show(ex.Message);                
            }
            finally
            {
                //toplam sure hesaplanır ve kalan süre 0'lanır
                gecenSure = watch.ElapsedMilliseconds;
                tahminiBitis = 0;
                backgroundWorker1.ReportProgress(69, "mailing_finished");

                //timer ve kronometre durdurulur
                timer1.Stop();
                watch.Stop();               

                //arka planda çalışan kodlar durdurulur
                backgroundWorker1.CancelAsync();

                //mutlu son mesajı verilir.
                MessageBox.Show("İşte bu kadar. Tamamdır bu iş. " + gonderilenMailSayisi + " adet mail " + TimeConverter.ConverLongToMs(gecenSure) + " sürede başarıyla gönderildi. Hadi geçmiş olsun. Bir daha bekleriz efenim :) :) :)");

                //tekrar gönderme işlemine hazır hale getirilir.
            }
        }

        //Ekran Görünümü İçin Sıfırlamalar ve gerekli değişkenleri sıfırlamalar
        private void ResetAll()
        {
            tb_BrowsedExcel.Enabled = true;
            tb_BrowsedOft.Enabled = true;
            tb_MailSubject.Text = "";
            tb_mailSender.Text = "";
            tb_BrowsedExcel.Text = "";
            tb_BrowsedOft.Text = "";
            lbl_yuzde.Text = "%0";
            tb_CC.Text = "";
            cb_autoSubject.Enabled = true;
            cb_autoCC.Enabled = true;
            lbl_n_tobeSent.Text = "0";
            lbl_n_sent.Text = "0";
            progressBar1.Value = 0;
            lbl_n_kalan.Text = "0";
            lbl_kalan_tahmini.Text = "0";
            lbl_gecen_dk.Text = "00:00:00";
            lbl_arsivlenecekMail.Text = "0";
            lbl_arsivlenenMail.Text = "0";
            gonderilenMailSayisi = 0;
            gonderilecekMailSayisi = 0;
            kalanMailSayisi = 0;
            arsivlenenMailSayisi = 0;
            kalanArsivMailSayisi = 0;
            arsivlenecekMailSayisi = 0;
            yuzde = 0;
            gecenSure = 0;
            ortMailSuresi = 0;
            tahminiBitis = 0;
            ortArsivSuresi = 543;
            watch.Reset();
            watch2.Reset();
            SubjectColumnNo = 0;
            excelCC = "";
            ccSutunNos.Clear();
            cb_otoArsiv.Enabled = true;
            cb_manuelArsiv.Enabled = true;
            tb_sleepingTime.Enabled = true;
            tb_otoArsivKota.Enabled = true;
            tb_manuelArsivKotasi.Enabled = true;
            tb_MailSubject.Enabled = true;
            tb_CC.Enabled = true;
            lbl_kalan_tahmini.Location = new Point(214, 206);
        }

        public void SendTestMail(string testMailAddress)
        {
            logger.Log("Test mail gönderimi için genel kontroller başlatıldı");
            if (!CheckIfMailRequirementsValid())
            {
                return;
            }

            //Yardımcı metot ile exceldeki değişkenleri otomatik alıyoruz ve hata kontrolü yapıyoruz.
            var degiskenOptions = new DegiskenBaseOptions();
            degiskenOptions.AutoCCOn = cb_autoCC.Checked;
            degiskenOptions.AutoSubjectOn = cb_autoSubject.Checked;
            logger.Log("Test mail gönderimi için excelden değişken tanımlama işlemi başlatıldı");

            var result = DegiskenInitializer.Test(mailTemplate.excelPath, mailTemplate.oftAdresi, degiskenOptions);
            if (result.Success != true)
            {
                logger.Log("Test mail gönderimi için excelden değişken tanımlama işlemi başarısız sonuçlandı", false);
                return;
            }
            var degiskencik = result.Data;

            degiskencik.MailAddress = testMailAddress;

            logger.Log("Test mail gönderimi için excelden değişken tanımlama işlemi başarıyla sonuçlandı. Mail gönderimi başlatılıyor", true);

            CreateTestMailTemplate(degiskencik);
        }

        public void CreateTestMailTemplate(DegiskenBase testDegiskencik)
        {
            try
            {
                //gönderilecek adresi al
                mailTemplate.gonderilecekAdres = testDegiskencik.MailAddress;

                //gönderici adres
                mailTemplate.gonderenAdres = tb_mailSender.Text;

                //eğer mail konusu excelden alınacaksa, excelden al.
                if (cb_autoSubject.Checked == true)
                {
                    mailTemplate.mailKonusu = testDegiskencik.Subject;
                }
                else
                {
                    mailTemplate.mailKonusu = tb_MailSubject.Text;
                }

                //eğer CC'ye eklenecek mailler excelden gelecekse
                if (cb_autoCC.Checked == true)
                {
                    mailTemplate.CCAdres = testDegiskencik.CCs;
                }
                else
                {
                    mailTemplate.CCAdres = tb_CC.Text;
                }

                //Taslak mailden mail oluşturma
                Outlook.Folder folder = outlookApp.Session.GetDefaultFolder(
                    Outlook.OlDefaultFolders.olFolderDrafts) as Outlook.Folder;
                Outlook.MailItem mail = outlookApp.CreateItemFromTemplate(
                    mailTemplate.oftAdresi, folder) as Outlook.MailItem;

                //gönderilecek mail ile ilgili düzenlemeler
                mail.BodyFormat = OlBodyFormat.olFormatHTML;
                mail.SentOnBehalfOfName = mailTemplate.gonderenAdres;
                mail.To = mailTemplate.gonderilecekAdres;
                mail.Subject = mailTemplate.mailKonusu;
                if (mailTemplate.CCAdres != "")
                {
                    mail.CC = mailTemplate.CCAdres;
                }

                //mail gövdesinde değiştirilecek değişkenler
                foreach (var degisken in testDegiskencik.Degiskenler)
                {
                    mail.HTMLBody = mail.HTMLBody.Replace(degisken.degiskenAdi, degisken.degiskenText);
                }
                mail.Send();

                logger.LogMailResult(mailTemplate.gonderilecekAdres + " adresine test maili gönderimi başarılı oldu.");
                MessageBox.Show(mailTemplate.gonderilecekAdres + " adresine test maili gönderimi başarılı oldu. Gönderilen mailde maddi hata var mı diye inceleyebilirsiniz.");
            }
            catch (System.Exception ex)
            {
                //Result yapısını getir ve burda ve yukarıda result gönder
                //worker.ReportProgress(69, mailTemplate.gonderilecekAdres);
                MessageBox.Show(ex.Message);
            }
        }

        //Test Butonuna Tıklanınca
        private void btn_testing_Click(object sender, EventArgs e)
        {
            string testMailAddress = Prompt.ShowDialog("Test mailini göndermek istediğiniz mail adresini yazınız", "Mail Testing");
            
            // mail formatı kontrolü yap, hata varsa hata ver.             
            if (!ValidationHelper.EmailIsValid(testMailAddress) && testMailAddress != "")
            {
                MessageBox.Show("Girdiğiniz mail adresi geçerli değildir. Lütfen geçerli bir mail adresi giriniz");
                return;
            }

            if (testMailAddress!= "")
            {
                SendTestMail(testMailAddress);
            }

        }

        //Otomatik arşivleme, 250 MB'dan büyükse arşivleme yapılıri yoksa yapılmaz.
        public void EvaluateArchiving()
        {
            //MB cinsinden sonuç değeri.
            var result =  (oftFileSize * gonderilecekMailSayisi) / 1048576;

            if (result>250)
            {
                arsivlemeYapilacak = true;
            }
            else
            {
                arsivlemeYapilacak = false;
            }
        }

        //oft dosyasını seçme işlemi
        private void button5_Click(object sender, EventArgs e)
        {
            var oftFileDto = FileDialogHelper.ChooseOft();

            //Archive değerlendirmesi için oft dosyası boyutunu aldık.
            oftFileSize = oftFileDto.FileSize;

            tb_BrowsedOft.Text = Path.GetFileName(oftFileDto.FileName);
            mailTemplate.oftAdresi = oftFileDto.FileName;           

            if (oftFileDto.FileName != null)
            {
                tb_BrowsedOft.Enabled = false;
            }
            else
            {
                tb_BrowsedOft.Enabled = true;
            }
        }

        //excel dosyası seçme işlemi
        private void button4_Click_1(object sender, EventArgs e)
        {
            var fileName = FileDialogHelper.ChooseExcel();
            tb_BrowsedExcel.Text = Path.GetFileName(fileName);
            mailTemplate.excelPath = fileName;

            if (fileName != null)
            {
                tb_BrowsedExcel.Enabled = false;
            }
            else
            {
                tb_BrowsedExcel.Enabled = true;
            }
        }

        //reset all button
        private void button2_Click(object sender, EventArgs e)
        {
            ResetAll();
        }


        //Button Animations
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.GhostWhite;
            button4.ForeColor = Color.Black;
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(128, 128, 255);
            button4.ForeColor = Color.FromArgb(255, 255, 192);
        }
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.GhostWhite;
            button5.ForeColor = Color.Black;
        }
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(128, 128, 255);
            button5.ForeColor = Color.FromArgb(255, 255, 192);
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.GhostWhite;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(128, 128, 255);
            button2.ForeColor = Color.FromArgb(255, 255, 192);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.GhostWhite;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(101, 101, 255); 
            button1.ForeColor = Color.White;
        }
        private void btn_reset_settings_MouseEnter(object sender, EventArgs e)
        {
            btn_reset_settings.BackColor = Color.GhostWhite;
            btn_reset_settings.ForeColor = Color.Black;
        }

        private void btn_reset_settings_MouseLeave(object sender, EventArgs e)
        {
            btn_reset_settings.BackColor = Color.FromArgb(128, 128, 255);
            btn_reset_settings.ForeColor = Color.FromArgb(255, 255, 192);
        }

        private void btn_kaydet_MouseEnter(object sender, EventArgs e)
        {
            btn_kaydet.BackColor = Color.GhostWhite;
            btn_kaydet.ForeColor = Color.Black;
        }

        private void btn_kaydet_MouseLeave(object sender, EventArgs e)
        {
            btn_kaydet.BackColor = Color.FromArgb(128, 128, 255);
            btn_kaydet.ForeColor = Color.FromArgb(255, 255, 192);
        }
        private void btn_testing_MouseEnter(object sender, EventArgs e)
        {
            btn_testing.BackColor = Color.GhostWhite;
            btn_testing.ForeColor = Color.Turquoise;
        }

        private void btn_testing_MouseLeave(object sender, EventArgs e)
        {
            btn_testing.BackColor = Color.Turquoise;
            btn_testing.ForeColor = Color.White;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_autoSubject.Checked == true)
            {
                cb_autoSubject.Text = "Oto ON";
                tb_MailSubject.Enabled = false;
                tb_MailSubject.Text = "";
            }
            else
            {
                cb_autoSubject.Text = "Oto OFF";
                tb_MailSubject.Enabled = true;
                tb_MailSubject.Text = "";
                SubjectColumnNo = 0;
            }
        }

        private void tb_sleepingTime_TextChanged(object sender, EventArgs e)
        {
            advancedSettingsChanged = true;
        }

        private void tb_otoArsivKota_TextChanged(object sender, EventArgs e)
        {
            advancedSettingsChanged = true;
        }

        private void tb_manuelArsivKotasi_TextChanged(object sender, EventArgs e)
        {
            advancedSettingsChanged = true;
        }

        private void btn_reset_settings_Click(object sender, EventArgs e)
        {
            tb_sleepingTime.Text = 2300.ToString();
            sleepingTime = 2300;
            
            cb_otoArsiv.Checked = true;
            lbl_otoArsiv.Enabled = true;
            tb_otoArsivKota.Enabled = true;
            tb_otoArsivKota.Text = 50.ToString();
            otoArsivKotasi = 50;
            
            cb_manuelArsiv.Checked = false;
            lbl_manuelArsiv.Enabled = false;
            tb_manuelArsivKotasi.Text = "";

            advancedSettingsChanged = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_autoCC.Checked == true)
            {
                cb_autoCC.Text = "Oto ON";
                tb_CC.Enabled = false;
            }
            else
            {
                cb_autoCC.Text = "Oto OFF";
                tb_CC.Enabled = true;
                tb_CC.Text = "";
                ccSutunNos.Clear();
            }
        }

        //Sayfa kapandığında:
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ScreenSaver.DeActivate();
        }

        //gelişmiş ayarları kaydet denilince
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (cb_otoArsiv.Checked)
            {
                otoArsivKotasi = ValidationHelper.ValidatePositiveInteger(tb_otoArsivKota.Text);
                if (otoArsivKotasi == 0)
                {
                    return;
                }
            }

            if (cb_manuelArsiv.Checked)
            {
                otoArsivKotasi = ValidationHelper.ValidatePositiveInteger(tb_manuelArsivKotasi.Text);
                if (otoArsivKotasi == 0)
                {
                    return;
                }
            }

            var valTmp = ValidationHelper.ValidatePositiveInteger(tb_sleepingTime.Text);
            if (valTmp != 0)
            {
                sleepingTime = valTmp;
            }
            else
            {
                return;
            }

            //eğer iki arşivleme de kapatılırsa arşivleme yapılmayacak.
            if (!cb_manuelArsiv.Checked && !cb_otoArsiv.Checked)
            {
                arsivlemeYapilacak = false;
            }

            advancedSettingsChanged = false;
            MessageBox.Show("Değişiklikler kaydedildi.");
        }


        //arka planda yapılacak işlemler:
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            worker = sender as BackgroundWorker;

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
            }
            else
            {
                //mail oluşturma ve içerisinde arşivleme işlemleri
                CreateItemFromTemplate();
            }
        }

        //talimat geldikçe ekrandaki nesneleri yeniler.
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lbl_n_tobeSent.Text = gonderilecekMailSayisi.ToString();
            lbl_arsivlenecekMail.Text = arsivlenecekMailSayisi.ToString();
            lbl_n_sent.Text = gonderilenMailSayisi.ToString();
            lbl_yuzde.Text = "%" + String.Format("{0:0.##}", yuzde);
            lbl_n_kalan.Text = kalanMailSayisi.ToString();
            progressBar1.Value = (int)yuzde;

            //her mail arşivlenince arşivlenen mail sayısını yaz.
            lbl_arsivlenenMail.Text = arsivlenenMailSayisi.ToString();

            tahminiBitis = (ortMailSuresi * kalanMailSayisi) + (ortArsivSuresi * kalanArsivMailSayisi);

            //kalan tahmini süreyi hesapla
            if ( e.UserState.ToString() == "mailing_finished")
            {
                tahminiBitis = 0;
                lbl_kalan_tahmini.Text = 0.ToString();
            }            

            if (e.UserState.ToString() == "archived" )
            {
                logger.Log("Arşivleme başarıyla gerçekleştirildi.");
            }else if (e.UserState.ToString() == "mailing_finished")
            {
                logger.Log("Mail gönderimi başarıyla sona erdi.");
            }
            else if(e.UserState.ToString() != "archiving")
            {
                logger.LogMailResult(e.UserState.ToString() + " adresine başarıyla mail gönderildi.");
            }            
        }

        //Otomatik Arşivleme onay kutusu tıklanınca:
        private void cb_otoArsiv_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_otoArsiv.Checked == true)
            {
                cb_otoArsiv.Text = "Otomatik Arşivleme Açık";
                lbl_otoArsiv.Enabled = true;
                tb_otoArsivKota.Enabled = true;

                if (cb_manuelArsiv.Checked)
                {
                    cb_manuelArsiv.Checked = false;
                    lbl_manuelArsiv.Enabled = false;
                    tb_manuelArsivKotasi.Enabled = false;
                    tb_manuelArsivKotasi.Text = "";
                    cb_manuelArsiv.Text = "Manuel Arşivleme Kapalı";
                }               
                
            }
            else
            {
                cb_otoArsiv.Text = "Otomatik Arşivleme Kapalı";
                lbl_otoArsiv.Enabled = false;
                tb_otoArsivKota.Enabled = false;
                tb_otoArsivKota.Text = "";
            }
            advancedSettingsChanged = true;
        }

        private void cb_manuelArsiv_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_manuelArsiv.Checked == true)
            {
                cb_manuelArsiv.Text = "Manuel Arşivleme Açık";
                lbl_manuelArsiv.Enabled = true;
                tb_manuelArsivKotasi.Enabled = true;

                if (cb_otoArsiv.Checked)
                {
                    cb_otoArsiv.Checked = false;
                    cb_otoArsiv.Text = "Otomatik Arşivleme Kapalı";
                    lbl_otoArsiv.Enabled = false;
                    tb_otoArsivKota.Enabled = false;
                    tb_otoArsivKota.Text = "";
                }
            }
            else
            {
                cb_manuelArsiv.Text = "Manuel Arşivleme Kapalı";
                lbl_manuelArsiv.Enabled = false;
                tb_manuelArsivKotasi.Enabled = false;
                tb_manuelArsivKotasi.Text = "";
            }
            advancedSettingsChanged = true;
        }

        //Her 100 ms'de yapılacaklar:
        private void timer1_Tick(object sender, EventArgs e)
        {
            //ekrana geçen süre yazdırılır.
            elapsed = watch.Elapsed;
            lbl_gecen_dk.Text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", Math.Floor(elapsed.TotalHours), elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds);

            //ekrana tahmini bitiş süresi ver.
            if (tahminiBitis >= 100)
            {
                tahminiBitis -= 100;
            }
            else
            {
                tahminiBitis = 0;

            }
            lbl_kalan_tahmini.Location = new Point(265, 206);
            lbl_kalan_tahmini.Text = TimeConverter.ConverLongToMs(tahminiBitis);
        }

        //otomatik arşivleme işlemleri:
        private void Arsivle()
        {
            //giden kutusunda gönderilmeyi bekleyen mail varsa bekliyoruz.
            bool gidenVar = true;
            oSource = outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderOutbox);
            watch2.Start();

            while (gidenVar)
            {
                int mailSayisi = oSource.Items.Count;

                if (mailSayisi != 0)
                {
                    Thread.Sleep(2000);
                }
                else
                {
                    gidenVar = false;
                }
            }

            Outlook.Folder folder;
            //"Auto Archiving" isminde arşiv dosyası yoksa oluşturur.
            try
            {
                folder = (Folder)outlookApp.Session.Folders["Auto Archiving"];
            }
            catch (System.Exception)
            {
                var newStore = outlookApp.GetNamespace("MAPI");
                newStore.AddStore(@"otoArchive.pst");
                folder = (Folder)outlookApp.Session.Folders["Outlook Data File"];
                folder.Name = "Auto Archiving";
            }
            
            //"Otonom Arşiv" isminde alt klasör yoksa oluşturur.
            string folderName = "OtonomArşiv";
            try
            {
                Folder customFolder = (Outlook.Folder)folder.Folders.Add(folderName,
        OlDefaultFolders.olFolderInbox);
            }
            catch (System.Exception)
            {
            }

            //Arşivleme işlemi
            try
            {
                oSource = outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderSentMail);
                oTarget = folder.Folders[folderName];
                int mailAdeti = oSource.Items.Count;

                //loop through the folders items
                for (int i = 0; i < mailAdeti; i++)
                {
                    //arşivlenecek mailleri taşı
                    oSource.Items[mailAdeti - i].Move(oTarget);

                    //arşiv istatistikleri
                    arsivlenenMailSayisi++;
                    ortArsivSuresi = watch2.ElapsedMilliseconds / arsivlenenMailSayisi;

                    //arşivlemenin yapıldığını ekrandaki rakamın artırılmasını söylüyoruz
                    worker.ReportProgress(i, "archiving");
                }
                //arşivlemenin bittiğini söylüyoruz
                worker.ReportProgress(69, "archived");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //release objects
            if (oTarget != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oTarget);
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            if (oSource != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSource);
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            watch2.Stop();
        }

    }
}
