using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Venta.Parametrizacion
{
    public class VentaComisionIndustrialesVistaModelo
    {
        /// <summary>
        /// VentaComisionIndustrialesId
        /// </summary>
        
        public int VentaComisionIndustrialesId { get; set; }

        /// <summary>
        /// VendedorId
        /// </summary>
        
        public int? VendedorId { get; set; }

        /// <summary>
        /// FechaComision
        /// </summary>
        
        public DateTime? FechaComision { get; set; }

        /// <summary>
        /// SucursalId
        /// </summary>
        
        public int? SucursalId { get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        
        public int? PuntoVentaId { get; set; }
    }
}