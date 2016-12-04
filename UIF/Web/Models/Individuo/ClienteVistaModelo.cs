#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using modeloVistaGeneral=Web.Models.General;
#endregion

namespace Web.Models.Individuo
{
    public class ClienteVistaModelo
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        
        public int ClienteId { get; set; }

        /// <summary>
        /// TipoGenero
        /// </summary>
        
        public modeloVistaGeneral.TipoGeneroVistaModelo TipoGenero { get; set; }

        /// <summary>
        /// Individuo
        /// </summary>
        
        public IndividuoVistaModelo Individuo { get; set; }

        /// <summary>
        /// FechaNacimiento
        /// </summary>
        
        public DateTime? FechaNacimiento { get; set; }
    }
}