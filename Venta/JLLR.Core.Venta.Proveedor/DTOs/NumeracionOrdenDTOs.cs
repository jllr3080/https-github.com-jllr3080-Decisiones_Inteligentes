#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Venta.Proveedor.DTOs
{
    public class NumeracionOrdenDTOs
    {

        /// <summary>
        /// Numeracion de Orden
        /// </summary>
        public NUMERACION_ORDEN NumeracionOrden { get; set; }


        /// <summary>
        /// Punto  de Venta
        /// </summary>
        public  PUNTO_VENTA PuntoVenta { get; set; }
    }
}
