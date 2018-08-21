using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sesion
    {
        private static Sesion ses;
        private BE.Usuario usu;

        private static object objLock = new object();
        
        public void Login(BE.Usuario usuario)
        {
            usu = usuario;
        }
        public void Logout()
        {
            usu = null;
        }
        public BE.Usuario usuario
        {
            get
            { return usu; }
        }

        public static Sesion Instancia
        {
            get
            {
                if (ses==null)
                {
                    lock(objLock)
                    {
                        if (ses==null)
                        {
                            ses = new Sesion();
                        }
                    }
                }
                return ses;
            }
        }
    }
}
