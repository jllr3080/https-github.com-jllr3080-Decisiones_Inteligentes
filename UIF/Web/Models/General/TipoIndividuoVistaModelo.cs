#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.General
{
    public class TipoIndividuoVistaModelo
    {

        /// <summary>
        /// Tipo de individuo id
        /// </summary>
        
        public int TipoIndividuoId { get; set; }

        /// <summary>
        /// Descipcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Esta Habilitado
        /// </summary>
        
        public bool? PorDefecto { get; set; }
    }
}