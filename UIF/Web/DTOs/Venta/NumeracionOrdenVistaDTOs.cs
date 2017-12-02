#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General;
using Web.Models.Venta.Parametrizacion;

#endregion

namespace Web.DTOs.Venta
{
    public class NumeracionOrdenVistaDTOs
    {

        /// <summary>
        /// Numeracion de Orden
        /// </summary>
        public NumeroOrdenVistaModelo NumeracionOrden { get; set; }


        /// <summary>
        /// Punto  de Venta
        /// </summary>
        public PuntoVentaVistaModelo PuntoVenta { get; set; }
    }
}