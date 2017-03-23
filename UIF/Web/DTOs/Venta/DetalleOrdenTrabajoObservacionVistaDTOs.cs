#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Venta.Negocio;

#endregion

namespace Web.DTOs.Venta
{
    public class DetalleOrdenTrabajoObservacionVistaDTOs
    {
        /// <summary>
        /// Nombre Usuario
        /// </summary>
        
        public string NombreUsuario { get; set; }


        /// <summary>
        /// Observaciones d elas prendas    
        /// </summary>
        
        public DetalleOrdenTrabajoObservacionVistaModelo DetalleOrdenTrabajoObservacion { get; set; }
    }
}