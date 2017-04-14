#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.General.Servicio.Modelo
{
    public class ParroquiaModelo
    {

        /// <summary>
        /// Id de la ciudad
        /// </summary>
        [DataMember]
        public int ParroquiaId { get; set; }

        /// <summary>
        /// Id de la ciudad
        /// </summary>
        [DataMember]
        public int? CiudadId { get; set; }

        /// <summary>
        /// Id del Pais
        /// </summary>
        [DataMember]
        public int? PaisId { get; set; }

        /// <summary>
        /// Id del estado
        /// </summary>
        [DataMember]
        public int? EstadoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }
    }
}