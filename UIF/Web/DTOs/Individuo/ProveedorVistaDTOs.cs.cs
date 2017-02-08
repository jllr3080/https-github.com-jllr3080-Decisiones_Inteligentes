#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Individuo;

#endregion

namespace Web.DTOs.Individuo
{

    /// <summary>
    /// DTO proveedor
    /// </summary>
    public class ProveedorVistaDTOs
    {
        /// <summary>
        ///  Individuo
        /// </summary>
        public IndividuoVistaModelo Individuo { get; set; }

        /// <summary>
        /// Proveedor
        /// </summary>
        public ProveedorVistaModelo Proveedor { get; set; }

        /// <summary>
        /// Direccion del Proveedor 
        /// </summary>
        public DireccionVistaModelo Direccion { get; set; }

        /// <summary>
        /// Telefono del Proveedor 
        /// </summary>
        public TelefonoVistaModelo Telefono { get; set; }

        /// <summary>
        /// Correo electronico del Proveedor 
        /// </summary>
        public CorreoElectronicoVistaModelo CorreoElectronico { get; set; }

        /// <summary>
        /// IndividuoRol
        /// </summary>
        public IndividuoRolVistaModelo IndividuoRol { get; set; }
    }
}