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
        /// HistorialCuentaPorCobrar
        /// </summary>
        public HistorialCuentaPorCobrarVistaModelo HistorialCuentaPorCobrar { get; set; }


        /// <summary>
        /// Cliente
        /// </summary>
        public string Cliente { get; set; }
    }
}