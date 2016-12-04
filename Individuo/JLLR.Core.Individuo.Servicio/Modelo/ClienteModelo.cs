#region  using

using System;
using System.Runtime.Serialization;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.Individuo.Servicio.Modelo
{
    /// <summary>
    /// Modelo del cliente
    /// </summary>
    [DataContract]
    public class ClienteModelo
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        [DataMember]
        public int ClienteId { get; set; }

        /// <summary>
        /// TipoGenero
        /// </summary>
        [DataMember]
        public modeloGeneral.TipoGeneroModelo TipoGenero{ get; set; }

        /// <summary>
        /// Individuo
        /// </summary>
        [DataMember]
        public IndividuoModelo Individuo { get; set; }

        /// <summary>
        /// FechaNacimiento
        /// </summary>
        [DataMember]
        public DateTime? FechaNacimiento{ get; set; }


    }
}