#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.Logistica.Servicio.Modelo;

#endregion
namespace JLLR.Core.Logistica.Servicio.DTOs
{
    /// <summary>
    /// Entrega orden de trabajo
    /// </summary>
    [DataContract]
    public class EntregaOrdenTrabajoDTOs
    {
        /// <summary>
        /// Entraga orden de  trabajo
        /// </summary>
        [DataMember]
        public EntregaOrdenTrabajoModelo EntregaOrdenTrabajo { get; set; }

        /// <summary>
        /// Detalle  entrega orden de  trabajo
        /// </summary>

        [DataMember]
        public List<DetalleEntregaOrdenTrabajoModelo> DetalleEntregaOrdenTrabajo { get; set; }


    }
}