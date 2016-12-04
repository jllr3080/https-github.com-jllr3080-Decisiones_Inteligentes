#region using

using System.Runtime.Serialization;

#endregion
namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Modelo del estado
    /// </summary>
    [DataContract]
    public class EstadoModelo
    {

        /// <summary>
        /// Id del Pais
        /// </summary>
        [DataMember]
        public int? PaisId { get; set; }

        /// <summary>
        /// Id del estado
        /// </summary>
        [DataMember]
        public int EstadoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }
    }
}