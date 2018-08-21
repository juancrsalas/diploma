using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario
    {
        DAL.MapperUsuario mapper = new DAL.MapperUsuario();
        public BE.Usuario TraerUsuario(string email)
        {
            return mapper.TraerUsuario(email);
        }
        public int AltaUsuario(string email, string pass)
        {
            int fa = 0;
            if (mapper.BuscarEmail(email)==false)
            {
                string encriptada = Servicios.Encriptador.Hashear(pass);
                string sumadatos = email + encriptada;
                string DVH = Servicios.Encriptador.Hashear(sumadatos);
                mapper.AltaUsuario(email, encriptada,DVH);
            }
            return fa;
        }
        public Servicios.LoginResult Validar(string email,string pass)
        {
            Servicios.LoginResult res;
            if (ComprobarEmail(email)==true)
            {
                if (VerificarPassword(email,pass)==true)
                {
                    res = Servicios.LoginResult.ValidUser;
                }
                else
                {
                    throw new Servicios.LoginException(Servicios.LoginResult.InvalidPassword);
                }
            }
            else
            {
                throw new Servicios.LoginException(Servicios.LoginResult.InvalidEmail);
            }
            return res;
        }
        private Boolean ComprobarEmail(string email)
        {
            return mapper.BuscarEmail(email);
        }
        private Boolean VerificarPassword(string email,string pass)
        {
            string encriptada = Servicios.Encriptador.Hashear(pass);
            return mapper.VerificarPass(email, encriptada);
        }
    }
}
