#region  using

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
        /// Producto
        /// </summary>
        [DataMember]
        public General.Servicio.Modelo.ColorModelo Color { get; set; }

        /// <summary>
        /// Impuesto    
        /// </summary>
        [DataMember]
        public ImpuestoModelo Impuesto{ get; set; }

        /// <summary>
        /// Cantidad  de  prensdas 
        /// </summary>
        [DataMember]
        public int? Cantidad{ get; set; }

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
        /// Valor total + iva
        /// </summary>
        [DataMember]
        public decimal? ValorTotal { get; set; }

        /// <summary>
        /// Observacion
        /// </summary>
        [DataMember]
        public string Observacion{ get; set; }

        /// <summary>
        /// ProductoTalla
        /// </summary>
        [DataMember]
        public ProductoTallaModelo ProductoTalla { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        [DataMember]
        public MarcaModelo Marca { get; set; }

        /// <summary>
        /// Material
        /// </summary>
        [DataMember]
        public MaterialModelo Material { get; set; }

        /// <summary>
        /// VentaComision
        /// </summary>
        [DataMember]
        public VentaComisionModelo VentaComision { get; set; }

        /// <summary>
        /// DetalleOrdenTrabajoObservacion
        /// </summary>
        [DataMember]
        public List<DetalleOrdenTrabajoObservacionModelo> DetalleOrdenTrabajoObservacion { get; set;  }
    }
}