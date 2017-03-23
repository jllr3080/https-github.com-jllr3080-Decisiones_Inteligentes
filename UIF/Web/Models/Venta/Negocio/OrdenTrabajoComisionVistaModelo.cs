#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Venta.Parametrizacion;

#endregion

namespace Web.Models.Venta.Negocio
{

    /// <summary>
    /// modelo de la orden de trabajo
    /// </summary>
    public class OrdenTrabajoComisionVistaModelo
    {

        /// <summary>
        /// Id de la orden de trabajo de la comision
        /// </summary>
        public Int64 OrdenTrabajoComisionId { get; set; }

        /// <summary>
        /// Venta de la comision  modelo
        /// </summary>
        public VentaComisionVistaModelo VentaComision { get; set; }


        /// <summary>
        /// Orden de  trabajo
        /// </summary>
        public OrdenTrabajoVistaModelo OrdenTrabajo { get; set; }

        /// <summary>
        /// FechaGeneracionComision
        /// </summary>
        public DateTime? FechaGeneracionComision { get; set; }


        /// <summary>
        /// UsuarioId
        /// </summary>
        public int? UsuarioId { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public decimal? Valor { get; set; }

    }
}