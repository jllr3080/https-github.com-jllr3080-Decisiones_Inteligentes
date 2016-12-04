#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.Individuo.Servicio.DTOs
{
    /// <summary>
    /// Datos del cliente 
    /// </summary>
    [DataContract]
    public class ClienteDTOs
    {

        /// <summary>
        /// Id del cliente
        /// </summary>
        [DataMember]
        public int? ClienteId { get; set; }

        /// <summary>
        /// Id del individuo
        /// </summary>
        [DataMember]
        public int? IndividuoId { get; set; }

        /// <summary>
        /// Nombre completo del cliente
        /// </summary>
        [DataMember]
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Direccion completa del cliente
        /// </summary>
        [DataMember]
        public string DireccionCliente { get; set; }

        /// <summary>
        /// Telefono del cliente
        /// </summary>
        [DataMember]
        public string TelefonoCliente { get; set; }
    }
}