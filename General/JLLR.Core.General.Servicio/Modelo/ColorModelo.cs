#region using

using System.Runtime.Serialization;

#endregion
namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// MOdelo de  color
    /// </summary>
    [DataContract]
    public class ColorModelo
    {
        /// <summary>
        /// Id del color
        /// </summary>
        [DataMember]
        public int ColorId { get; set; }

        /// <summary>
        /// Descripcion del color
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// Esta habilitado del color
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado { get; set; }
    }
}