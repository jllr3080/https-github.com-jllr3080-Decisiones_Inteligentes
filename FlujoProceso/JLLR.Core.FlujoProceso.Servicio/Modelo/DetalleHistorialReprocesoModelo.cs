#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.General.Servicio.Modelo;

#endregion

namespace JLLR.Core.FlujoProceso.Servicio.Modelo
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class DetalleHistorialReprocesoModelo
    {
        /// <summary>
        /// Id del detalle de  reproceso
        /// </summary>
        [DataMember]
        public int DetalleHistorialReprocesoId { get; set; }

        /// <summary>
        /// HistorialReproceso
        /// </summary>
        [DataMember]
        public HistorialReprocesoModelo HistorialReproceso { get; set; }


        /// <summary>
        /// TipoReproceso
        /// </summary>
        [DataMember]
        public TipoReprocesoModelo TipoReproceso { get; set; }

        /// <summary>
        /// Motivo
        /// </summary>
        [DataMember]
        public string Motivo { get; set; }
    }
}