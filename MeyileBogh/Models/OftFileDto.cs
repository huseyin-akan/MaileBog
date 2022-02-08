using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeyileBogh.Models
{
    public class OftFileDto
    {
        public OftFileDto(string fileName, long fileSize)
        {
            FileName = fileName;
            FileSize = fileSize;
        }
        public string FileName{ get; set; }
        public long FileSize { get; set; }
    }
}
