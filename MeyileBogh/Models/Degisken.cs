using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeyileBogh
{
    //Oft dosyasında değiştirilecek değişkenleri ifade eder.
    public class Degisken
    {

        public Degisken()
        {
            degiskenAdi = "undefined";
            degiskenText = "undefined";
        }

        public string degiskenAdi { get; set; }
        public string degiskenText { get; set; }


    }
}
