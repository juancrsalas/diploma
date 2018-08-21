using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MapperDigito
    {
        Acceso ac = new Acceso();
        public List<string> TraerDigitosUsuario()
        {
            List<string> digitos = new List<string>();
            DataTable tabla = ac.Leer("USUARIO_LISTARDIGITOS", null);
            foreach (DataRow row in tabla.Rows)
            {
                digitos.Add(row["DVH"].ToString());
            }
            return digitos;
        }
        public string TraerDigito()
        {
            string digito=null;
            DataTable tabla = ac.Leer("DIGITO_LISTAR", null);
            foreach(DataRow row in tabla.Rows)
            {
                digito = row["DigitoVerificador"].ToString();
            }
            return digito;
        }
        public int ActualizarDigito(string dig)
        {
            ac.Abrir();
            int fa = 0;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@DV", dig);
            fa = ac.Escribir("DIGITO_ACTUALIZAR", parametros);
            ac.Cerrar();
            return fa;
        }
    }

}
