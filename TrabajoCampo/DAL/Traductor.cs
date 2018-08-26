using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Traductor
    {
        Acceso ac = new Acceso();

        public Dictionary<string,string> TraerTraducciones(int idioma)
        {
            Dictionary<string,string> dic= new Dictionary<string, string>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@i", idioma);
            DataTable tabla = ac.Leer("TRADUCCIONES_LISTAR", parametros);
            foreach (DataRow row in tabla.Rows)
            {
                dic.Add(row["ClaveControl"].ToString(), row["Descripcion"].ToString());
            }
            return dic;
        }
        public int CrearTraduccion(string idioma,Dictionary<string,string> diccionario)
        {
            int fa = 0;
            if (TraerIdIdioma(idioma)==0)
            {
                AltaIdioma(idioma);
                int id = TraerIdIdioma(idioma);
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@ididioma", id);
                foreach (KeyValuePair<string, string> trad in diccionario)
                {
                    ac.Abrir();
                    parametros[1] = new SqlParameter("@clavecontrol", trad.Key);
                    parametros[2] = new SqlParameter("@descripcion", trad.Value.ToString());
                    fa = ac.Escribir("ALTA_DICCIONARIO", parametros);
                    ac.Cerrar();
                }
            }
            return fa;
        }
        private int AltaIdioma(string idioma)
        {
            ac.Abrir();
            int fa = 0;
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idioma", idioma);
            fa = ac.Escribir("ALTA_IDIOMA", param);
            ac.Cerrar();
            return fa;
        }
        private int TraerIdIdioma(string idioma)
        {
            int id=0;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@idioma", idioma);
            DataTable tabla = ac.Leer("IDIOMA_ID", parametros);
            if (tabla.Rows.Count>0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    id = int.Parse(row["Id"].ToString());
                }
            }
            return id;
        }
    }
}
