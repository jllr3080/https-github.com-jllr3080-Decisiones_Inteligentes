using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Individuo;

namespace Web.DTOs.Individuo
{
    public class ClienteGeneralVistaDTOs
    {

        /// <summary>
        /// Cliente
        /// </summary>
        
        public ClienteVistaModelo Cliente { get; set; }

        /// <summary>
        /// Individuo
        /// </summary>
        
        public IndividuoVistaModelo Individuo { get; set; }

        /// <summary>
        /// Direcion
        /// </summary>
        
        public DireccionVistaModelo Direccion { get; set; }

        /// <summary>
        /// Telefono
        /// </summary>
        
        public TelefonoVistaModelo Telefono { get; set; }

        /// <summary>
        /// CorreoElectronico
        /// </summary>
        
        public CorreoElectronicoVistaModelo CorreoElectronico { get; set; }

        /// <summary>
        /// IndividuoRol
        /// </summary>

        public IndividuoRolVistaModelo IndividuoRol { get; set; }
    }
}