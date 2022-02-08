using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MeyileBogh.Models
{
    //Exceldeki her bir satırı ifade eder.
    public class DegiskenBase
    {
        public DegiskenBase()
        {
            this.Degiskenler = new List<Degisken>();
        }

        public string MailAddress;
        public List<Degisken> Degiskenler;
        public string Subject;        
        public string CCs;
    }
}
