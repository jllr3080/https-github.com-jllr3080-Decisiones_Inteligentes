#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.Venta.Parametrizacion
{
    public class VentaComisionVistaModelo
    {
        /// <summary>
        /// Id 
        /// </summary>
        
        public int VentaComisionId { get; set; }

        /// <summary>
        ///VendedorId
        /// </summary>
        
        public int? VendedorId { get; set; }

        /// <summary>
        ///FechaComision
        /// </summary>
        
        public DateTime? FechaComision { get; set; }

        /// <summary>
        ///EstaHabilitado
        /// </summary>
        
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        ///PorcentajeComision
        /// </summary>
        
        public decimal? PorcentajeComision { get; set; }

        /// <summary>
        ///SucursalId
        /// </summary>
        
        public int? SucursalId { get; set; }


        /// <summary>
        ///PuntoVentaId
        /// </summary>
        
        public int? PuntoVentaId { get; set; }
    }
}