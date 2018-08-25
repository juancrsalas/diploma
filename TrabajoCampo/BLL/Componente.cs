using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Componente
    {
        DAL.MapperComponente mapper = new DAL.MapperComponente();
        public List<BE.Familia> traerFamilias()
        {
            return mapper.TraerFamilias();
        }
        public List<BE.Patente> traerPatentes()
        {
            return mapper.TraerPatentes();
        }
    }
}
