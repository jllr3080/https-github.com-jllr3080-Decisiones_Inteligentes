#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.Logistica.Servicio.Modelo
{
    /// <summary>
    /// Detalle de la entrega d ela orden de trabajo
    /// </summary>
    [DataContract]
    public class DetalleEntregaOrdenTrabajoModelo
    {

        /// <summary>
        /// DetalleEntregaOrdenTrabajoId
        /// </summary>
        [DataMember]
        public int DetalleEntregaOrdenTrabajoId { get; set; }

        /// <summary>
        ///DetalleOrdenTrabajoId
        /// </summary>
        [DataMember]
        public int? DetalleOrdenTrabajoId { get; set; }

        /// <summary>
        ///DetalleOrdenTrabajoId
        /// </summary>
        [DataMember]
        public int? EntregaTrabajoId { get; set; }

    }
}