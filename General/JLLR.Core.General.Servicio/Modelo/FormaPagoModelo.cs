#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


#endregion

namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Modelo de la  forma de  pago
    /// </summary>
    [DataContract]
    public class FormaPagoModelo
    {

        /// <summary>
        /// FormaPagoId
        /// </summary>
        [DataMember]
        public int FormaPagoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion{ get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado { get; set; }
    }
}