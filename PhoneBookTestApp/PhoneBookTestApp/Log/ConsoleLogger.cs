using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    public class ConsoleLogger : AbstractLogger
    {
        public override bool Log(string errorSource, string errorMessage)
        {
            Console.WriteLine(string.Format("SOURCE:{0}", errorSource) + string.Format("Error:{0}", errorMessage));
            return true;
        }
    }
}
