#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Contabilidad
{
    public class CuentaPorCobrarVistaModelo
    {
        /// <summary>
        /// Id
        /// </summary>
        
        public Int64 CuentaPorCobrarId { get; set; }

        /// <summary>
        /// IndividuoId
        /// </summary>
        
        public Int64? IndividuoId { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }


        /// <summary>
        /// UsuarioId
        /// </summary>
        
        public int? UsuarioId { get; set; }


        /// <summary>
        /// EstadoCuentaPorSucursal
        /// </summary>
        
        public bool? EstadoCuentaPorSucursal { get; set; }

        /// <summary>
        /// SucursalId
        /// </summary>
        
        public int? SucursalId { get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        
        public int? PuntoVentaId { get; set; }

        /// <summary>
        /// EstadoCuentaPorPuntoVenta
        /// </summary>
        
        public bool? EstadoCuentaPorPuntoVenta { get; set; }
    }
}