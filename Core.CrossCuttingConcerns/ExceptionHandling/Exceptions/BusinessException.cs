﻿namespace Core.CrossCuttingConcerns.ExceptionHandling.Exceptions
{
    public class BusinessException:Exception
    {
        public BusinessException(string message):base(message)
        {

        }

    }
}
