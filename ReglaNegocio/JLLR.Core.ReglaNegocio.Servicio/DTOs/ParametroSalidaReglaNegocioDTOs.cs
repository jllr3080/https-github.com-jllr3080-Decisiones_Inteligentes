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
    public class ParametroSalidaReglaNegocioDTOs
    {
        /// <summary>
        /// ProductoId
        /// </summary>
        [DataMember]
        public int? ProductoId { get; set; }

        /// <summary>
        /// Cantidad de prendas
        /// </summary>
        [DataMember]
        public int? Cantidad { get; set; }

        /// <summary>
        /// Valor Unitario del producto
        /// </summary>
        [DataMember]
        public decimal? ValorUnitario { get; set; }

        /// <summary>
        /// Valor Total del producto sin descuento
        /// </summary>
        [DataMember]
        public decimal? ValorTotal { get; set; }

        /// <summary>
        /// Valor de Descuento
        /// </summary>
        [DataMember]
        public decimal? ValorDescuento { get; set; }


        /// <summary>
        /// Valor  total - Valor de Descuento
        /// </summary>
        [DataMember]
        public decimal? ValorTotalPagar { get; set; }

        /// <summary>
        /// promocion
        /// </summary>
        [DataMember]
        public string NombrePromocion { get; set; }

        /// <summary>
        /// Id de la promocion
        /// </summary>
        [DataMember]
        public int? PromocionId { get; set; }
    }
}