#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General;
#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Inventario
{
  public  class ProductoVistaModelo
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

        /// <summary>
        /// Visible
        /// </summary>
    
        public bool? Visible { get; set; }

        /// <summary>
        /// TiempoEntrega
        /// </summary>
    
        public int? TiempoEntrega { get; set; }

        /// <summary>
        /// PrendaEspecial
        /// </summary>
    
        public bool? PrendaEspecial { get; set; }


        /// <summary>
        /// NumeroPrendas
        /// </summary>
    
        public int? NumeroPrendas { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
    
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
    
        public int? UsuarioId { get; set; }
    }
}
