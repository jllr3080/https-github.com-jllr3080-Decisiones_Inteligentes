#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.Seguridad.Servicio.DTOs
{
    /// <summary>
    /// DTO que  genera el menu
    /// </summary>
    [DataContract]
    public class AccesoDTOs
    {

        /// <summary>
        /// Id  del modulo
        /// </summary>
        [DataMember]
        public int? ModuloId { get; set; }


        /// <summary>
        /// Descripcion del modulo
        /// </summary>
        [DataMember]
        public string Modulo { get; set; }

        /// <summary>
        /// Id  del Submodulo
        /// </summary>
        [DataMember]
        public int? SubmoduloId { get; set; }

        /// <summary>
        /// Descripcion del Submodulo
        /// </summary>
        [DataMember]
        public string SubModulo { get; set; }

        /// <summary>
        /// Id  del Acceso
        /// </summary>
        [DataMember]
        public int? AccesoId { get; set; }


        /// <summary>
        /// Descripcion del Acceso
        /// </summary>
        [DataMember]
        public string Acceso { get; set; }


        /// <summary>
        /// Direccion de la pagina
        /// </summary>
        [DataMember]
        public string Url { get; set; }
    }
}