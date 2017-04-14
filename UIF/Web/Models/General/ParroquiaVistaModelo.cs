#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace Web.Models.General
{
    public class ParroquiaVistaModelo
    {
        /// <summary>
        /// Id de la ciudad
        /// </summary>

        public int ParroquiaId { get; set; }

        /// <summary>
        /// Id de la ciudad
        /// </summary>

        public int? CiudadId { get; set; }

        /// <summary>
        /// Id del Pais
        /// </summary>

        public int? PaisId { get; set; }

        /// <summary>
        /// Id del estado
        /// </summary>

        public int? EstadoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>

        public string Descripcion { get; set; }
    }
}