#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.FlujoProceso;
using Web.Models.General;

#endregion

namespace Web.DTOs.FlujoProceso
{
    public class DetalleHistorialReprocesoVistaDTOs
    {
        ///// <summary>
        ///// Historial  reproceso
        ///// </summary>

        //public HistorialReprocesoVistaModelo HistorialReproceso { get; set; }

        ///// <summary>
        ///// DetalleHistorialReproceso
        ///// </summary>

        //public DetalleHistorialReprocesoVistaModelo DetalleHistorialReproceso { get; set; }

        ///// <summary>
        ///// TipoReproceso
        ///// </summary>

        //public TipoReprocesoVistaModelo TipoReproceso { get; set; }

        /// <summary>
        /// TipoMotivoProceso
        /// </summary>
        public string TipoMotivoProceso { get; set; }

        /// <summary>
        /// Motivo
        /// </summary>
        public string Motivo { get; set; }
    }
}