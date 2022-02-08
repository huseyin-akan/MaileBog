using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeyileBogh.Helpers.Abstract
{
    public interface ILogger
    {
        void Log(string logText, bool isSuccess = true);

        void LogMailResult(string logText);
    }
}
