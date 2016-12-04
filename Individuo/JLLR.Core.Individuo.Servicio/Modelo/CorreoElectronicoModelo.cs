#region  using

using System;
using System.Runtime.Serialization;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
#endregion

namespace JLLR.Core.Individuo.Servicio.Modelo
{
    /// <summary>
    /// Correo electronico modelo
    /// </summary>
    [DataContract]
    public class CorreoElectronicoModelo
    {
        /// <summary>
        /// CorreoElectronicoId
        /// </summary>
        [DataMember]
        public int CorreoElectronicoId { get; set; }

       
        /// <summary>
        /// Individuo
        /// </summary>
        [DataMember]
        public IndividuoModelo Individuo { get; set; }

        /// <summary>
        /// TipoCorreoElectronico
        /// </summary>
        [DataMember]
        public modeloGeneral.TipoCorreoElectronicoModelo TipoCorreoElectronico { get; set; }

        /// <summary>
        /// DireccionCorreoElectronico
        /// </summary>
        [DataMember]
        public string DireccionCorreoElectronico{ get; set; }
    }
}