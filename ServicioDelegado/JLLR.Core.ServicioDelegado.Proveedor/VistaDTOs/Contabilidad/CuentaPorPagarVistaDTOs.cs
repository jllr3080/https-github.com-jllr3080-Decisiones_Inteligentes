#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Contabilidad;

#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.VistaDTOs.Contabilidad
{
   public  class CuentaPorPagarVistaDTOs
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
