#region using

using System;
using System.Runtime.Serialization;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion
{
    /// <summary>
    /// Modelo de producto precio
    /// </summary>
    [DataContract]
    public class ProductoPrecioModelo
    {
        /// <summary>
        /// ProductoPrecioId
        /// </summary>
        [DataMember]
        public int ProductoPrecioId { get; set; }

        /// <summary>
        /// Producto
        /// </summary>
        [DataMember]
        public ProductoModelo Producto { get; set; }

      
        /// <summary>
        /// Precio
        /// </summary>
        [DataMember]
        public decimal? Precio { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        [DataMember]
        public Boolean? EstaHabilitado { get; set; }

        /// <summary>
        /// Modificable
        /// </summary>
        [DataMember]
        public Boolean? Modificable { get; set; }


    }
}