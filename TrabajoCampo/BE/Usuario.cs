using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BE
{
    public class Usuario
    {
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private Hashtable permisos= new Hashtable();

        public Hashtable Permisos
        {
            get { return permisos; }
            set { permisos = value; }
        }

    }
}
