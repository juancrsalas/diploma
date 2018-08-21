using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class DigitoException:Exception
    {
        public DigitoException(DigitoResult res)
        {
            resultado = res;
        }
        public DigitoResult resultado;
    }
}
