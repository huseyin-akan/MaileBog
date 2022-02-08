using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeyileBogh.Helpers
{
    public static class ExcelHelper
    {
        private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string ToExcelCoordinates(int rowNo, int columnNo)
        {
            string str = string.Empty;
            while (columnNo > 0)
            {
                str = ALPHABET[(columnNo - 1) % 26] + str;
                columnNo /= 26;
            }

            return str + rowNo;
        }

        public static bool ExcelIsOpen(string excelPath)
        {
            try
            {
                Stream s = File.Open(excelPath, FileMode.Open, FileAccess.Read, FileShare.None);

                s.Close();

                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
