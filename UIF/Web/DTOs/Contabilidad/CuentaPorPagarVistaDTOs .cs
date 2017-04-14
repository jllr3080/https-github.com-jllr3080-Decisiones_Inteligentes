#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Contabilidad;

#endregion
namespace Web.DTOs.Contabilidad
{
    public class CuentaPorPagarVistaDTOs
    {
        /// <summary>
        /// Cabecera de la cuentas por cobrar
        /// </summary>
    
        public CuentaPorPagarVistaModelo CuentaPorPagar { get; set; }

        /// <summary>
        /// HistorialCuentaPorCobrar
    
        public HistorialCuentaPorPagarVistaModelo HistorialCuentaPorPagar { get; set; }


        /// <summary>
        /// Cliente
        /// </summary>
      
        public string proveedor { get; set; }
    }
}