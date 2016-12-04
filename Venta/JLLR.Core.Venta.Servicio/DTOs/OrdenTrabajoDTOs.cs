#region using

using System.Collections.Generic;
using System.Runtime.Serialization;
using JLLR.Core.Venta.Servicio.Modelo;

#endregion
namespace JLLR.Core.Venta.Servicio.DTOs
{
    /// <summary>
    /// Dto de la orden de  trabajo
    /// </summary>
    [DataContract]
    public class OrdenTrabajoDTOs
    {
        /// <summary>
        /// Orden de  trabajo
        /// </summary>
        [DataMember]
        public OrdenTrabajoModelo OrdenTrabajo { get; set; }

        /// <summary>
        /// Detalle de la Orden de  trabajo
        /// </summary>
        [DataMember]
        public List<DetalleOrdenTrabajoModelo> DetalleOrdenTrabajo { get; set; }

    }
}