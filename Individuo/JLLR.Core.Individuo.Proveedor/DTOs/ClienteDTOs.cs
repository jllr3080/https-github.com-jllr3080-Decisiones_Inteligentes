#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.Individuo.Proveedor.DTOs
{
    /// <summary>
    /// Datos del cliente 
    /// </summary>
    public class ClienteDTOs
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        public int? ClienteId { get; set; }

        /// <summary>
        /// Id del individuo
        /// </summary>
        public int? IndividuoId { get; set; }

        /// <summary>
        /// Nombre completo del cliente
        /// </summary>
        public string NombreCompleto{ get; set; }

        /// <summary>
        /// Direccion completa del cliente
        /// </summary>
        public string DireccionCliente { get; set; }

        /// <summary>
        /// Telefono del cliente
        /// </summary>
        public string TelefonoCliente { get; set; }



    }
}
