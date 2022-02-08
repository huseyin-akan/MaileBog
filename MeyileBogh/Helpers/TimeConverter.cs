using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeyileBogh.Helpers
{
    public static class TimeConverter
    {
        public static string ConverLongToMs(long time)
        {
            int remainingHour = 0, remaingMin = 0, remainingSec = 0, remainingMs = 0;
            string remainingTime = "";

            //show only ms
            if (time < 1000)
            {
                remainingTime = time + " ms";
            }
            //show sec and ms
            else if (time < 60000)
            {
                remainingSec = (int)time / 1000;
                remainingMs = (int)time % 1000;
                remainingTime = remainingSec + " sn " + remainingMs + " ms";
            }
            //show min, sec and ms
            else if (time < 3600000)
            {
                remaingMin = (int)time / 60000;
                remainingSec = (int)(time - remaingMin * 60000) / 1000;
                remainingMs = (int)(time - remaingMin * 60000) % 1000;
                remainingTime = remaingMin + " dk " + remainingSec + " sn " + remainingMs + " ms";
            }
            //show hour, min, sec and ms
            else if (time <= 86400000)
            {
                remainingHour = (int)time / 3600000;
                remaingMin = (int)(time - remainingHour * 3600000) / 60000;
                remainingSec = (int)(time - remainingHour * 3600000 - remaingMin * 60000) / 1000;
                remainingMs = (int)(time - remainingHour * 3600000 - remaingMin * 60000) % 1000;
                remainingTime = remainingHour + " saat" + remaingMin + " dk " + remainingSec + " sn " + remainingMs + " ms";
            }
            //show days
            else
            {
                remainingTime = "Bu işlem günler alacak gibi duruyor.";
            }
            return remainingTime;
        }
    }
}
