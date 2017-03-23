#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Venta.Proveedor.DTOs
{
    /// <summary>
    /// Orden de trabajo descuento
    /// </summary>
    public class OrdenTrabajoDescuentoDTO
    {
        /// <summary>
        /// Nombre del punto de venta
        /// </summary>
        public string NombrePuntoVenta { get; set; }

        /// <summary>
        ///OrdenTrabajoDescuento
        /// </summary>
        public ORDEN_TRABAJO_DESCUENTO OrdenTrabajoDescuento{ get; set; }
    }
}
