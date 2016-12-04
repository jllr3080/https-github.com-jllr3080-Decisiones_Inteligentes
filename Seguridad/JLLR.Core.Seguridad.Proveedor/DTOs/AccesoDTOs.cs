#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace JLLR.Core.Seguridad.Proveedor.DTOs
{
    /// <summary>
    /// DTO que  genera el menu
    /// </summary>
    public class AccesoDTOs
    {
        /// <summary>
        /// Id  del modulo
        /// </summary>
        public int? ModuloId { get; set; }


        /// <summary>
        /// Descripcion del modulo
        /// </summary>
        public string Modulo { get; set; }

        /// <summary>
        /// Id  del Submodulo
        /// </summary>
        public int? SubmoduloId { get; set; }

        /// <summary>
        /// Descripcion del Submodulo
        /// </summary>
        public string SubModulo { get; set; }

        /// <summary>
        /// Id  del Acceso
        /// </summary>
        public int? AccesoId { get; set; }


        /// <summary>
        /// Descripcion del Acceso
        /// </summary>
        public string Acceso { get; set; }


        /// <summary>
        /// Direccion de la pagina
        /// </summary>
        public string Url{ get; set; }

    }
}
