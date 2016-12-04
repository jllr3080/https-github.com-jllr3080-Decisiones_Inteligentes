#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.General
{

    /// <summary>
    /// Modelo del Pais
    /// </summary>

    public class PaisVistaModelo
    {

        /// <summary>
        /// Id del Pais
        /// </summary>
        
        public int PaisId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Pais por defecto
        /// </summary>
        
        public bool? PorDefecto { get; set; }
    }
}