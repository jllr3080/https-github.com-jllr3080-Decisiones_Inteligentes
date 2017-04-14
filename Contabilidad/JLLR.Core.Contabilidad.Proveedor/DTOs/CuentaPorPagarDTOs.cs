#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Contabilidad.Proveedor.DTOs
{
    /// <summary>
    /// Cuenta por  pagar dtos
    /// </summary>
    public class CuentaPorPagarDTOs
    {
        /// <summary>
        /// Cabecera de la cuentas por cobrar
        /// </summary>
        public CUENTA_POR_PAGAR CuentaPorPagar{ get; set; }

        /// <summary>
        /// HistorialCuentaPorCobrar
        /// </summary>
        public HISTORIAL_CUENTA_POR_PAGAR HistorialCuentaPorPagar { get; set; }


        /// <summary>
        /// Cliente
        /// </summary>
        public string proveedor { get; set; }
    }
}
