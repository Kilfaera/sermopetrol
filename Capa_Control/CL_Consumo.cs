using Consumos_Sermopetrol.Capa_Control;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using MySql.Data.MySqlClient;  // Usar la librería de MySQL
using System;
using System.Collections.Generic;
using System.Data;

namespace AppConsumo.Controlador
{
    class QueryConsumo
    {
        public List<Consumo> Listar()
        {
            List<Consumo> lista = new List<Consumo>();
            using (MySqlConnection oconexion = new MySqlConnection(CL_Conexion.cadena))
            {
                try
                {
                    string query = "CALL ObtenerConsumo();";  // Usamos CALL para procedimientos en MySQL
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Consumo
                            {
                                IdConsumo = Convert.ToInt32(reader["IdConsumo"]),
                                NombreEmpleado = reader["NombreEmpleado"].ToString(),
                                DocumentoEmpleado = reader["DocumentoEmpleado"].ToString(),
                                ZonaTrabajoEmpleado = reader["ZonaTrabajoEmpleado"].ToString(),
                                TipoConsumo = reader["TipoConsumo"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                                FormaRegistro = Convert.ToBoolean(reader["Registro"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Consumo>();
                    // Manejo de excepciones
                }
                finally
                {
                    oconexion.Close();
                }
            }
            return lista;
        }

        public void InsertarConsumo(int idempleado, string tipoConsumo, bool registro)
        {
            using (MySqlConnection oconexion = new MySqlConnection( CL_Conexion.cadena))
            {
                try
                {
                    oconexion.Open();
                    MySqlCommand command = oconexion.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertarConsumo";
                    command.Parameters.AddWithValue("@IdEmpleado", idempleado);
                    command.Parameters.AddWithValue("@TipoConsumo", tipoConsumo);
                    command.Parameters.AddWithValue("@Registro", registro); // Adaptación para columna BIT en MySQL
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                }
                finally
                {
                    oconexion.Close();
                }
            }
        }

        public List<Consumo_CS> ListarCs()
        {
            List<Consumo_CS> lista = new List<Consumo_CS>();
            using (MySqlConnection oconexion = new MySqlConnection(CL_Conexion.cadena))
            {
                try
                {
                    string query = "CALL ObtenerConsumoCS();";  // Usamos CALL para procedimientos en MySQL
                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Consumo_CS
                            {
                                IdConsumo = Convert.ToInt32(reader["IdConsumo"]),
                                IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]),
                                TipoConsumo = reader["TipoConsumo"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                                FormaRegistro = Convert.ToBoolean(reader["Registro"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Consumo_CS>();
                    // Manejo de excepciones
                }
                finally
                {
                    oconexion.Close();
                }
            }
            return lista;
        }

        public void AgregarConsumoCS(int idempleado, string tipoConsumo, DateTime fechaRegistro, bool registro)
        {
            using (MySqlConnection oconexion = new MySqlConnection(CL_Conexion.cadena))
            {
                try
                {
                    oconexion.Open();
                    MySqlCommand command = oconexion.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AgregarConsumoCS";
                    command.Parameters.AddWithValue("@IdEmpleado", idempleado);
                    command.Parameters.AddWithValue("@TipoConsumo", tipoConsumo);
                    command.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);
                    command.Parameters.AddWithValue("@Registro", registro ? 1 : 0); // BIT en MySQL
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                }
                finally
                {
                    oconexion.Close();
                }
            }
        }
    }

    class ListarConsumoCS
    {
        private QueryConsumo _queryConsumoCS = new QueryConsumo();
        public List<Consumo_CS> Listar()
        {
            return _queryConsumoCS.ListarCs();
        }
    }

    class ListarConsumo
    {
        private QueryConsumo _queryConsumo = new QueryConsumo();
        public List<Consumo> Listar()
        {
            return _queryConsumo.Listar();
        }
    }
}
