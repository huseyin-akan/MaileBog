using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeyileBogh
{
    class MailTemplate
    {
        public MailTemplate() 
        {
            gonderilecekAdres = "";
            gonderenAdres = "" ;
            CCAdres = "";
            mailKonusu = "";
        }

        public string excelPath { get; set; }

        public string gonderilecekAdres { get; set; }

        public string oftAdresi { get; set; }

        public string gonderenAdres { get; set; }
        public string CCAdres { get; set; }

        public string mailKonusu { get; set; }
    }
}
