using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Componente
    {
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }


    }
}