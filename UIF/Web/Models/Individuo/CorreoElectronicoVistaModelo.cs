#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using modeloVistaGeneral = Web.Models.General;
#endregion


namespace Web.Models.Individuo
{
    public class CorreoElectronicoVistaModelo
    {

        /// <summary>
        /// CorreoElectronicoId
        /// </summary>
        
        public int CorreoElectronicoId { get; set; }


        /// <summary>
        /// Individuo
        /// </summary>
        
        public IndividuoVistaModelo Individuo { get; set; }

        /// <summary>
        /// TipoCorreoElectronico
        /// </summary>
        
        public modeloVistaGeneral.TipoCorreoElectronicoVistaModelo TipoCorreoElectronico { get; set; }

        /// <summary>
        /// DireccionCorreoElectronico
        /// </summary>
        
        public string DireccionCorreoElectronico { get; set; }
    }
}