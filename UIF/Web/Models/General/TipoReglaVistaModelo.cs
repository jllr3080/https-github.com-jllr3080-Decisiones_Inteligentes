using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.General
{
    public class TipoReglaVistaModelo
    {

        /// <summary>
        /// Tipo de regla id
        /// </summary>
        
        public int TipoReglaId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        
        public bool EstaHabilitado { get; set; }
    }
}