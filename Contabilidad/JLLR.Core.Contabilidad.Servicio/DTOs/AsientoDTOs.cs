#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.Contabilidad.Servicio.Modelo;

#endregion

namespace JLLR.Core.Contabilidad.Servicio.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class AsientoDTOs
    {

        /// <summary>
        /// Cuenta por cobrar
        /// </summary>
        [DataMember]
        public CuentaPorCobrarModelo CuentaPorCobrar { get; set; }

        /// <summary>
        /// HistorialCuentaPorCobrar
        /// </summary>
        [DataMember]
        public HistorialCuentaPorCobrarModelo HistorialCuentaPorCobrar { get; set; }


        /// <summary>
        /// CuentaPorPagar
        /// </summary>
        [DataMember]
        public CuentaPorPagarModelo CuentaPorPagar { get; set; }


        /// <summary>
        /// HistorialCuentaPorPagar
        /// </summary>
        [DataMember]
        public HistorialCuentaPorPagarModelo HistorialCuentaPorPagar { get; set; }
    }
}