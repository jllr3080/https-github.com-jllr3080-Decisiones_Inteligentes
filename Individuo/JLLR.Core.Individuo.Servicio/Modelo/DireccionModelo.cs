#region  using

using System;
using System.Runtime.Serialization;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
#endregion

namespace JLLR.Core.Individuo.Servicio.Modelo
{
    /// <summary>
    /// Modelo de  direccion
    /// </summary>
    [DataContract]
    public class DireccionModelo
    {
        /// <summary>
        /// DireccionId
        /// </summary>
        [DataMember]
        public int DireccionId { get; set; }


        /// <summary>
        /// Individuo
        /// </summary>
        [DataMember]
        public IndividuoModelo Individuo { get; set; }

        /// <summary>
        /// TipoDireccion
        /// </summary>
        [DataMember]
        public modeloGeneral.TipoDireccionModelo TipoDireccion { get; set; }

        /// <summary>
        /// Pais
        /// </summary>
        [DataMember]
        public modeloGeneral.PaisModelo Pais { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [DataMember]
        public modeloGeneral.EstadoModelo Estado{ get; set; }

        /// <summary>
        /// Ciudad
        /// </summary>
        [DataMember]
        public modeloGeneral.CiudadModelo Ciudad { get; set; }

        /// <summary>
        /// Parroquia
        /// </summary>
        [DataMember]
        public modeloGeneral.ParroquiaModelo Parroquia { get; set; }


        /// <summary>
        /// DescripcionDireccion
        /// </summary>
        [DataMember]
        public string DescripcionDireccion { get; set; }

        /// <summary>
        /// CallePrincipal
        /// </summary>
        [DataMember]
        public string CallePrincipal { get; set; }

        /// <summary>
        /// CalleSecundaria
        /// </summary>
        [DataMember]
        public string CalleSecundaria { get; set; }

        /// <summary>
        /// NumeroCasa
        /// </summary>
        [DataMember]
        public string NumeroCasa { get; set; }


        /// <summary>
        /// Referencia
        /// </summary>
        [DataMember]
        public string Referencia { get; set; }
    }
}