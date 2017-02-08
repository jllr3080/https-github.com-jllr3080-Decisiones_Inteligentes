#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
using System.Web;
#endregion

namespace JLLR.Core.Individuo.Servicio.Modelo
{
    /// <summary>
    /// Proveedor modelo 
    /// </summary>
    [DataContract]
    public class ProveedorModelo
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        [DataMember]
        public int ProveedorId { get; set; }

        /// <summary>
        /// FormaPago
        /// </summary>
        [DataMember]
        public modeloGeneral.FormaPagoModelo FormaPago{ get; set; }

        /// <summary>
        /// Individuo
        /// </summary>
        [DataMember]
        public IndividuoModelo Individuo { get; set; }

        /// <summary>
        /// DiasCredito
        /// </summary>
        [DataMember]
        public int? DiasCredito{ get; set; }
    }
}