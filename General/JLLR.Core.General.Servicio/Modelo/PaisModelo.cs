#region using
using System.Runtime.Serialization;
#endregion

namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Modelo del Pais
    /// </summary>
    [DataContract]
    public class PaisModelo
    {
        /// <summary>
        /// Id del Pais
        /// </summary>
        [DataMember]
        public int PaisId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// Pais por defecto
        /// </summary>
        [DataMember]
        public bool? PorDefecto{ get; set; }
    }
}