#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{
    public class TipoRolIndividuoVistaModelo
    {
        /// <summary>
        /// Id del tipo de el rol del individuo
        /// </summary>
        
        public int TipoRolIndividuoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }
    }
}