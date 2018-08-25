using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class MapperUsuario
    {
        Acceso ac = new Acceso();
        public int AgregarPermiso(int id, BE.Componente permiso)
        {
            ac.Abrir();
            int fa = 0;
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@idusu", id);
            parametros[1] = new SqlParameter("@codigo", permiso.Codigo);
            fa = ac.Escribir("ALTA_PERMISO", parametros);
            ac.Cerrar();
            return fa;
        }
        public int AltaUsuario(string email, string pass, string DVH)
        {
            ac.Abrir();
            int fa = 0;
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@email", email);
            parametros[1] = new SqlParameter("@pass", pass);
            parametros[2] = new SqlParameter("@DVH", DVH);
            fa = ac.Escribir("ALTA_USUARIO", parametros);
            ac.Cerrar();
            return fa;
        }

        public Boolean BuscarEmail(string email)
        {
            Boolean existe = false;
            DataTable tabla = ac.Leer("USUARIO_LISTAR", null);
            foreach (DataRow row in tabla.Rows)
            {
                if (row["Email"].ToString() == email)
                {
                    existe = true;
                }
            }
            return existe;
        }
        public BE.Usuario TraerUsuario(string email)
        {
            BE.Usuario usu = new BE.Usuario();
            DataTable tabla = ac.Leer("USUARIO_LISTAR", null);
            foreach(DataRow row in tabla.Rows)
            {
                if (row["Email"].ToString()==email)
                {
                    usu.Email = row["Email"].ToString();
                    usu.Id = int.Parse(row["Id"].ToString());
                    SqlParameter[] parametros = new SqlParameter[1];
                    parametros[0] = new SqlParameter("@id", usu.Id);
                    DataTable tablacomp = ac.Leer("LISTAR_PERMISOSUSUARIO", parametros);
                    foreach (DataRow rowcomp in tablacomp.Rows)
                    {
                        BE.Componente compo = new BE.Componente();
                        compo.Codigo = int.Parse(rowcomp["Codigo_Patente"].ToString());
                        usu.Permisos.Add(compo.Codigo, compo);
                    }
                }
            }
            return usu;
        }
        public Boolean VerificarPass(string email,string pass)
        {
            Boolean passok = false;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@email", email);
            DataTable tabla = ac.Leer("USUARIO_TRAERPASS", parametros);
            foreach (DataRow row in tabla.Rows)
            {
                if (row["Pass"].ToString() == pass)
                {
                    passok = true;
                }
            }
            return passok;
        }
    }
}
