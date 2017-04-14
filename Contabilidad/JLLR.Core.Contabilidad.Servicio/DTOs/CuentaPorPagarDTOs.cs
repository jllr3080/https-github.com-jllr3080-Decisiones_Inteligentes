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
    /// Cuenta por  pagar
    /// </summary>
    [DataContract]
    public class CuentaPorPagarDTOs
    {


        /// <summary>
        /// Cabecera de la cuentas por cobrar
        /// </summary>
        [DataMember]
        public CuentaPorPagarModelo CuentaPorPagar { get; set; }

        /// <summary>
        /// HistorialCuentaPorCobrar
        /// </summary>
        [DataMember]
        public HistorialCuentaPorPagarModelo HistorialCuentaPorPagar { get; set; }


        /// <summary>
        /// Cliente
        /// </summary>
        [DataMember]
        public string proveedor { get; set; }
    }
}