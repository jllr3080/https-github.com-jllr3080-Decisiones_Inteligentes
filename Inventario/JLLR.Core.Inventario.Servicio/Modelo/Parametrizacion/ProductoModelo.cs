#region using

using System;
using System.Runtime.Serialization;
using  modeloGeneral= JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion
{

    /// <summary>
    /// MOdelo del producto
    /// </summary>
    [DataContract]
    public class ProductoModelo
    {
        /// <summary>
        /// Id del color
        /// </summary>
        [DataMember]
        public int ProductoId { get; set; }

        /// <summary>
        /// TipoProducto
        /// </summary>
        [DataMember]
        public TipoProductoModelo TipoProducto { get; set; }

        /// <summary>
        /// Material
        /// </summary>
        [DataMember]
        public modeloGeneral.MaterialModelo Material { get; set; }

        /// <summary>
        /// modelo
        /// </summary>
        [DataMember]
        public modeloGeneral.ModeloModelo Modelo { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        [DataMember]
        public modeloGeneral.MarcaModelo Marca { get; set; }


        /// <summary>
        /// Descripcion del producto
        /// </summary>
        [DataMember]
        public string Nombre { get; set; }

        
        /// <summary>
        /// Fecha de creacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// PedirMedida
        /// </summary>
        [DataMember]
        public bool? PedirMedida { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        [DataMember]
        public bool? Visible{ get; set; }

        /// <summary>
        /// TiempoEntrega
        /// </summary>
        [DataMember]
        public int? TiempoEntrega { get; set; }

        /// <summary>
        /// PrendaEspecial
        /// </summary>
        [DataMember]
        public bool? PrendaEspecial { get; set; }

    }

}