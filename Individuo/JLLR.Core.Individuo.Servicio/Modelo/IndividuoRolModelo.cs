#region  using
using System;
using System.Runtime.Serialization;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
#endregion

namespace JLLR.Core.Individuo.Servicio.Modelo
{
    /// <summary>
    /// Modelo  del individuo rol   
    /// </summary>
    [DataContract]
    public class IndividuoRolModelo
    {
        /// <summary>
        /// IndividuoRolId
        /// </summary>
        [DataMember]
        public int IndividuoRolId    { get; set; }

        /// <summary>
        /// Tipo de rol individuo
        /// </summary>
        [DataMember]
        public modeloGeneral.TipoRolIndividuoModelo TipoRolIndividuo { get; set; }

        /// <summary>
        /// IndividuoId
        /// </summary>
        [DataMember]
        public int? IndividuoId { get; set; }
    }
}