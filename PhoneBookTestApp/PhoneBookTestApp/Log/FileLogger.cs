using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using PhoneBookTestApp.Log;

namespace PhoneBookTestApp
{
    public class FileLogger : AbstractLogger
    {
        public override bool Log(string errorSource, string errorMessage)
        {
            try
            {
                FileStream fs = new FileStream("AppLog.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLineAsync(string.Format(DateTime.Now.ToString() + " ==> SOURCE:{0}", errorSource) + string.Format("Error:{0}", errorMessage));
                sw.Close();
                fs.Close();
                fs.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerType.Console, "Writing Log Failed!", ex.StackTrace);
                return false;
            }
        }
    }
}
