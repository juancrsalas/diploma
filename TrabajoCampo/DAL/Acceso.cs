using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Acceso
    {
        SqlConnection con = new SqlConnection(@"Data Source= .\MSSQLSERVER2 ; Initial Catalog=TrabajoCampo ; Integrated Security= SSPI");
        public void Abrir()
        {
            con.Open();
        }
        public void Cerrar()
        {
            con.Close();
        }
        public DataTable Leer(string sp, SqlParameter[] parametros)
        {
            con.Open();
            DataTable tabla = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = CrearComando(sp, parametros);
            adaptador.Fill(tabla);
            con.Close();
            return tabla;
        }

        public SqlCommand CrearComando(string sp, SqlParameter[] parametros)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            if (parametros!=null)
            {
                cmd.Parameters.AddRange(parametros);
            }
            return cmd;
        }

        public int Escribir(string sp, SqlParameter[] parametros)
        {
            int fa = 0;
            SqlCommand cmd = CrearComando(sp, parametros);
            try
            {
                fa = cmd.ExecuteNonQuery();
            }
            catch
            {
                fa = -1;
            }
            cmd.Parameters.Clear();
            return fa;
        }


    }
}
