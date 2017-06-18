#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.FlujoProceso.Servicio.Modelo;

#endregion
namespace JLLR.Core.FlujoProceso.Servicio.DTOs
{
    [DataContract]
    public class HistorialReprocesoDTOs
    {
        /// <summary>
        /// HistorialProceso
        /// </summary>
        [DataMember]
        public HistorialProcesoModelo HistorialProceso { get; set; }


        /// <summary>
        /// Graba los  reprocesos
        /// </summary>
        [DataMember]
        public List<HistorialReprocesoModelo> HistorialReprocesos { get; set; }
    }
}