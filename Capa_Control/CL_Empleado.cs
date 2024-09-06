using Consumos_Sermopetrol.Capa_Control;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AppConsumo.Controlador
{
    internal class QueryEmpleado
    {
        public List<Empleado> Listar()
        {
            List<Empleado> lista = new List<Empleado>();
            using (SqlConnection oconexion = new SqlConnection(CL_Conexion.cadena))
            {
                try
                {
                    string query = "select * from Empleado";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Empleado
                            {
                                IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]),
                                NumeroDocumento = reader["NumeroDocumento"].ToString(),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                                ZonaDeTrabajo = reader["ZonaDeTrabajo"].ToString(),
                                NumeroConsumos = Convert.ToInt32(reader["NumeroConsumos"]),
                                Estado = Convert.ToBoolean(reader["Estado"]),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Empleado>();
                    // Manejo del error
                }
                oconexion.Close();
            }
            return lista;
        }

        public void InsertarEmpleado(string numeroDocumento, string nombreCompleto, string zonaDeTrabajo, int consumos, bool estado, DateTime hoy)
        {
            using (SqlConnection oconexion = new SqlConnection(CL_Conexion.cadena))
            {
                oconexion.Open();
                SqlCommand command = oconexion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "InsertarEmpleado";

                command.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                command.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                command.Parameters.AddWithValue("@ZonaDeTrabajo", zonaDeTrabajo);
                command.Parameters.AddWithValue("@NumeroConsumos", consumos);
                command.Parameters.AddWithValue("@Estado", estado);
                command.Parameters.AddWithValue("@FechaRegistro", hoy);
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarEmpleado(int idEmpleado, string numeroDocumento, string nombreCompleto, string zonaDeTrabajo)
        {
            using (SqlConnection oconexion = new SqlConnection(CL_Conexion.cadena))
            {
                using (SqlCommand command = new SqlCommand("ActualizarEmpleado", oconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    command.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                    command.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                    command.Parameters.AddWithValue("@ZonaDeTrabajo", zonaDeTrabajo);

                    oconexion.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void IncrementarConsumo(int idEmpleado)
        {
            using (SqlConnection oconexion = new SqlConnection(CL_Conexion.cadena))
            {
                using (SqlCommand command = new SqlCommand("IncrementarConsumo", oconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                    oconexion.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CambiarEstadoEmpleado(int idEmpleado, bool nuevoEstado)
        {
            using (SqlConnection oconexion = new SqlConnection(CL_Conexion.cadena))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CambiarEstadoEmpleado", oconexion))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                        command.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);

                        oconexion.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción aquí
                    Console.WriteLine("Error al cambiar el estado del empleado: " + ex.Message);
                    throw; // Opcional: relanzar la excepción para que sea manejada en un nivel superior
                }
            }
        }

        public void ActualizarEmpleadoCS(int idEmpleado, string numeroDocumento, string nombreCompleto, string zonaDeTrabajo, int numeroConsumos, bool estado, DateTime fechaRegistro)
        {
            using (SqlConnection oconexion = new SqlConnection(CL_Conexion.cadena))
            {
                using (SqlCommand command = new SqlCommand("ActualizarEmpleadoCS", oconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    command.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                    command.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                    command.Parameters.AddWithValue("@ZonaDeTrabajo", zonaDeTrabajo);
                    command.Parameters.AddWithValue("@NumeroConsumos", numeroConsumos);
                    command.Parameters.AddWithValue("@Estado", estado);
                    command.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);

                    oconexion.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    class ListarEmpleado
    {
        private QueryEmpleado _queryEmpleado = new QueryEmpleado();
        public List<Empleado> Listar()
        {
            return _queryEmpleado.Listar();
        }
    }
}
