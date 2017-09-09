using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.General
{
    public class TipoReprocesoVistaModelo
    {
        /// <summary>
        /// Tipo de  Reproceso Id 
        /// </summary>
    
        public int TipoReprocesoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
      
        public string Descripcion { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
   
        public bool? EstaHabilitado { get; set; }
    }
}