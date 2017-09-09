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

        /// <summary>
        /// NombreCompleto
        /// </summary>

        public string NombreCompleto{ get; set; }


        /// <summary>
        /// DireccionCompleta
        /// </summary>

        public string DireccionCompleta { get; set; }

        // <summary>
        /// Telefono del cliente 
        /// </summary>
        public List<TelefonoVistaModelo> Telefonos { get; set; }


    }
}