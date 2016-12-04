#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{
    public class TipoIdentificacionVistaModelo
    {
        /// <summary>
        /// Id del tipo de Identificacion
        /// </summary>
        
        public int TipoIdentificacionId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Por Defecto
        /// </summary>
        
        public bool? PorDefecto { get; set; }


        /// <summary>
        ///Tipo de  identificacion en el SRI
        /// </summary>
        
        public string TipoIdentificacionSri { get; set; }
    }
}