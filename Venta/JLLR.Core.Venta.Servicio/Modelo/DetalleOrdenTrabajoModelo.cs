#region  using

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion;
using JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;

#endregion
namespace JLLR.Core.Venta.Servicio.Modelo
{
    /// <summary>
    /// Detalle de  orden de trabajo 
    /// </summary>
    [DataContract]
    public class DetalleOrdenTrabajoModelo
    {
        /// <summary>
        /// Id del detalle de la orden de  trabajo
        /// </summary>
        [DataMember]
        public int DetalleOrdenTrabajoId { get; set; }


        /// <summary>
        /// Id de la cabecera de la orden de  trabajo
        /// </summary>
        [DataMember]
        public OrdenTrabajoModelo OrdenTrabajo{ get; set; }

        /// <summary>
        /// Producto
        /// </summary>
        [DataMember]
        public ProductoModelo Producto { get; set; }

        
        /// <summary>
        /// Impuesto    
        /// </summary>
        [DataMember]
        public ImpuestoModelo Impuesto{ get; set; }

        /// <summary>
        /// Cantidad  de  prensdas 
        /// </summary>
        [DataMember]
        public Decimal? Cantidad{ get; set; }

        /// <summary>
        /// Valor Unitario de las prendas
        /// </summary>
        [DataMember]
        public decimal? ValorUnitario{ get; set; }

        /// <summary>
        /// Porcentaje de impuesto
        /// </summary>
        [DataMember]
        public decimal? PorcentajeImpuesto { get; set; }


        /// <summary>
        /// ValorImpuesto
        /// </summary>
        [DataMember]
        public decimal? ValorImpuesto { get; set; }

        /// <summary>
        /// Valor total + iva
        /// </summary>
        [DataMember]
        public decimal? ValorTotal { get; set; }

        
       
        
        /// <summary>
        /// VentaComision
        /// </summary>
        [DataMember]
        public VentaComisionModelo VentaComision { get; set; }

       

        /// <summary>
        /// Suavizante
        /// </summary>
        [DataMember]
        public bool? Suavizante{ get; set; }

        /// <summary>
        /// Desengrasante
        /// </summary>
        [DataMember]
        public bool? Desengrasante { get; set; }


        /// <summary>
        /// FijadorColor
        /// </summary>
        [DataMember]
        public bool? FijadorColor { get; set; }

        /// <summary>
        /// ValorTotalUnitario
        /// </summary>
        [DataMember]
        public decimal? ValorTotalUnitario { get; set; }

        /// <summary>
        /// ValorTotalDescuento
        /// </summary>
        [DataMember]
        public decimal? ValorDescuento { get; set; }

        /// <summary>
        /// ValorTotalDescuento
        /// </summary>
        [DataMember]
        public int? PromocionAplicada { get; set; }

      
        /// <summary>
        /// DetallePrendaOrdenTrabajo
        /// </summary>
        [DataMember]
        public List<DetallePrendaOrdenTrabajoModelo> DetallePrendaOrdenTrabajo { get; set; }

     
        
        /// <summary>
        /// SoloPlanchado
        /// </summary>
        [DataMember]
        public bool? SoloPlanchado { get; set; }

        /// <summary>
        /// PorcentajeAdicional
        /// </summary>
        [DataMember]
        public bool? PorcentajeAdicional { get; set; }

        /// <summary>
        /// DetalleOrdenTrabajoAnuladaId
        /// </summary>
        [DataMember]
        public int? DetalleOrdenTrabajoAnuladaId { get; set; }


        /// <summary>
        /// EstaAulada
        /// </summary>
        [DataMember]
        public bool? EstaAulada { get; set; }
    }
}