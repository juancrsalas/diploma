using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bitacora
    {
        DAL.MapperBitacora mapper = new DAL.MapperBitacora();
        public void EscribirBitacora(string mensaje,Servicios.TipoEvento tipo,BE.Usuario usu)
        {
            Servicios.Bitacora bit = new Servicios.Bitacora();
            bit.Usuario = usu;
            bit.Tipo = tipo;
            bit.Mensaje = mensaje;
            bit.Fecha = DateTime.Now;
            mapper.NuevaBitacora(bit);
        }
    }
}
