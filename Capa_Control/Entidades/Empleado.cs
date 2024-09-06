using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumos_Sermopetrol.Capa_Control.Entidades
{
    internal class Empleado
    {
        
            public int IdEmpleado { get; set; }
            public string NumeroDocumento { get; set; }
            public string NombreCompleto { get; set; }
            public string ZonaDeTrabajo { get; set; }
            public int NumeroConsumos { get; set; }
            public bool Estado { get; set; }
            public DateTime FechaRegistro { get; set; }
        
    }
}
