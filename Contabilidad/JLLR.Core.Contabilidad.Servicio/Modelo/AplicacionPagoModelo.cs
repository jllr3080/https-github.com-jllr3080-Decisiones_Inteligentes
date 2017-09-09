#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.Contabilidad.Servicio.Modelo
{
    [DataContract]
    public class AplicacionPagoModelo
    {

        /// <summary>
        /// AprobacionPagoId
        /// </summary>
        [DataMember]
        public int AplicacionPagoId { get; set; }

        /// <summary>
        /// CierreMes
        /// </summary>
        [DataMember]
        public CierreMesModelo CierreMes{ get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        [DataMember]
        public decimal? Valor { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion { get; set; }


        /// <summary>
        /// EstaValidado
        /// </summary>
        [DataMember]
        public bool? EstaValidado { get; set; }

        /// <summary>
        /// NumeroDocumento
        /// </summary>
        [DataMember]
        public string NumeroDocumento { get; set; }

        /// <summary>
        /// NumeroDocumento
        /// </summary>
        [DataMember]
        public DateTime? FechaDeposito { get; set; }

        /// <summary>
        /// FechaValidacion
        /// </summary>
        [DataMember]
        public DateTime? FechaValidacion { get; set; }

        /// <summary>
        /// FechaValidacion
        /// </summary>
        [DataMember]
        public byte[] Documento { get; set; }


        /// <summary>
        /// UsuarioAplicaId
        /// </summary>
        [DataMember]
        public int?  UsuarioAplicaId { get; set; }

        /// <summary>
        /// UsuarioValidaId
        /// </summary>
        [DataMember]
        public int? UsuarioValidaId { get; set; }
    }
}