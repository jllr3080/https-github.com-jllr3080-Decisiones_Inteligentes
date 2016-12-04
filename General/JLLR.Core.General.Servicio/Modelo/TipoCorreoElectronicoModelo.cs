#region using
using System.Runtime.Serialization;
#endregion

namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// Modelo del tipo de correo eletronico
    /// </summary>
    [DataContract]
    public class TipoCorreoElectronicoModelo
    {
        /// <summary>
        /// Id del tipo de  correo electronico
        /// </summary>
        [DataMember]
        public int TipoCorreoElectronicoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// Por defecto
        /// </summary>
        [DataMember]
        public bool? PorDefecto { get; set; }
    }
}