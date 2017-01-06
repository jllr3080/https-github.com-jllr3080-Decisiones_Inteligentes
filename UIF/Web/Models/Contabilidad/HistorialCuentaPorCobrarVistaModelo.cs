#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using modeloVistaGeneral= Web.Models.General;
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

        /// <summary>
        /// FormaPago
        /// </summary>

        public modeloVistaGeneral.FormaPagoVistaModelo FormaPago { get; set; }
    }
}