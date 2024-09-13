using Consumos_Sermopetrol.Capa_Control.Entidades;
using Consumos_Sermopetrol.Capa_Control;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace AppConsumo.Controlador
{
    internal class QueryEmpleado
    {
        public List<Empleado> Listar()
        {
            List<Empleado> lista = new List<Empleado>();
            using (MySqlConnection oconexion = new MySqlConnection(CL_Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM Empleado";
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
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
            using (MySqlConnection oconexion = new MySqlConnection(CL_Conexion.cadena))
            {
                oconexion.Open();
                MySqlCommand command = oconexion.CreateCommand();
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
            using (MySqlConnection oconexion = new MySqlConnection(CL_Conexion.cadena))
            {
                using (MySqlCommand command = new MySqlCommand("ActualizarEmpleado", oconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_IdEmpleado", idEmpleado);
                    command.Parameters.AddWithValue("@p_NumeroDocumento", numeroDocumento);
                    command.Parameters.AddWithValue("@p_NombreCompleto", nombreCompleto);
                    command.Parameters.AddWithValue("@p_ZonaDeTrabajo", zonaDeTrabajo);

                    oconexion.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void IncrementarConsumo(int idEmpleado)
        {
            using (MySqlConnection oconexion = new MySqlConnection(CL_Conexion.cadena))
            {
                using (MySqlCommand command = new MySqlCommand("IncrementarConsumo", oconexion))
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
            using (MySqlConnection oconexion = new MySqlConnection(CL_Conexion.cadena))
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand("CambiarEstadoEmpleado", oconexion))
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
                    throw;
                }
            }
        }

        public void ActualizarEmpleadoCS(int idEmpleado, string numeroDocumento, string nombreCompleto, string zonaDeTrabajo, int numeroConsumos, bool estado, DateTime fechaRegistro)
        {
            using (MySqlConnection oconexion = new MySqlConnection(CL_Conexion.cadena))
            {
                using (MySqlCommand command = new MySqlCommand("ActualizarEmpleadoCS", oconexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_IdEmpleado", idEmpleado);
                    command.Parameters.AddWithValue("@p_NumeroDocumento", numeroDocumento);
                    command.Parameters.AddWithValue("@p_NombreCompleto", nombreCompleto);
                    command.Parameters.AddWithValue("@p_ZonaDeTrabajo", zonaDeTrabajo);
                    command.Parameters.AddWithValue("@p_NumeroConsumos", numeroConsumos);
                    command.Parameters.AddWithValue("@p_Estado", estado);
                    command.Parameters.AddWithValue("@p_FechaRegistro", fechaRegistro);

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
