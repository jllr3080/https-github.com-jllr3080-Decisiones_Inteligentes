#region using

using System;
using System.Runtime.Serialization;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion
{
    /// <summary>
    /// Modelo de  producto talla
    /// </summary>
    [DataContract]
    public class ProductoTallaModelo
    {

        /// <summary>
        /// ProductoTallaId
        /// </summary>
        [DataMember]
        public int ProductoTallaId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// Producto
        /// </summary>
        [DataMember]
        public ProductoModelo Producto { get; set; }
    }
}