using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DigitoVerificador
    {
        DAL.MapperDigito mapper = new DAL.MapperDigito();
        public Servicios.DigitoResult VerificarDigito()
        {
            Servicios.DigitoResult digitook;
            digitook = CompararDigitos(CalcularDigito());
            return digitook;
        }
        private string CalcularDigito()
        {
            List<string> digitos = mapper.TraerDigitosUsuario();
            string sumadig = null;
            foreach (string dig in digitos)
            {
                sumadig += dig;
            }
            return Servicios.Encriptador.Hashear(sumadig);
        }
        private Servicios.DigitoResult CompararDigitos(string digCalc)
        {
            Servicios.DigitoResult resu;
            string dig = mapper.TraerDigito();
            if (digCalc==dig)
            {
                resu = Servicios.DigitoResult.DigitoCorrecto;
            }
            else
            {
                throw new Servicios.DigitoException(Servicios.DigitoResult.DigitoIncorrecto);
            }
            return resu;
        }
        public void ActualizarDigito()
        {
            mapper.ActualizarDigito(CalcularDigito());
        }
    }
}
