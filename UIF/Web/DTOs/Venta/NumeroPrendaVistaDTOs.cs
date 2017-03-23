#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.DTOs.Venta
{
    public class NumeroPrendaVistaDTOs
    {
        /// <summary>
        /// Nombre de Producto
        /// </summary>
        public string NombreProducto { get; set; }

        /// <summary>
        /// Cantidad
        /// </summary>
        public int? Cantidad { get; set; }
    }
}