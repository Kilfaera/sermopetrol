using System;

namespace Consumos_Sermopetrol.Capa_Control.Entidades
{
    internal class Consumo_CS
    {
        public int IdConsumo { get; set; }
        public int IdEmpleado { get; set; }
        public string TipoConsumo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Boolean FormaRegistro {  get; set; }
    }
}
