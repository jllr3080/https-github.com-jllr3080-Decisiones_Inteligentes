#region  using

using System;
using System.Runtime.Serialization;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
#endregion

namespace JLLR.Core.Individuo.Servicio.Modelo
{
    /// <summary>
    /// Telefono modelo
    /// </summary>
    [DataContract]
    public class TelefonoModelo
    {

        /// <summary>
        /// TelefonoId
        /// </summary>
        [DataMember]
        public int TelefonoId { get; set; }


        /// <summary>
        /// Individuo
        /// </summary>
        [DataMember]
        public IndividuoModelo Individuo { get; set; }

        /// <summary>
        /// TipoTelefono
        /// </summary>
        [DataMember]
        public modeloGeneral.TipoTelefonoModelo TipoTelefono { get; set; }

        /// <summary>
        /// NumeroTelefono
        /// </summary>
        [DataMember]
        public string NumeroTelefono { get; set; }
    }
}