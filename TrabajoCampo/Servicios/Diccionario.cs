using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Diccionario
    {
        private static Diccionario dic;
        private Dictionary<string,string> dicc= new Dictionary<string, string>();
        private static object objLock = new object();
        public void CambiarIdioma(Dictionary<string,string> d)
        {
            dicc = d;
        }
        public void ActualizarDiccionario(Dictionary<string,string> d)
        {
            dicc = d;
        }
        public Dictionary<string,string> diccionario
        {
            get
            { return dicc; }
        }
        public static Diccionario Instancia
        {
            get
            {
                if (dic == null)
                {
                    lock (objLock)
                    {
                        if (dic == null)
                        {
                            dic = new Diccionario();
                        }
                    }
                }
                return dic;
            }
        }
    }
}
