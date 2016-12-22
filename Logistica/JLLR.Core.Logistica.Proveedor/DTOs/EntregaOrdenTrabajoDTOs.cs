#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Logistica.Proveedor.DTOs
{
    
    /// <summary>
    /// Entrega  orden de trabajo DTO
    /// </summary>
    public class EntregaOrdenTrabajoDTOs
    {
        /// <summary>
        /// Entraga orden de  trabajo
        /// </summary>
        public ENTREGA_ORDEN_TRABAJO EntregaOrdenTrabajo { get; set; }

        /// <summary>
        /// Detalle  entrega orden de  trabajo
        /// </summary>
        public List<DETALLE_ENTREGA_ORDEN_TRABAJO> DetalleEntregaOrdenTrabajo { get; set; }
    }
}
