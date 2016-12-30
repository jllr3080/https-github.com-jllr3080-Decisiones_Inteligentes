#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Contabilidad
{
    public class HistorialCuentaPorCobrarVistaModelo
    {

        /// <summary>
        /// Id
        /// </summary>
        
        public int HistorialCuentaPorCobrarId { get; set; }

        /// <summary>
        /// CuentaPorCobrarId
        /// </summary>
        
        public Int64? CuentaPorCobrarId { get; set; }


        /// <summary>
        /// FechaPago
        /// </summary>
        
        public DateTime? FechaCobro { get; set; }

        /// <summary>
        /// FechaPago
        /// </summary>
        
        public decimal? ValorCobro { get; set; }


        /// <summary>
        /// FechaPago
        /// </summary>
        
        public int? UsuarioId { get; set; }
    }
}