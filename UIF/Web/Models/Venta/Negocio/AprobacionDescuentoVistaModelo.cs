using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Venta.Negocio
{
    public class AprobacionDescuentoVistaModelo
    {

        /// <summary>
        /// AprobacionDescuentoId
        /// </summary>
        
        public Int64 AprobacionDescuentoId { get; set; }

        /// <summary>
        /// OrdenTrabajoDescuento
        /// </summary>
        
        public OrdenTrabajoDescuentoVistaModelo OrdenTrabajoDescuento { get; set; }

        /// <summary>
        /// OrdenTrabajo
        /// </summary>
        
        public OrdenTrabajoVistaModelo OrdenTrabajo { get; set; }


        /// <summary>
        /// usuarioAprobacionId
        /// </summary>
        
        public int? usuarioAprobacionId { get; set; }

        /// <summary>
        /// FechaAprobacion
        /// </summary>
        
        public DateTime? FechaAprobacion { get; set; }

        /// <summary>
        /// ValorFranquiciaAprobacion
        /// </summary>
        
        public decimal? ValorFranquiciaAprobacion { get; set; }

        /// <summary>
        /// ValorMatrizAprobacion
        /// </summary>
        
        public decimal? ValorMatrizAprobacion { get; set; }
    }
}