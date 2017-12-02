using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.ReglaNegocio;

namespace Web.DTOs.ReglaNegocio
{
    public class ReglaCompletaVistaDTOs
    {
        /// <summary>
        /// Regla
        /// </summary>
        
        public ReglaVistaModelo Regla { get; set; }

        /// <summary>
        /// Accione reglas
        /// </summary>
        
        public List<AccionReglaVistaModelo> AccionReglas { get; set; }
    }
}