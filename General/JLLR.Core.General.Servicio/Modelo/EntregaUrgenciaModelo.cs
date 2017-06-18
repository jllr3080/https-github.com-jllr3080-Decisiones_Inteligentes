#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.General.Servicio.Modelo
{
    [DataContract]
    public class EntregaUrgenciaModelo
    {
        /// <summary>
        /// EntregaUrgenciaId
        /// </summary>
        [DataMember]
        public int EntregaUrgenciaId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado{ get; set; }
    }
}