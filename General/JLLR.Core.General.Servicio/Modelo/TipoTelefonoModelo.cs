#region using
using System.Runtime.Serialization;
#endregion


namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// Modelo de tipo de telefono
    /// </summary>
    [DataContract]
    public class TipoTelefonoModelo
    {
        /// <summary>
        /// Id del tipo de telefono
        /// </summary>
        [DataMember]
        public int TipoTelefonoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// Por Defecto
        /// </summary>
        [DataMember]
        public bool? PorDefecto{ get; set; }
    }
}