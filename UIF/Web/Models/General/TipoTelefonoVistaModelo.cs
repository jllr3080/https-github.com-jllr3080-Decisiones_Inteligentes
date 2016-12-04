#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.General
{
    public class TipoTelefonoVistaModelo
    {
        /// <summary>
        /// Id del tipo de telefono
        /// </summary>
        
        public int TipoTelefonoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Por Defecto
        /// </summary>
        
        public bool? PorDefecto { get; set; }
    }
}