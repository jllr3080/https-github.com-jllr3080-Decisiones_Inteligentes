using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCliente.DTOs.Seguridad
{
    public class AccesoVistaDTOs
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
        public string Url { get; set; }
    }
}