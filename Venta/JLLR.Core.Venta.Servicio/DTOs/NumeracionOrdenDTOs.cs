#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;

#endregion

namespace JLLR.Core.Venta.Servicio.DTOs
{
    public class NumeracionOrdenDTOs
    {

        /// <summary>
        /// Numeracion de Orden
        /// </summary>
        public NumeroOrdenModelo NumeracionOrden { get; set; }


        /// <summary>
        /// Punto  de Venta
        /// </summary>
        public PuntoVentaModelo PuntoVenta { get; set; }
    }
}