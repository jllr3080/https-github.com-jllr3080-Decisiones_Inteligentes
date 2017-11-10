﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Contabilidad
{
    public class HistorialCuentaPorPagarVistaModelo
    {
        /// <summary>
        /// Id
        /// </summary>

        public Int64 HistorialCuentaPorPagarId { get; set; }

        /// <summary>
        /// CuentaPorCobrarId
        /// </summary>

        public Int64? CuentaPorPagarId { get; set; }


        /// <summary>
        /// FechaPago
        /// </summary>

        public DateTime? FechaPago { get; set; }

        /// <summary>
        /// FechaPago
        /// </summary>

        public decimal? ValorPago { get; set; }


        /// <summary>
        /// FechaPago
        /// </summary>

        public int? UsuarioId { get; set; }
    }
}
