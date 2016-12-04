#region  using

using System.Runtime.Serialization;

#endregion
namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Tipo de  lavado
    /// </summary>
    [DataContract]
    public class TipoLavadoModelo
    {

        /// <summary>
        /// Tipo de lavado id
        /// </summary>
        [DataMember]
        public int TipoLavadoId { get; set; }

        /// <summary>
        /// Descipcion
        /// </summary>
        [DataMember]
        public string Descripcion{ get; set; }

        /// <summary>
        /// Esta Habilitado
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado{ get; set; }

    }
}