#region  using

using System;
using System.Runtime.Serialization;
using  modeloGeneral=JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.Individuo.Servicio.Modelo
{
    /// <summary>
    ///  Modelo del Individuo
    /// </summary>
    [DataContract]
    public class IndividuoModelo
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        [DataMember]
        public int IndividuoId { get; set; }

        /// <summary>
        /// Tipo de identificacion
        /// </summary>
        [DataMember]
        public modeloGeneral.TipoIdentificacionModelo TipoIdentificacion { get; set; }

        /// <summary>
        /// Tipo de individuo
        /// </summary>
        [DataMember]
        public modeloGeneral.TipoIndividuoModelo TipoIndividuo { get; set; }

        /// <summary>
        /// Tipo de rol individuo
        /// </summary>
        [DataMember]
        public modeloGeneral.TipoRolIndividuoModelo TipoRolIndividuo { get; set; }

        /// <summary>
        /// PrimerCampo
        /// </summary>
        [DataMember]
        public string PrimerCampo { get; set; }

        /// <summary>
        /// Segundo Campo
        /// </summary>
        [DataMember]
        public string SegundoCampo { get; set; }

        /// <summary>
        /// Tercer Campo
        /// </summary>
        [DataMember]
        public string TercerCampo { get; set; }

        /// <summary>
        /// Cuarto Campo
        /// </summary>
        [DataMember]
        public string CuartoCampo { get; set; }

        /// <summary>
        /// NumeroIdentificacion
        /// </summary>
        [DataMember]
        public string NumeroIdentificacion { get; set; }

        /// <summary>
        /// Habilitado
        /// </summary>
        [DataMember]
        public bool? Habilitado { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// FechaModificacion
        /// </summary>
        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// UsuarioId
        /// </summary>
        [DataMember]
        public int? UsuarioId { get; set; }

    }
}