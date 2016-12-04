#region using
using System.Runtime.Serialization;
#endregion

namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Modelo de tipo de direccion
    /// </summary>
    [DataContract]
    public class TipoDireccionModelo
    {
        /// <summary>
        /// Id del tipo de  direccion domiciliaria
        /// </summary>
        [DataMember]
        public int TipoDireccionId { get; set; }

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