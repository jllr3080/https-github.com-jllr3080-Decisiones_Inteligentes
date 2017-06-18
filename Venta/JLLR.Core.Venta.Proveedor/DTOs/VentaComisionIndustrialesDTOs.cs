#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Venta.Proveedor.DTOs
{
    /// <summary>
    /// Venta  comision  industriales
    /// </summary>
    public class VentaComisionIndustrialesDTOs
    {

        /// <summary>
        /// Venta Comision Industriales
        /// </summary>
       public  VENTA_COMISION_INDUSTRIALES VentaComisionIndustriales{get;set ;}

        /// <summary>
        /// Detalle Venta Comision Industriales
        /// </summary>
        public List<DETALLE_VENTA_COMISION_INDUSTRIALES> DetalleVentaComisionIndustriales { get; set; }
    }
}
