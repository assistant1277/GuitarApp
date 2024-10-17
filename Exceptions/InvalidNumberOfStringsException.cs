using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Exceptions
{
    public class InvalidNumberOfStringsException:Exception
    {
        public InvalidNumberOfStringsException(string message): base(message) { }
    }
}
