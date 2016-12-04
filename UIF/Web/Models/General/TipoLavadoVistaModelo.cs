#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{
    public class TipoLavadoVistaModelo
    {
        /// <summary>
        /// Tipo de lavado id
        /// </summary>
        
        public int TipoLavadoId { get; set; }

        /// <summary>
        /// Descipcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Esta Habilitado
        /// </summary>
        
        public bool? EstaHabilitado { get; set; }
    }
}