using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Venta.Parametrizacion;

namespace Web.DTOs.Venta
{
    public class VentaComisionIndustrialesVistaDTOs
    {
        /// <summary>
        /// Venta Comision Industriales
        /// </summary>
        
        public VentaComisionIndustrialesVistaModelo VentaComisionIndustriales { get; set; }

        /// <summary>
        /// Detalle Venta Comision Industriales
        /// </summary>
        
        public List<DetalleVentaComisionIndustrialesVistaModelo> DetalleVentaComisionIndustriales { get; set; }
    }
}