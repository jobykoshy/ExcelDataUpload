﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelDataReaderWebApi.CustomExceptions
{
    public class ValidationException:Exception
    {
        public ValidationException(string msg):base(msg)
        {

        }
    }
}
