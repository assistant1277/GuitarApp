﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Exceptions
{
    public class InvalidModelException:Exception
    {
        public InvalidModelException(string message): base(message) { }
    }
}
