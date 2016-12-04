#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.General
{
    /// <summary>
    /// Modelo del estado
    /// </summary>
    public class EstadoVistaModelo
    {


        /// <summary>
        /// Id del Pais
        /// </summary>
       
        public int? PaisId { get; set; }

        /// <summary>
        /// Id del estado
        /// </summary>
        public int EstadoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
    }
}