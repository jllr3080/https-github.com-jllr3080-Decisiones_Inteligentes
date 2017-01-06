#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{


    public class FormaPagoVistaModelo
    {
        /// <summary>
        /// FormaPagoId
        /// </summary>
        
        public int FormaPagoId { get; set; }

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