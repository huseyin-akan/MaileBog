using MeyileBogh.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeyileBogh.Helpers
{
    public static class FileDialogHelper
    {
        public static OftFileDto ChooseOft()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Oft Dosyası Seçiniz",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "oft",
                Filter = "Outlook Template Files (*.oft)|*.oft",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //byte olarak size'ı aldık.
                var size = new FileInfo(openFileDialog1.FileName).Length;
                return new OftFileDto(openFileDialog1.FileName, size);
            }
            return null;
        }

        public static string ChooseExcel()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Excel Dosyası Seçiniz",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "Excel Files (*.xlsx; *.xls)|*.xlsx; *.xls",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            return null;
        }
    }
}
