#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.General;

#endregion
namespace Web.Models.FlujoProceso
{
    public class HistorialProcesoVistaModelo
    {
        /// <summary>
        /// Id 
        /// </summary>
        
        public int HistorialProcesoId { get; set; }

        /// <summary>
        /// OrdenTrabajoId
        /// </summary>
        
        public Int64? OrdenTrabajoId { get; set; }

        /// <summary>
        /// EtapaProceso
        /// </summary>
        
        public EtapaProcesoVistaModelo EtapaProceso { get; set; }

        /// <summary>
        /// FechaRegistro
        /// </summary>
        
        public DateTime? FechaRegistro { get; set; }


        /// <summary>
        /// FechaInicio
        /// </summary>
        
        public DateTime? FechaInicio { get; set; }

        /// <summary>
        /// FechaFin
        /// </summary>
        
        public DateTime? FechaFin { get; set; }

        /// <summary>
        /// NumeroOrden
        /// </summary>
        
        public string NumeroOrden { get; set; }

        /// <summary>
        /// Texto
        /// </summary>
        public string Texto { get; set; }
    }
}
