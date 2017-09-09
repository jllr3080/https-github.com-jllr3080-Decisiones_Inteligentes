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
    /// Modelo de los meses
    /// </summary>
    [DataContract]
    public class MesModelo
    {

        /// <summary>
        /// Mes ID
        /// </summary>
        [DataMember]
        public int MesId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        /// FechaDesde
        /// </summary>
        [DataMember]
        public DateTime? FechaDesde { get; set; }

        /// <summary>
        /// FechaHasta
        /// </summary>
        [DataMember]
        public DateTime? FechaHasta { get; set; }
    }
}