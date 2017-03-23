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
    /// Modelo de tipo de  regla de  negocio
    /// </summary>
    [DataContract]
    public class TipoReglaModelo
    {

        /// <summary>
        /// Tipo de regla id
        /// </summary>
        [DataMember]
        public int TipoReglaId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        [DataMember]
        public bool EstaHabilitado{ get; set; }
    }
}