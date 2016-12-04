#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{
    public class MaterialVistaModelo
    {

        /// <summary>
        /// Id del material del producto
        /// </summary>

        public int MaterialId { get; set; }

        /// <summary>
        /// Descripcion 
        /// </summary>

        public string Descripcion { get; set; }

        /// <summary>
        /// Esta habilitado 
        /// </summary>

        public bool? EstaHabilitado { get; set; }
    }
}