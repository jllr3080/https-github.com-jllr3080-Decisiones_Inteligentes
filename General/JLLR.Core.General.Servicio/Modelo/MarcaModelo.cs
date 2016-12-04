#region using

using System.ComponentModel;
using System.Runtime.Serialization;
#endregion
namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// Modelo de  marca
    /// </summary>
    [DataContract]
    public class MarcaModelo
    {

        /// <summary>
        /// Id de la marca del producto
        /// </summary>
        [DataMember]
        public int MarcaId { get; set; }

        /// <summary>
        /// Descripcion 
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// Esta habilitado 
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado { get; set; }
    }
}