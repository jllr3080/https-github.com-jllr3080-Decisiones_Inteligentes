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
    /// Dto de la orden de trabajo
    /// </summary>
    public class OrdenTrabajoDTOs
    {
        /// <summary>
        /// Cabecera de la orden de trabajo
        /// </summary>
        public ORDEN_TRABAJO OrdenTrabajo { get; set; }

        /// <summary>
        /// Detalle de la orden de  trabajo
        /// </summary>
        public List<DETALLE_ORDEN_TRABAJO> DetalleOrdenTrabajos { get; set; }
    }
}
