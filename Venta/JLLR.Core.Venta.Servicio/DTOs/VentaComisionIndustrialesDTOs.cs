using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;

namespace JLLR.Core.Venta.Servicio.DTOs
{
    [DataContract]
    public class VentaComisionIndustrialesDTOs
    {
        /// <summary>
        /// Venta Comision Industriales
        /// </summary>
        [DataMember]
        public VentaComisionIndustrialesModelo VentaComisionIndustriales { get; set; }

        /// <summary>
        /// Detalle Venta Comision Industriales
        /// </summary>
        [DataMember]
        public List<DetalleVentaComisionIndustrialesModelo> DetalleVentaComisionIndustriales { get; set; }
    }
}