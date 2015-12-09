﻿using System;

namespace OS.Business.Logic.Exceptions
{
    public class BaseBusinessException : Exception
    {
        public BaseBusinessException()
        {
        }

        public BaseBusinessException(string message) : base(message)
        {
        }
    }
}