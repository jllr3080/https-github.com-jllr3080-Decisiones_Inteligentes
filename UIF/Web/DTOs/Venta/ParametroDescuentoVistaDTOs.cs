#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.DTOs.Venta
{
    public class ParametroDescuentoVistaDTOs
    {
        /// <summary>
        /// OrdenTrabajoId
        /// </summary>

        public int OrdenTrabajoId { get; set; }

        /// <summary>
        /// ValorDescuentoFranquicia
        /// </summary>

        public decimal? ValorDescuentoFranquicia { get; set; }

        /// <summary>
        /// ValorDescuentoMatriz
        /// </summary>

        public decimal? ValorDescuentoMatriz { get; set; }

        /// <summary>
        /// UsuarioId
        /// </summary>


        public int? UsuarioId { get; set; }
    }
}