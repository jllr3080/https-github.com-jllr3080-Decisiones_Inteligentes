#region  using
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
    /// DTo  de proveedor
    /// </summary>
    public class ProveedorDTOs
    {     
        /// <summary>
         ///  Individuo
         /// </summary>
        public INDIVIDUO Individuo { get; set; }

        /// <summary>
        /// Proveedor
        /// </summary>
        public PROVEEDOR Proveedor{ get; set; }

        /// <summary>
        /// Direccion del Proveedor 
        /// </summary>
        public DIRECCION Direccion { get; set; }

        /// <summary>
        /// Telefono del Proveedor 
        /// </summary>
        public TELEFONO Telefono { get; set; }

        /// <summary>
        /// Correo electronico del Proveedor 
        /// </summary>
        public E_MAIL CorreoElectronico { get; set; }

        /// <summary>
        /// IndividuoRol
        /// </summary>
        public INDIVIDUO_ROL IndividuoRol { get; set; }
    }
}
