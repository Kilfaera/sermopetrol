using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumos_Sermopetrol.Capa_Control.Entidades
{
    public class Configuraciones
    {
        public int IdConfiguracion { get; set; }
        public string UbicacionImagenes { get; set; }
        public string UbicacionPDF { get; set; }
        public string UbicacionPlantilla { get; set; }
        public string UbicacionExcel { get; set; }
        public bool PermisoEliminacionRegistros { get; set; }
        public string UbicacionCopiasSeguridad { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
