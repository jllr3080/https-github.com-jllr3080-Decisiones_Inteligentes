#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.FlujoProceso;

#endregion

namespace Web.DTOs.FlujoProceso
{

    /// <summary>
    /// DTO que contiene  el  historial de  reclamo
    /// </summary>
    public class HistorialReprocesoVistaDTOs
    {

        /// <summary>
        /// HistorialProceso
        /// </summary>
        public HistorialProcesoVistaModelo HistorialProceso { get; set; }


        /// <summary>
        /// Graba los  reprocesos
        /// </summary>
        public List<HistorialReprocesoVistaModelo> HistorialReprocesos { get; set; }
    }
}