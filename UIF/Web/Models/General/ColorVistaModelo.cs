#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.General
{
    public class ColorVistaModelo
    {
        /// <summary>
        /// Id del color
        /// </summary>

        public int ColorId { get; set; }

        /// <summary>
        /// Descripcion del color
        /// </summary>

        public string Descripcion { get; set; }

        /// <summary>
        /// Esta habilitado del color
        /// </summary>

        public bool? EstaHabilitado { get; set; }
    }
}