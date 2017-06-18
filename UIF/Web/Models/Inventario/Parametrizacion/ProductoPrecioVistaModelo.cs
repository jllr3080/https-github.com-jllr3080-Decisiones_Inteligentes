#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Inventario.Parametrizacion
{
    public class ProductoPrecioVistaModelo
    {
        /// <summary>
        /// ProductoPrecioId
        /// </summary>
        
        public int ProductoPrecioId { get; set; }

        /// <summary>
        /// Producto
        /// </summary>
        
        public ProductoVistaModelo Producto { get; set; }

        /// <summary>
        /// ProductoTalla
        /// </summary>
        
        public ProductoTallaVistaModelo ProductoTalla { get; set; }

        /// <summary>
        /// Precio
        /// </summary>
        
        public decimal? Precio { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        
        public Boolean? EstaHabilitado { get; set; }

        /// <summary>
        /// Modificable
        /// </summary>
        
        public Boolean? Modificable { get; set; }

      
    }
}