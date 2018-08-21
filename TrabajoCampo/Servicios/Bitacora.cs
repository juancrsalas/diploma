using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Bitacora
    {
        private string mensaje;

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private TipoEvento tipo;

        public TipoEvento Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private BE.Usuario usuario;

        public BE.Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

    }
}
