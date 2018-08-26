using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Traductor
    {
        DAL.Traductor mapperTraductor = new DAL.Traductor();

        public void CambiarIdioma(int idioma)
        {
            Dictionary<string,string> dic= mapperTraductor.TraerTraducciones(idioma);
            Servicios.Diccionario.Instancia.ActualizarDiccionario(dic);
        }
        public Dictionary<string,string> TraerControles()
        {
            Dictionary<string, string> dic = mapperTraductor.TraerTraducciones(1);
            return dic;
        }

        public void CrearTraduccion(string idioma,Dictionary<string,string> dic)
        {
            mapperTraductor.CrearTraduccion(idioma, dic);
        }
    }
}
