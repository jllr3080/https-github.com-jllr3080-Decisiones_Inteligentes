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
    /// Tipo de  Reproceso
    /// </summary>
    [DataContract]
    public class TipoReprocesoModelo
    {
        /// <summary>
        /// Tipo de  Reproceso Id 
        /// </summary>
        [DataMember]
        public int TipoReprocesoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion{ get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado{ get; set; }
    }
}