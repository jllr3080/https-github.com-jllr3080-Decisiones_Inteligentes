using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.Individuo.Servicio.Modelo;

namespace JLLR.Core.Individuo.Servicio.DTOs
{
    [DataContract]
    public class ProveedorDTOs
    {

        /// <summary>
        ///  Individuo
        /// </summary>
        [DataMember]
        public IndividuoModelo Individuo { get; set; }

        /// <summary>
        /// Proveedor
        /// </summary>
        [DataMember]
        public ProveedorModelo Proveedor { get; set; }

        /// <summary>
        /// Direccion del Proveedor 
        /// </summary>
        [DataMember]
        public DireccionModelo Direccion { get; set; }

        /// <summary>
        /// Telefono del Proveedor 
        /// </summary>
        [DataMember]
        public TelefonoModelo Telefono { get; set; }

        /// <summary>
        /// Correo electronico del Proveedor 
        /// </summary>

        [DataMember]
        public CorreoElectronicoModelo CorreoElectronico { get; set; }

        /// <summary>
        /// IndividuoRol
        /// </summary>
        [DataMember]
        public IndividuoRolModelo IndividuoRol { get; set; }
    }
}