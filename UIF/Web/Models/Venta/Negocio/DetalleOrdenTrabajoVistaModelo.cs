#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.General;
using Web.Models.Inventario.Parametrizacion;
using Web.Models.Venta.Parametrizacion;

#endregion

namespace Web.Models.Venta.Negocio
{
    public class DetalleOrdenTrabajoVistaModelo
    {

        /// <summary>
        /// Id del detalle de la orden de  trabajo
        /// </summary>
        
        public int DetalleOrdenTrabajoId { get; set; }


        /// <summary>
        /// Id de la cabecera de la orden de  trabajo
        /// </summary>
        
        public OrdenTrabajoVistaModelo OrdenTrabajo { get; set; }

        /// <summary>
        /// Producto
        /// </summary>
        
        public ProductoVistaModelo Producto { get; set; }

       

        /// <summary>
        /// Impuesto    
        /// </summary>
        
        public ImpuestoVistaModelo Impuesto { get; set; }

        /// <summary>
        /// Cantidad  de  prensdas 
        /// </summary>
        
        public decimal? Cantidad { get; set; }

        /// <summary>
        /// Valor Unitario de las prendas
        /// </summary>
        
        public decimal? ValorUnitario { get; set; }

        /// <summary>
        /// Porcentaje de impuesto
        /// </summary>
        
        public decimal? PorcentajeImpuesto { get; set; }

        /// <summary>
        /// Valor total + iva
        /// </summary>
        
        public decimal? ValorTotal { get; set; }

       
        /// <summary>
        /// ProductoTalla
        /// </summary>
        
        public ProductoTallaVistaModelo ProductoTalla { get; set; }

       

        /// <summary>
        /// VentaComision
        /// </summary>
        
        public VentaComisionVistaModelo VentaComision { get; set; }

       


        /// <summary>
        /// DetallePrendaOrdenTrabajo
        /// </summary>
        
        public List<DetallePrendaOrdenTrabajoVistaModelo> DetallePrendaOrdenTrabajo { get; set; }

       
        /// <summary>
        /// Suavizante
        /// </summary>
        
        public bool? Suavizante { get; set; }

        /// <summary>
        /// Desengrasante
        /// </summary>
        
        public bool? Desengrasante { get; set; }


        /// <summary>
        /// FijadorColor
        /// </summary>
        
        public bool? FijadorColor { get; set; }

       
        /// <summary>
        /// ValorTotalUnitario
        /// </summary>
        
        public decimal? ValorTotalUnitario { get; set; }

        /// <summary>
        /// ValorTotalDescuento
        /// </summary>
        public decimal? ValorDescuento { get; set; }

        /// <summary>
        /// ValorTotalDescuento
        /// </summary>
        public int? PromocionAplicada { get; set; }

        /// <summary>
        /// ValorTotalDescuento
        /// </summary>
        public string NombrePromocionAplicada { get; set; }
    }
}