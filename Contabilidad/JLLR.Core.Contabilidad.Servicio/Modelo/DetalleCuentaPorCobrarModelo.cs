#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.Contabilidad.Servicio.Modelo
{
    /// <summary>
    /// Detalle de la cuenta por cobrar
    /// </summary>
    [DataContract]
    public class DetalleCuentaPorCobrarModelo
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public Int64 DetalleCuentaPorCobrarId { get; set; }

        /// <summary>
        /// CuentaPorCobrarId
        /// </summary>
        [DataMember]
        public Int64? CuentaPorCobrarId { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion{ get; set; }

        /// <summary>
        /// EstadoPagoId
        /// </summary>
        [DataMember]
        public int? EstadoPagoId{ get; set; }

        /// <summary>
        /// UsuarioId
        /// </summary>
        [DataMember]
        public int? UsuarioId { get; set; }

        /// <summary>
        /// FechaCancelacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCancelacion{ get; set; }

        /// <summary>
        /// NumeroFactura
        /// </summary>
        [DataMember]
        public string NumeroFactura { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion{ get; set; }

        /// <summary>
        /// Debito
        /// </summary>
        [DataMember]
        public decimal? Debito{ get; set; }

        /// <summary>
        /// Credito
        /// </summary>
        [DataMember]
        public decimal? Credito { get; set; }
    }
}