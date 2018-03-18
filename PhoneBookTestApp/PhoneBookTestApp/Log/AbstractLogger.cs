using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    public abstract class AbstractLogger
    {
        public abstract bool Log(string errorSource, string errorMessage);
    }
}
