#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.Inventario.Parametrizacion
{
    public class ProductoTallaVistaModelo
    {

        /// <summary>
        /// ProductoTallaId
        /// </summary>
        
        public int ProductoTallaId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Producto
        /// </summary>
        
        public ProductoVistaModelo Producto { get; set; }
    }
}