using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeyileBogh.Helpers
{
    public static class ValidationHelper
    {
        //public static bool CheckIfMailRequirementsValid(MailTemplate mailTemplate)
        //{
        //    if (advancedSettingsChanged)
        //    {
        //        string message = "Gelişmiş ayarlarda yaptığınız değişiklikler kaydedilmedi. Devam etmek istiyor musunuz?";
        //        string title = "Uyarı";
        //        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        //        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
        //        if (result == DialogResult.No)
        //        {
        //            logger.Log("Gelişmiş ayarları kaydetmediğiniz için program çalışmayı durdurdu", false);
        //            return false;
        //        }
        //    }

        //    if (tb_MailSubject.Text.Trim() == "" && !cb_autoSubject.Checked)
        //    {
        //        MessageBox.Show("Mail Konusu boş geçilemez!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        logger.Log("Mail kutusu boş bırakıldığı için program çalışmayı durdurdu.", false);
        //        return false;
        //    }

        //    if (tb_mailSender.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Gönderen kutusu boş geçilemez!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        logger.Log("Gönderen kutusu boş bırakıldığı için program çalışmayı durdurdu.", false);
        //        return false;
        //    }

        //    if (!ValidationHelper.EmailIsValid(tb_mailSender.Text))
        //    {
        //        MessageBox.Show("Lütfen geçerli bir mail adresi yazınız!!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        logger.Log("Geçerli bir mail yazılmadığı için program çalışmayı durdurdu.", false);
        //        return false;
        //    }
        //    logger.Log("Gönderici mail geçerlilik kontrolü başarılı");

        //    if (mailTemplate.excelPath == null)
        //    {
        //        MessageBox.Show("Excel dosyası yüklemeniz gerekmektedir!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        logger.Log("Excel dosyası yüklenmediği için program çalışmayı durdurdu.", false);
        //        return false;
        //    }
        //    else if (ExcelHelper.ExcelIsOpen(mailTemplate.excelPath))
        //    {
        //        MessageBox.Show("Excel dosyanız açık kalmış. Lütfen excel dosyasını kapatıp tekrar deneyin", "Excel Açık", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        logger.Log("Excel dosyası açık kaldığı için program çalışmayı durdurdu.", false);
        //        return false;
        //    }
        //    else if (mailTemplate.oftAdresi == null)
        //    {
        //        MessageBox.Show("Oft dosyası yüklemeniz gerekmektedir!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        logger.Log("Oft dosyası yüklenmediği için program çalışmayı durdurdu.", false);
        //        return false;
        //    }
        //    logger.Log("Dosya yüklemeleri kontrolü başarılı");

        //    return true;
        //}

        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static int ValidatePositiveInteger(string value)
        {
            int tmpValue = 0;
            if (int.TryParse(value.Trim(), out tmpValue))
            { }
            else
            {
                MessageBox.Show("Girdiğiniz ifade bir tam sayı değildir, lütfen tamsayı ifade giriniz!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (tmpValue <= 0)
            {
                MessageBox.Show("Girdiğiniz ifade negatif sayı veya 0 olamaz., lütfen pozitif tamsayı giriniz!!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return tmpValue;
        }
    }
}
