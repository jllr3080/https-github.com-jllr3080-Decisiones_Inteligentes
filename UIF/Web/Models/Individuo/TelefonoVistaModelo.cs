#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using modeloVistaGeneral = Web.Models.General;
#endregion

namespace Web.Models.Individuo
{
    public class TelefonoVistaModelo
    {

        /// <summary>
        /// TelefonoId
        /// </summary>
        
        public int TelefonoId { get; set; }


        /// <summary>
        /// Individuo
        /// </summary>
        
        public IndividuoVistaModelo Individuo { get; set; }

        /// <summary>
        /// TipoTelefono
        /// </summary>
        
        public modeloVistaGeneral.TipoTelefonoVistaModelo TipoTelefono { get; set; }

        /// <summary>
        /// NumeroTelefono
        /// </summary>
        
        public string NumeroTelefono { get; set; }
    }
}