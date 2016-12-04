#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{
    public class TipoCorreoElectronicoVistaModelo
    {
        /// <summary>
        /// Id del tipo de  correo electronico
        /// </summary>
        
        public int TipoCorreoElectronicoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Por defecto
        /// </summary>
        
        public bool? PorDefecto { get; set; }
    }
}