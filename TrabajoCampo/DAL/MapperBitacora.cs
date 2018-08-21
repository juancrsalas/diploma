using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class MapperBitacora
    {
        Acceso ac = new Acceso();
        public int NuevaBitacora(Servicios.Bitacora bit)
        {
            ac.Abrir();
            int fa = 0;
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@email", bit.Usuario.Email);
            parametros[1] = new SqlParameter("@fec", bit.Fecha);
            parametros[2] = new SqlParameter("@evento", bit.Tipo.ToString());
            parametros[3] = new SqlParameter("@mensaje", bit.Mensaje);
            fa = ac.Escribir("BITACORA_ALTA", parametros);
            ac.Cerrar();
            return fa;
        }
    }
}
