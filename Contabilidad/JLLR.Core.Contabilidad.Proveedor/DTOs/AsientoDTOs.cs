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
    /// Asientos
    /// </summary>
    public class AsientoDTOs
    {
        /// <summary>
        /// Cuenta por cobrar
        /// </summary>
        public CUENTA_POR_COBRAR CuentaPorCobrar { get; set; }

        /// <summary>
        /// HistorialCuentaPorCobrar
        /// </summary>
        public HISTORIAL_CUENTA_POR_COBRAR HistorialCuentaPorCobrar{ get; set; }


        /// <summary>
        /// CuentaPorPagar
        /// </summary>
        public CUENTA_POR_PAGAR CuentaPorPagar{ get; set; }


        /// <summary>
        /// HistorialCuentaPorPagar
        /// </summary>
        public HISTORIAL_CUENTA_POR_PAGAR HistorialCuentaPorPagar { get; set; }

    }
}
