#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.DTOs.ReglaNegocio
{
    public class ReglaVistaDTOs
    {

        /// <summary>
        /// ReglaId
        /// </summary>
        public int ReglaId { get; set; }

        /// <summary>
        /// NombreRegla
        /// </summary>
        public string NombreRegla { get; set; }

        /// <summary>
        /// Porcentaje
        /// </summary>
        public decimal? Porcentaje { get; set; }


        /// <summary>
        /// ProductoId
        /// </summary>
        public int? ProductoId { get; set; }
    }
}