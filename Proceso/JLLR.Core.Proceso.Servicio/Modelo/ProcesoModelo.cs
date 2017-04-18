#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.General.Servicio.Modelo;

#endregion
namespace JLLR.Core.Proceso.Servicio.Modelo
{
    [DataContract]
    public class ProcesoModelo
    {
        /// <summary>
        /// ProcesoId
        /// </summary>
        [DataMember]
        public Int64 ProcesoId { get; set; }

        /// <summary>
        /// EtapaProceso
        /// </summary>
        [DataMember]
        public EtapaProcesoModelo EtapaProceso { get; set; }


        /// <summary>
        /// SucursalId
        /// </summary>
        [DataMember]
        public int? SucursalId { get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        [DataMember]
        public int? PuntoVentaId { get; set; }

        /// <summary>
        /// FechaEnvio
        /// </summary>
        [DataMember]
        public DateTime? FechaEnvio { get; set; }

        /// <summary>
        /// NumeroOrden
        /// </summary>
        [DataMember]
        public string NumeroOrden { get; set; }

        /// <summary>
        /// SeEnvio
        /// </summary>
        [DataMember]
        public Boolean? SeEnvio { get; set; }

        /// <summary>
        /// Mensaje
        /// </summary>
        [DataMember]
        public string Mensaje { get; set; }
    }
}