using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicios
{
    public class LoginException : Exception
    {
        public LoginException(LoginResult res)
        {
            resultado = res;
        }
        public LoginResult resultado;

    }
}