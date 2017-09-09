#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.Individuo.Servicio.Modelo;

#endregion
namespace JLLR.Core.Individuo.Servicio.DTOs
{
    /// <summary>
    /// Datos del cliente 
    /// </summary>
    [DataContract]
    public class ClienteGeneralDTOs
    {
        /// <summary>
        /// Cliente
        /// </summary>
        [DataMember]
        public ClienteModelo Cliente { get; set; }

        /// <summary>
        /// Individuo
        /// </summary>
        [DataMember]
        public IndividuoModelo Individuo { get; set; }

        /// <summary>
        /// Direcion
        /// </summary>
        [DataMember]
        public DireccionModelo Direccion { get; set; }

        /// <summary>
        /// Telefono del cliente 
        /// </summary>
        [DataMember]
        public List<TelefonoModelo> Telefonos { get; set; }

        /// <summary>
        /// Telefono
        /// </summary>
        [DataMember]
        public TelefonoModelo Telefono { get; set; }

        /// <summary>
        /// CorreoElectronico
        /// </summary>
        [DataMember]
        public CorreoElectronicoModelo CorreoElectronico { get; set; }

        /// <summary>
        /// IndividuoRol
        /// </summary>
        [DataMember]
        public IndividuoRolModelo IndividuoRol { get; set; }

        /// <summary>
        /// NombreCompleto
        /// </summary>
        [DataMember]
        public string NombreCompleto { get; set; }


        /// <summary>
        /// DireccionCompleta
        /// </summary>
        [DataMember]
        public string DireccionCompleta { get; set; }
    }
}