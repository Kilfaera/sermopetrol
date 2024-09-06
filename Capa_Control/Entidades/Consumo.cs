using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumos_Sermopetrol.Capa_Control.Entidades
{
    internal class Consumo
    {
        public int IdConsumo { get; set; }
        public string NombreEmpleado { get; set; }
        public string DocumentoEmpleado { get; set; }
        public string ZonaTrabajoEmpleado { get; set; }
        public string TipoConsumo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Boolean FormaRegistro { get; set; }
    }
}
