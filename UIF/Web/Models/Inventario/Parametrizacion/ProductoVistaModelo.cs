#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.General;
#endregion
namespace Web.Models.Inventario.Parametrizacion
{
    public class ProductoVistaModelo
    {
        /// <summary>
        /// Id del color
        /// </summary>
   
        public int ProductoId { get; set; }

        /// <summary>
        /// TipoProducto
        /// </summary>
     
        public TipoProductoVistaModelo TipoProducto { get; set; }

        /// <summary>
        /// Material
        /// </summary>
        
        public MaterialVistaModelo Material { get; set; }

        /// <summary>
        /// modelo
        /// </summary>
        
        public ModeloVistaModelo Modelo { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
      
        public MarcaVistaModelo Marca { get; set; }


        /// <summary>
        /// Descripcion del producto
        /// </summary>
      
        public string Nombre { get; set; }


        /// <summary>
        /// Fecha de creacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// PedirMedida
        /// </summary>

        public bool? PedirMedida { get; set; }
    }
}