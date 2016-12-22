#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Contabilidad
{
    public class DetalleCuentaPorCobrarVistaModelo
    {
        /// <summary>
        /// Id
        /// </summary>
        
        public Int64 DetalleCuentaPorCobrarId { get; set; }

        /// <summary>
        /// CuentaPorCobrarId
        /// </summary>
        
        public Int64? CuentaPorCobrarId { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// EstadoPagoId
        /// </summary>
        
        public int? EstadoPagoId { get; set; }

        /// <summary>
        /// UsuarioId
        /// </summary>
        
        public int? UsuarioId { get; set; }

        /// <summary>
        /// FechaCancelacion
        /// </summary>
        
        public DateTime? FechaCancelacion { get; set; }

        /// <summary>
        /// NumeroFactura
        /// </summary>
        
        public string NumeroFactura { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Debito
        /// </summary>
        
        public decimal? Debito { get; set; }

        /// <summary>
        /// Credito
        /// </summary>
        
        public decimal? Credito { get; set; }
    }
}