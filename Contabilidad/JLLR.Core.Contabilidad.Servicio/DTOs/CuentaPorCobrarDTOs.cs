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
    /// Cuenta por pagar DTOS
    /// </summary>
    [DataContract]
    public class CuentaPorCobrarDTOs
    {
        /// <summary>
        /// Cabecera de la cuentas por cobrar
        /// </summary>
        [DataMember]
        public CuentaPorCobrarModelo CuentaPorCobrar { get; set; }

       
    }
}