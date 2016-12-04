#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Modelo de  tipo de individuo
    /// </summary>
    [DataContract]
    public class TipoIndividuoModelo
    {
        /// <summary>
        /// Tipo de individuo id
        /// </summary>
        [DataMember]
        public int TipoIndividuoId { get; set; }

        /// <summary>
        /// Descipcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// Esta Habilitado
        /// </summary>
        [DataMember]
        public bool? PorDefecto { get; set; }
    }
}