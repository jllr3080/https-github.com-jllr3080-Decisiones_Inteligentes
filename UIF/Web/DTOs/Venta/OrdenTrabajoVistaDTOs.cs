#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Venta.Negocio;

#endregion
namespace Web.DTOs.Venta
{
    public class OrdenTrabajoVistaDTOs
    {

        /// <summary>
        /// Orden de  trabajo
        /// </summary>
        
        public OrdenTrabajoVistaModelo OrdenTrabajo { get; set; }

        /// <summary>
        /// Detalle de la Orden de  trabajo
        /// </summary>
        
        public List<DetalleOrdenTrabajoVistaModelo> DetalleOrdenTrabajo { get; set; }
    }
}