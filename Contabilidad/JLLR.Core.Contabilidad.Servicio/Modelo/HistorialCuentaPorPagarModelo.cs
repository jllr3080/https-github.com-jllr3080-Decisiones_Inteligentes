#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.Contabilidad.Servicio.Modelo
{
    [DataContract]
    public class HistorialCuentaPorPagarModelo
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public Int64 HistorialCuentaPorPagarId { get; set; }

        /// <summary>
        /// CuentaPorCobrarId
        /// </summary>
        [DataMember]
        public Int64? CuentaPorPagarId { get; set; }


        /// <summary>
        /// FechaPago
        /// </summary>
        [DataMember]
        public DateTime? FechaPago { get; set; }

        /// <summary>
        /// FechaPago
        /// </summary>
        [DataMember]
        public decimal? ValorPago { get; set; }


        /// <summary>
        /// FechaPago
        /// </summary>
        [DataMember]
        public int? UsuarioId { get; set; }

    }
}