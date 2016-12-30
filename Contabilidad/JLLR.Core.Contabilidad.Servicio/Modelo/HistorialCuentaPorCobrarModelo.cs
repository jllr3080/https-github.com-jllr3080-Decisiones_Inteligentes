
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
    public class HistorialCuentaPorCobrarModelo
    {

        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public int HistorialCuentaPorCobrarId { get; set; }

        /// <summary>
        /// CuentaPorCobrarId
        /// </summary>
        [DataMember]
        public Int64? CuentaPorCobrarId { get; set; }


        /// <summary>
        /// FechaPago
        /// </summary>
        [DataMember]
        public DateTime? FechaCobro{ get; set; }

        /// <summary>
        /// FechaPago
        /// </summary>
        [DataMember]
        public decimal? ValorCobro{ get; set; }
        
        
        /// <summary>
        /// FechaPago
        /// </summary>
        [DataMember]
        public int? UsuarioId{ get; set; }

    }
}