#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Inventario;
#endregion

namespace Web.Models.Venta.Parametrizacion
{
    public class DetalleVentaComisionIndustrialesVistaModelo
    {
        /// <summary>
        /// DetalleVentaComisionIndustrialesId 
        /// </summary>
        
        public int DetalleVentaComisionIndustrialesId { get; set; }

        /// <summary>
        /// VentaComisionIndustriales 
        /// </summary>
        
        public VentaComisionIndustrialesVistaModelo VentaComisionIndustriales { get; set; }

        /// <summary>
        /// ProductoPrecio 
        /// </summary>
        
        public ProductoPrecioVistaModelo ProductoPrecio { get; set; }

        /// <summary>
        /// EstaHabilitado 
        /// </summary>
        
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        /// FechaCreacion 
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// Porcentaje 
        /// </summary>
        
        public decimal? Porcentaje { get; set; }

        /// <summary>
        /// UsuarioId 
        /// </summary>
        
        public int? UsuarioId { get; set; }
    }
}