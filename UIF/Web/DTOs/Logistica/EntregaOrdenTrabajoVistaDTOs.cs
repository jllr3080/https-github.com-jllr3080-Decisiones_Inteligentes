#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Logistica;
using Web.Models.Venta.Negocio;

#endregion
namespace Web.DTOs.Logistica
{
    public class EntregaOrdenTrabajoVistaDTOs
    {
        /// <summary>
        /// Entraga orden de  trabajo
        /// </summary>
        public EntregaOrdenTrabajoVistaModelo EntregaOrdenTrabajo { get; set; }

        /// <summary>
        /// Detalle  entrega orden de  trabajo
        /// </summary>
        public List<DetalleOrdenTrabajoVistaModelo> DetalleEntregaOrdenTrabajo { get; set; }
    }
}