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
    public class HistorialReprocesoModelo
    {
        /// <summary>
        /// HistorialReprocesoId
        /// </summary>
        [DataMember]
        public Int64 HistorialReprocesoId { get; set; }

        /// <summary>
        /// HistorialProceso
        /// </summary>
        [DataMember]
        public HistorialProcesoModelo HistorialProceso { get; set; }


        /// <summary>
        /// DetallePrendaOrdenTrabajoId
        /// </summary>
        [DataMember]
        public int? DetallePrendaOrdenTrabajoId { get; set; }


        /// <summary>
        /// FechaEstimadaEntrega
        /// </summary>
        [DataMember]
        public DateTime? FechaEstimadaEntrega { get; set; }



    }
}