#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Logistica
{
    public class DetalleEntregaOrdenTrabajoVistaModelo
    {
        /// <summary>
        /// DetalleEntregaOrdenTrabajoId
        /// </summary>
        
        public int DetalleEntregaOrdenTrabajoId { get; set; }

        /// <summary>
        ///DetalleOrdenTrabajoId
        /// </summary>
        
        public int? DetalleOrdenTrabajoId { get; set; }

        /// <summary>
        ///DetalleOrdenTrabajoId
        /// </summary>
        
        public int? EntregaTrabajoId { get; set; }
    }
}