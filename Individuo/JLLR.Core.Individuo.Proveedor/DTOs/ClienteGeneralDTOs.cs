#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Individuo.Proveedor.DTOs
{
    /// <summary>
    /// Cliente  
    /// </summary>
    public class ClienteGeneralDTOs
    {
        /// <summary>
        ///  Individuo
        /// </summary>
        public INDIVIDUO Individuo { get; set; }

        /// <summary>
        /// Cliente
        /// </summary>
        public CLIENTE Cliente { get; set; }

        /// <summary>
        /// Direccion del cliente 
        /// </summary>
        public DIRECCION Direccion { get; set; }

        /// <summary>
        /// Telefono del cliente 
        /// </summary>
        public TELEFONO Telefono  { get; set; }

        /// <summary>
        /// Correo electronico del cliente 
        /// </summary>
        public E_MAIL CorreoElectronico { get; set; }

        /// <summary>
        /// IndividuoRol
        /// </summary>
        public INDIVIDUO_ROL IndividuoRol { get; set; }
    }
}
