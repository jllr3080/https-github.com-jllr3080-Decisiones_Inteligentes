#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Venta.Negocio
{
    public class DetalleOrdenTrabajoObservacionVistaModelo
    {

        /// <summary>
        /// Id 
        /// </summary>
       
        public int DetalleOrdenTrabajoObservacionId { get; set; }

        /// <summary>
        /// DetalleOrdenTrabajoId 
        /// </summary>
     
        public int? DetalleOrdenTrabajoId { get; set; }

        /// <summary>
        /// Observacion 
        /// </summary>
       
        public string Observacion { get; set; }

        /// <summary>
        /// FechaCreacionObservacion 
        /// </summary>
       
        public DateTime? FechaCreacionObservacion { get; set; }

        /// <summary>
        /// UsuarioId 
        /// </summary>
       
        public int? UsuarioId { get; set; }
    }
}