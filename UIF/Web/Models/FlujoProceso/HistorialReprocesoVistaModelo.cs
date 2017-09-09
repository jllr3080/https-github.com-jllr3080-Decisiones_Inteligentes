#region  using
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
#endregion
namespace Web.Models.FlujoProceso
{

    public class HistorialReprocesoVistaModelo
    {
        /// <summary>
        /// HistorialReprocesoId
        /// </summary>

        public Int64 HistorialReprocesoId { get; set; }

        /// <summary>
        /// HistorialProceso
        /// </summary>
      
        public HistorialProcesoVistaModelo HistorialProceso { get; set; }


        /// <summary>
        /// DetallePrendaOrdenTrabajoId
        /// </summary>
    
        public Int64 DetallePrendaOrdenTrabajoId { get; set; }



        /// <summary>
        /// FechaEstimadaEntrega
        /// </summary>
        
        public DateTime? FechaEstimadaEntrega { get; set; }
    }
}