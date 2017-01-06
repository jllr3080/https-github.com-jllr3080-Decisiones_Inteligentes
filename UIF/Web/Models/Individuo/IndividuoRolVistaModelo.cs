#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.General;

#endregion

namespace Web.Models.Individuo
{
    public class IndividuoRolVistaModelo
    {

        /// <summary>
        /// IndividuoRolId
        /// </summary>
        
        public int IndividuoRolId { get; set; }

        /// <summary>
        /// Tipo de rol individuo
        /// </summary>
        
        public TipoRolIndividuoVistaModelo TipoRolIndividuo { get; set; }

        /// <summary>
        /// IndividuoId
        /// </summary>
        
        public int? IndividuoId { get; set; }
    }
}