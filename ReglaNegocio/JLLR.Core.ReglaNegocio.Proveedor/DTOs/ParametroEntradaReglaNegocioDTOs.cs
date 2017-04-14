#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.ReglaNegocio.Proveedor.DTOs
{
    public class ParametroEntradaReglaNegocioDTOs
    {
        /// <summary>
        /// Codigo del Producto
        /// </summary>
        public int? ProductoId { get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        public int? SucursalId { get; set; }
        /// <summary>
        /// PuntoVentaId
        /// </summary>
        public int? PuntoVentaId { get; set; }


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

       
    }
}
