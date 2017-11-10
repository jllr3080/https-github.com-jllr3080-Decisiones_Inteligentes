
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Inventario
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
