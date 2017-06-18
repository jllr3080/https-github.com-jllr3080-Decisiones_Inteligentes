#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.FlujoProceso.Servicio.Modelo
{
    [DataContract]
    public class HistorialReclamoReprocesoPrendaModelo
    {

        /// <summary>
        /// HistorialReclamoReprocesoPrendaId
        /// </summary>
        [DataMember]
        public Int64 HistorialReclamoReprocesoPrendaId { get; set; }

        /// <summary>
        /// DetallePrendaOrdenTrabajoId
        /// </summary>
        [DataMember]
        public int? DetallePrendaOrdenTrabajoId  { get; set; }

        /// <summary>
        /// Fecha
        /// </summary>
        [DataMember]
        public DateTime? Fecha { get; set; }

        /// <summary>
        /// PorqueReproceso
        /// </summary>
        [DataMember]
        public string PorqueReproceso{ get; set; }

        /// <summary>
        /// UsuarioId
        /// </summary>
        [DataMember]
        public int? UsuarioId{ get; set; }

        /// <summary>
        /// FechaEntrega
        /// </summary>
        [DataMember]
        public DateTime? FechaEntrega{ get; set; } 
    }
}