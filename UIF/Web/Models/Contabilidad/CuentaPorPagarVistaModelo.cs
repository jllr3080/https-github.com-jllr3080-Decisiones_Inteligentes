#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Contabilidad
{
    public class CuentaPorPagarVistaModelo
    {
        /// <summary>
        /// Id
        /// </summary>
        
        public Int64 CuentaPorPagarId { get; set; }

        /// <summary>
        /// IndividuoId
        /// </summary>
        
        public Int64? ProveedorId { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaVencimiento { get; set; }


        /// <summary>
        /// UsuarioId
        /// </summary>
        
        public int? UsuarioCreacionId { get; set; }

        /// <summary>
        /// UsuarioId
        /// </summary>
        
        public int? UsuarioModificacionId { get; set; }



        /// <summary>
        /// SucursalId
        /// </summary>
        
        public int? SucursalId { get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        
        public int? PuntoVentaId { get; set; }

        /// <summary>
        /// Saldo
        /// </summary>
        
        public decimal? Saldo { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        
        public decimal? Valor { get; set; }

        /// <summary>
        /// NumeroFactura
        /// </summary>
        
        public string NumeroFactura { get; set; }

        /// <summary>
        /// NumeroFactura
        /// </summary>
        
        public string NumeroOrden { get; set; }
    }
}