using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class data
    {
        private string cnn = "Data Source = SQL8002.site4now.net; Initial Catalog = db_a8ea57_fernan2; User Id = db_a8ea57_fernan2_admin; Password=#Fernando1";
        public DataTable queryData(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                conexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                conexion.Close();
                reader.Close();
            }
            return dt;
        }
        public bool execData(string query)
        {
            bool estado = false;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                conexion.Open();
                estado = command.ExecuteNonQuery() == 1 ? true : false;
                conexion.Close();
            }

            return estado;
        }


        public DataTable listadoSP(string NombreSP, List<Parametros> lst)
        {
            DataSet dt = new DataSet();
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(NombreSP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);
                    }
                }
                da.Fill(dt);
                conexion.Close();
            }

            return dt.Tables[0];
        }
        public string ejecutarSP(String NombreSP, List<Parametros> lst)
        {
            string mensaje = "";
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(NombreSP, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {

                    for (int i = 0; i < lst.Count; i++)
                    {

                        if (lst[i].Direccion == ParameterDirection.Input)
                            cmd.Parameters.AddWithValue(lst[i].Nombre, lst[i].Valor);

                        if (lst[i].Direccion == ParameterDirection.Output)
                            cmd.Parameters.Add(lst[i].Nombre, lst[i].TipoDato, lst[i].Tamaño).Direction = ParameterDirection.Output;
                    }
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                            mensaje = cmd.Parameters[i].Value.ToString();
                    }
                }
            }

            return mensaje;
        }

    }
}
