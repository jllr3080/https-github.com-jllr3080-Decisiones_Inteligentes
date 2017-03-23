#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.Venta.Servicio.Modelo;

#endregion

namespace JLLR.Core.Venta.Servicio.DTOs
{
    [DataContract]
    public class DetalleOrdenTrabajoObservacionDTOs
    {
        /// <summary>
        /// Nombre Usuario
        /// </summary>
        [DataMember]
        public string NombreUsuario { get; set; }


        /// <summary>
        /// Observaciones d elas prendas    
        /// </summary>
        [DataMember ]
        public DetalleOrdenTrabajoObservacionModelo DetalleOrdenTrabajoObservacion { get; set; }
    }
}