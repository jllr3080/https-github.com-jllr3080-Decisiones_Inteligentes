#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace JLLR.Core.Venta.Proveedor.DTOs
{
    /// <summary>
    /// Numero de prendas
    /// </summary>
    public class NumeroPrendaDTOs
    {

        /// <summary>
        /// Nombre de Producto
        /// </summary>
        public string NombreProducto { get; set; }

        /// <summary>
        /// Cantidad
        /// </summary>
        public int? Cantidad{ get; set; }
    }
}
