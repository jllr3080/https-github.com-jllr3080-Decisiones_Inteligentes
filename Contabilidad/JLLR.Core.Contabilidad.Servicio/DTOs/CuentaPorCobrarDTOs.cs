#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.Contabilidad.Servicio.Modelo;
using  modeloIndividuo= JLLR.Core.Individuo.Servicio.Modelo;
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

        /// <summary>
        /// HistorialCuentaPorCobrar
        /// </summary>
        [DataMember]
        public HistorialCuentaPorCobrarModelo HistorialCuentaPorCobrar { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        [DataMember]
        public string Cliente { get; set; }

        /// <summary>
        /// Direccion
        /// </summary>
        [DataMember]
        public string Direccion { get; set; }

        /// <summary>
        /// NumeroTelefonos
        /// </summary>
        [DataMember]
        public string NumeroTelefonos { get; set; }



        /// <summary>
        /// IndividuoId
        /// </summary>
        [DataMember]
        public int? IndividuoId { get; set; }


    }
}