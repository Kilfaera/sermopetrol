using Consumos_Sermopetrol.Capa_Control;
using Consumos_Sermopetrol.Capa_Control.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AppConsumo.Controlador
{
    internal class QueryConfiguracion
    {
        // Método para obtener la configuración
        public Configuraciones ObtenerConfiguracion()
        {
            Configuraciones configuracion = null;
            using (SqlConnection oconexion = new SqlConnection(CL_Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM Configuraciones WHERE IdConfiguracion = 1";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            configuracion = new Configuraciones
                            {
                                IdConfiguracion = Convert.ToInt32(reader["IdConfiguracion"]),
                                UbicacionImagenes = reader["UbicacionImagenes"].ToString(),
                                UbicacionPDF = reader["UbicacionPDF"].ToString(),
                                UbicacionPlantilla = reader["UbicacionPlantilla"].ToString(),
                                UbicacionExcel = reader["UbicacionExcel"].ToString(),
                                PermisoEliminacionRegistros = Convert.ToBoolean(reader["PermisoEliminacionRegistros"]),
                                UbicacionCopiasSeguridad = reader["UbicacionCopiasSeguridad"].ToString(),
                                FechaModificacion = Convert.ToDateTime(reader["FechaModificacion"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    configuracion = null;
                    // Manejo del error
                    Console.WriteLine("Error al obtener la configuración: " + ex.Message);
                }
                oconexion.Close();
            }
            return configuracion;
        }

        // Método para actualizar la configuración
        public void ActualizarConfiguracion(string ubicacionImagenes, string ubicacionPDF, string ubicacionPlantilla, string ubicacionExcel, bool permisoEliminacionRegistros, string ubicacionCopiasSeguridad)
        {
            using (SqlConnection oconexion = new SqlConnection(CL_Conexion.cadena))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("ActualizarConfiguraciones", oconexion))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_UbicacionImagenes", ubicacionImagenes);
                        command.Parameters.AddWithValue("@p_UbicacionPDF", ubicacionPDF);
                        command.Parameters.AddWithValue("@p_UbicacionPlantilla", ubicacionPlantilla);
                        command.Parameters.AddWithValue("@p_UbicacionExcel", ubicacionExcel);
                        command.Parameters.AddWithValue("@p_PermisoEliminacionRegistros", permisoEliminacionRegistros);
                        command.Parameters.AddWithValue("@p_UbicacionCopiasSeguridad", ubicacionCopiasSeguridad);

                        oconexion.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Manejo del error
                    Console.WriteLine("Error al actualizar la configuración: " + ex.Message);
                }
                oconexion.Close();
            }
        }
    }
    }
