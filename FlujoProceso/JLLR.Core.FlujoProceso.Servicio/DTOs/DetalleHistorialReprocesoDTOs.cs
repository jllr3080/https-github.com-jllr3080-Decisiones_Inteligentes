#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.FlujoProceso.Servicio.Modelo;
using JLLR.Core.General.Servicio.Modelo;

#endregion
namespace JLLR.Core.FlujoProceso.Servicio.DTOs
{
    [DataContract]
    public class DetalleHistorialReprocesoDTOs
    {

        ///// <summary>
        ///// Historial  reproceso
        ///// </summary>
        //[DataMember]
        //public HistorialReprocesoModelo HistorialReproceso { get; set; }

        ///// <summary>
        ///// DetalleHistorialReproceso
        ///// </summary>
        //[DataMember]
        //public DetalleHistorialReprocesoModelo DetalleHistorialReproceso { get; set; }

        ///// <summary>
        ///// TipoReproceso
        ///// </summary>
        //[DataMember]
        //public TipoReprocesoModelo TipoReproceso { get; set; }

        /// <summary>
        /// TipoMotivoProceso
        /// </summary>
        [DataMember]
        public string TipoMotivoProceso { get; set; }

        /// <summary>
        /// Motivo
        /// </summary>
        [DataMember]
        public string Motivo { get; set; }
    }
}