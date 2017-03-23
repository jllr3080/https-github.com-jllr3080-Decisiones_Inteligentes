using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ReglaNegocio
{
    public class AccionReglaVistaModelo
    {
        /// <summary>
        /// AccionreglaId
        /// </summary>
        
        public int AccionreglaId { get; set; }

        /// <summary>
        /// Regla
        /// </summary>
        
        public ReglaVistaModelo Regla { get; set; }

        /// <summary>
        /// ProductoId
        /// </summary>
        
        public int? ProductoId { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        
        public decimal? Valor { get; set; }
    }
}