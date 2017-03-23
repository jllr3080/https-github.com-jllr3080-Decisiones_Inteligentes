using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Venta.Negocio;

namespace Web.DTOs.Venta
{
    public class OrdenTrabajoDescuentoVistaDTO
    {
        /// <summary>
        /// Nombre del punto de venta
        /// </summary>
        public string NombrePuntoVenta { get; set; }

        /// <summary>
        ///OrdenTrabajoDescuento
        /// </summary>
        public OrdenTrabajoDescuentoVistaModelo OrdenTrabajoDescuento { get; set; }
    }
}