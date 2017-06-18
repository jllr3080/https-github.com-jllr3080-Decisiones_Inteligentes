#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{
    public class EntregaUrgenciaVistaModelo
    {


        /// <summary>
        /// EntregaUrgenciaId
        /// </summary>

        public int EntregaUrgenciaId { get; set; }

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