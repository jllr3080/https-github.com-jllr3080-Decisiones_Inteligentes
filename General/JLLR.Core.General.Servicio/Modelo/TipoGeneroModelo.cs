#region using
using System.Runtime.Serialization;
#endregion

namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// Modelo de tipo de Genero
    /// </summary>
    [DataContract]
    public class TipoGeneroModelo
    {
        /// <summary>
        /// Id del tipo de Genero
        /// </summary>
        [DataMember]
        public int TipoGeneroId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

      
    }
}