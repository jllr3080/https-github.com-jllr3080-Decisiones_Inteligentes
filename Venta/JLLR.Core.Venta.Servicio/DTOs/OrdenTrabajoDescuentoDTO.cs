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
    public class OrdenTrabajoDescuentoDTO
    {
        /// <summary>
        /// Nombre del punto de venta
        /// </summary>
        [DataMember]
        public string NombrePuntoVenta { get; set; }

        /// <summary>
        ///OrdenTrabajoDescuento
        /// </summary>
        [DataMember]
        public OrdenTrabajoDescuentoModelo OrdenTrabajoDescuento { get; set; }
    }
}