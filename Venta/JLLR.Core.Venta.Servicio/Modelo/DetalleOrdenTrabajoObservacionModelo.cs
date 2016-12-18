#region  using

using System;
using System.Runtime.Serialization;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Individuo.Servicio.Modelo;
using JLLR.Core.Seguridad.Servicio.Modelo;

#endregion
namespace JLLR.Core.Venta.Servicio.Modelo
{
    /// <summary>
    /// Detalle de la orden de  trabajo las observaciones
    /// </summary>
    public class DetalleOrdenTrabajoObservacionModelo
    {
        /// <summary>
        /// Id 
        /// </summary>
        [DataMember]
        public int DetalleOrdenTrabajoObservacionId { get; set; }

        /// <summary>
        /// DetalleOrdenTrabajoId 
        /// </summary>
        [DataMember]
        public int? DetalleOrdenTrabajoId { get; set; }

        /// <summary>
        /// Observacion 
        /// </summary>
        [DataMember]
        public string Observacion{ get; set; }

        /// <summary>
        /// FechaCreacionObservacion 
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacionObservacion { get; set; }

        /// <summary>
        /// UsuarioId 
        /// </summary>
        [DataMember]
        public int? UsuarioId { get; set; }
    }
}