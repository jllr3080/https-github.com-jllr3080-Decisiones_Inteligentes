#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.Inventario.Parametrizacion
{
    public class TipoProductoVistaModelo
    {
        /// <summary>
        /// Id del tipo de  producto
        /// </summary>
        
        public int TipoProductoId { get; set; }

        /// <summary>
        /// Descripcion del color
        /// </summary>
        
        public string Descripcion { get; set; }
    }
}