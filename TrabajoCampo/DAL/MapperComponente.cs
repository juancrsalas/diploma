using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class MapperComponente
    {
        Acceso ac = new Acceso();
        public List<BE.Familia> TraerFamilias()
        {
            List<BE.Familia> familias = new List<BE.Familia>();
            DataTable tabla = ac.Leer("PATENTE_LISTARFAMILIAS", null);
            foreach (DataRow row in tabla.Rows)
            {
                BE.Familia fam = new BE.Familia();
                fam.Codigo = int.Parse(row["Codigo"].ToString());
                fam.Descripcion = row["Descripcion"].ToString();
                List<BE.Componente> comp = new List<BE.Componente>();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@padre", fam.Codigo);
                DataTable tablacomp = ac.Leer("PATENTE_LISTARHIJOS", parametros);
                foreach (DataRow rowcomp in tablacomp.Rows)
                {
                    BE.Componente compo = new BE.Componente();
                    compo.Codigo = int.Parse(rowcomp["Codigo"].ToString());
                    compo.Descripcion = rowcomp["Descripcion"].ToString();
                    comp.Add(compo);
                }
                fam.Permisos = comp;
                familias.Add(fam);
            }
            return familias;
        }
        public List<BE.Patente> TraerPatentes()
        {
            List<BE.Patente> patentes = new List<BE.Patente>();
            DataTable tabla = ac.Leer("PATENTE_LISTAR", null);
            foreach (DataRow row in tabla.Rows)
            {
                BE.Patente pat = new BE.Patente();
                pat.Codigo = int.Parse(row["Codigo"].ToString());
                pat.Descripcion = row["Descripcion"].ToString();
                patentes.Add(pat);
            }
            return patentes;
        }
    }
}
