﻿namespace Core.CrossCuttingConcerns.ExceptionHandling.Exceptions
{
    public class AuthorizationException:Exception
    {
        public AuthorizationException(string message):base(message)
        {

        }
    }
}
