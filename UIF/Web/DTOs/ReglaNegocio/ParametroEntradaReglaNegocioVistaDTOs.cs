#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.DTOs.ReglaNegocio
{
    public class ParametroEntradaReglaNegocioVistaDTOs
    {
        /// <summary>
        /// Codigo del Producto
        /// </summary>
        public int? ProductoId { get; set; }


        /// <summary>
        /// Cantidad e  prendas
        /// </summary>
        public int? Cantidad { get; set; }


        /// <summary>
        /// Valor Unitario 
        /// </summary>
        public decimal? ValorUnitario { get; set; }


        /// <summary>
        /// Valor Total del Producto
        /// </summary>
        public decimal? ValorTotal { get; set; }


        /// <summary>
        /// Valor de la promocion
        /// </summary>
        public decimal? ValorPromocion { get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        public int? SucursalId { get; set; }
        /// <summary>
        /// PuntoVentaId
        /// </summary>
        public int? PuntoVentaId { get; set; }
    }
}