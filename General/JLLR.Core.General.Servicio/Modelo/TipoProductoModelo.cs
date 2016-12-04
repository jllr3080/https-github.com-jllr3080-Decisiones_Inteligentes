#region using
using System.Runtime.Serialization;
#endregion
namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Modelo del tipo de producto
    /// </summary>
    [DataContract]
    public class TipoProductoModelo
    {
        /// <summary>
        /// Id del tipo de  producto
        /// </summary>
        [DataMember]
        public int TipoProductoId { get; set; }

        /// <summary>
        /// Descripcion del color
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }
    }
}