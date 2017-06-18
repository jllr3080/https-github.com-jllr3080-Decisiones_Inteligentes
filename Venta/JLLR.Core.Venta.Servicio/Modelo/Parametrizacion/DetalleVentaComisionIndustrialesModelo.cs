#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion;

#endregion
namespace JLLR.Core.Venta.Servicio.Modelo.Parametrizacion
{
    [DataContract]
    public class DetalleVentaComisionIndustrialesModelo
    {
        /// <summary>
        /// DetalleVentaComisionIndustrialesId 
        /// </summary>
        [DataMember]
        public int DetalleVentaComisionIndustrialesId { get; set; }

        /// <summary>
        /// VentaComisionIndustriales 
        /// </summary>
        [DataMember]
        public VentaComisionIndustrialesModelo VentaComisionIndustriales { get; set; }

        /// <summary>
        /// ProductoPrecio 
        /// </summary>
        [DataMember]
        public ProductoPrecioModelo ProductoPrecio { get; set; }

        /// <summary>
        /// EstaHabilitado 
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        /// FechaCreacion 
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// Porcentaje 
        /// </summary>
        [DataMember]
        public decimal? Porcentaje { get; set; }

        /// <summary>
        /// UsuarioId 
        /// </summary>
        [DataMember]
        public int? UsuarioId { get; set; }
    }
}