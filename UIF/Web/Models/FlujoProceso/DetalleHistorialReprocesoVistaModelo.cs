using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Web.Models.General;

namespace Web.Models.FlujoProceso
{
    public class DetalleHistorialReprocesoVistaModelo
    {

        /// <summary>
        /// Id del detalle de  reproceso
        /// </summary>
        
        public int DetalleHistorialReprocesoId { get; set; }

        /// <summary>
        /// HistorialReproceso
        /// </summary>
        
        public HistorialReprocesoVistaModelo HistorialReproceso { get; set; }


        /// <summary>
        /// TipoReproceso
        /// </summary>
        
        public TipoReprocesoVistaModelo TipoReproceso { get; set; }

        /// <summary>
        /// Motivo
        /// </summary>
        
        public string Motivo { get; set; }
    }
}