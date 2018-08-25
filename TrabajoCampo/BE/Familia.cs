using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Familia : Componente
    {
        private List<Componente> permisos;

        public List<Componente> Permisos
        {
            get { return permisos; }
            set { permisos = value; }
        }

    }
}