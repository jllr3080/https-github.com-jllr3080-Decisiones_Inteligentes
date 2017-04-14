#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.DTOs
{
    [DataContract]
    public class ParametroEntradaReglaNegocioDTOs
    {

        /// <summary>
        /// Codigo del Producto
        /// </summary>
        [DataMember]
        public int? ProductoId { get; set; }


        /// <summary>
        /// Cantidad e  prendas
        /// </summary>
        [DataMember]
        public int? Cantidad { get; set; }


        /// <summary>
        /// Valor Unitario 
        /// </summary>
        [DataMember]
        public decimal? ValorUnitario { get; set; }


        /// <summary>
        /// Valor Total del Producto
        /// </summary>
        [DataMember]
        public decimal? ValorTotal { get; set; }


        /// <summary>
        /// Valor de la promocion
        /// </summary>
        [DataMember]
        public decimal? ValorPromocion { get; set; }

        /// <summary>
        /// PuntoVentaId
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