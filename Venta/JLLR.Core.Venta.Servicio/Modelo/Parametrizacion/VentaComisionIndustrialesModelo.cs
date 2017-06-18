#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.Venta.Servicio.Modelo.Parametrizacion
{

    /// <summary>
    /// Modelo de la  comision de  industriales
    /// </summary>
    [DataContract]
    public class VentaComisionIndustrialesModelo
    {
        /// <summary>
        /// VentaComisionIndustrialesId
        /// </summary>
        [DataMember]
        public int VentaComisionIndustrialesId { get; set; }

        /// <summary>
        /// VendedorId
        /// </summary>
        [DataMember]
        public int? VendedorId { get; set; }

        /// <summary>
        /// FechaComision
        /// </summary>
        [DataMember]
        public DateTime? FechaComision { get; set; }

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
    }
}