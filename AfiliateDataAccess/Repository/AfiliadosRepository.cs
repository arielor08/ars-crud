using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AfiliateDataAccess.Models;

namespace AfiliateDataAccess.Repository
{
    public class AfiliadosRepository
    {
        public List<Afiliados> GetAfiliados(string conn)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            var afiliados = new List<Afiliados>();

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SEL_GetAfiliados";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    afiliados.Add(new Afiliados
                    {
                        Id = (int) reader["Id"],
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        FechaNacimiento = (DateTime) reader["Fecha_Nacimiento"],
                        Sexo = (string) reader["Sexo"],
                        Cedula = reader["Cedula"].ToString(),
                        NSS = reader["Numero_Seguridad_Social"].ToString(),
                        FechaRegistro = (DateTime) reader["Fecha_Registro"],
                        MontoConsumido = (int) reader["Monto_Consumido"],
                        IdEstatus = (int) reader["Id_Estatus"],
                        IdPlan = (int) reader["Id_Plan"],
                        Estatus = reader["Estatus"].ToString(),
                        MontoRestante = (int)reader["Monto_Cobertura"] - (int)reader["Monto_Consumido"] ,
                        

                    }
                    );   
                }

                return afiliados;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Afiliados AddAfiliados(string conn,Afiliados afiliado)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand();
            var afiliados = new Afiliados();

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ADD_AddAfiliados";

                command.Parameters.AddWithValue("@Nombres", afiliado.Nombres);
                command.Parameters.AddWithValue("@Apellidos", afiliado.Apellidos);
                command.Parameters.AddWithValue("@Fecha_Nacimiento", afiliado.FechaNacimiento);
                command.Parameters.AddWithValue("@Sexo", afiliado.Sexo);
                command.Parameters.AddWithValue("@Cedula", afiliado.Cedula);
                command.Parameters.AddWithValue("@Numero_Seguridad_Social", afiliado.NSS);
                command.Parameters.AddWithValue("@Id_Estatus", afiliado.IdEstatus);
                command.Parameters.AddWithValue("@Id_Plan", afiliado.IdPlan);

                
                if((int)command.ExecuteNonQuery() == 0)
                {
                    return null; 
                }

                return afiliados;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Afiliados UpdateAfiliados(string conn, Afiliados afiliado)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand();
            var afiliados = new Afiliados();

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UPD_UpdateAfiliado";

                command.Parameters.AddWithValue("@Nombres", afiliado.Nombres);
                command.Parameters.AddWithValue("@Apellidos", afiliado.Apellidos);
                command.Parameters.AddWithValue("@Fecha_Nacimiento", afiliado.FechaNacimiento);
                command.Parameters.AddWithValue("@Sexo", afiliado.Sexo);
                command.Parameters.AddWithValue("@Cedula", afiliado.Cedula);
                command.Parameters.AddWithValue("@Numero_Seguridad_Social", afiliado.NSS);
                command.Parameters.AddWithValue("@FechaRegistro", afiliado.FechaRegistro);
                command.Parameters.AddWithValue("@MontoConsumido", afiliado.MontoConsumido);
                command.Parameters.AddWithValue("@Id_Estatus", afiliado.IdEstatus);
                command.Parameters.AddWithValue("@Id_Plan", afiliado.IdPlan);
                command.Parameters.AddWithValue("@ID", afiliado.Id);

                if (command.ExecuteNonQuery() == 0)
                {
                    return null;
                }

                return afiliados;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Afiliados InactivarAfiliado(string conn, Afiliados afiliado)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand();
            var afiliados = new Afiliados();

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "Inactivar_Afiliado";

                command.Parameters.AddWithValue("@ID", afiliado.Id);

                if (command.ExecuteNonQuery() == 0)
                {
                    return null;
                }

                return afiliados;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Afiliados GetAfiliadosById(string conn,int Id)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            var afiliados = new Afiliados();

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SEL_GETBYID";
                command.Parameters.AddWithValue("@ID",Id);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    afiliados = new Afiliados
                    {
                        Id = (int)reader["Id"],
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        FechaNacimiento = (DateTime)reader["Fecha_Nacimiento"],
                        Sexo = (string)reader["Sexo"],
                        Cedula = reader["Cedula"].ToString(),
                        NSS = reader["Numero_Seguridad_Social"].ToString(),
                        FechaRegistro = (DateTime)reader["Fecha_Registro"],
                        MontoConsumido = (int)reader["Monto_Consumido"],
                        IdEstatus = (int)reader["Id_Estatus"],
                        IdPlan = (int)reader["Id_Plan"]
                    };
                }

                return afiliados;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Afiliados UpdateMontoConsumido(string conn, int Id,int monto)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlCommand command = new SqlCommand();
            var afiliados = new Afiliados();

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "Actualizar_Monto";

                command.Parameters.AddWithValue("@ID", Id);
                command.Parameters.AddWithValue("@MontoConsumido", monto);

                if (command.ExecuteNonQuery() == 0)
                {
                    return null;
                }

                return afiliados;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
