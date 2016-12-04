#region using
using System.Runtime.Serialization;
#endregion

namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// Modelo de tipo de identificacion
    /// </summary>
    [DataContract]
    public class TipoIdentificacionModelo
    {
        /// <summary>
        /// Id del tipo de Identificacion
        /// </summary>
        [DataMember]
        public int TipoIdentificacionId { get; set; }

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


        /// <summary>
        ///Tipo de  identificacion en el SRI
        /// </summary>
        [DataMember]
        public string TipoIdentificacionSri{ get; set; }
    }
}