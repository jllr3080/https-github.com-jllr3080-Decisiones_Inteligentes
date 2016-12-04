#region using
using System.Runtime.Serialization;
#endregion


namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// Modelo de tipo de rol de individuo
    /// </summary>
    [DataContract]
    public class TipoRolIndividuoModelo
    {
        /// <summary>
        /// Id del tipo de el rol del individuo
        /// </summary>
        [DataMember]
        public int TipoRolIndividuoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

    }
}