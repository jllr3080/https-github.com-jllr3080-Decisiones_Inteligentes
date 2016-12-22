#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Contabilidad;
#endregion
namespace Web.DTOs.Contabilidad
{
    public class CuentaPorCobrarVistaDTOs
    {


        /// <summary>
        /// Cabecera de la cuentas por cobrar
        /// </summary>
        public CuentaPorCobrarVistaModelo CuentaPorCobrar { get; set; }

        /// <summary>
        /// Detalle de la cuenta por cobrar
        /// </summary>
        public List<DetalleCuentaPorCobrarVistaModelo> DetalleCuentaPorCobrar { get; set; }
    }
}