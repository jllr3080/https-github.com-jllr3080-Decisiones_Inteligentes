#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.ReglaNegocio.Proveedor.DTOs
{
    public class ParametroSalidaReglaNegocioDTOs
    {
        /// <summary>
        /// ProductoId
        /// </summary>
        public int? ProductoId { get; set; }

        /// <summary>
        /// Cantidad de prendas
        /// </summary>
        public int? Cantidad { get; set; }

        /// <summary>
        /// Valor Unitario del producto
        /// </summary>
        public decimal? ValorUnitario { get; set; }

        /// <summary>
        /// Valor Total del producto sin descuento
        /// </summary>
        public decimal? ValorTotal { get; set; }

        /// <summary>
        /// Valor de Descuento
        /// </summary>
        public decimal? ValorDescuento { get; set; }


        /// <summary>
        /// Valor  total - Valor de Descuento
        /// </summary>
        public decimal? ValorTotalPagar { get; set; }

        /// <summary>
        /// promocion
        /// </summary>
       
        public string NombrePromocion { get; set; }

        /// <summary>
        /// Id de la promocion
        /// </summary>

        public int? PromocionId { get; set; }
    }
}
