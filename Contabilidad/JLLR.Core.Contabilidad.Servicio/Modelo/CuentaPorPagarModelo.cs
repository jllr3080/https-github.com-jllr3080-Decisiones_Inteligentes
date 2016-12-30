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
    public class CuentaPorPagarModelo
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public Int64 CuentaPorPagarId { get; set; }

        /// <summary>
        /// IndividuoId
        /// </summary>
        [DataMember]
        public Int64? ProveedorId { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaVencimiento { get; set; }


        /// <summary>
        /// UsuarioId
        /// </summary>
        [DataMember]
        public int? UsuarioCreacionId { get; set; }

        /// <summary>
        /// UsuarioId
        /// </summary>
        [DataMember]
        public int? UsuarioModificacionId { get; set; }



        /// <summary>
        /// SucursalId
        /// </summary>
        [DataMember]
        public int? SucursalId { get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        [DataMember]
        public int? PuntoVentaId { get; set; }

        /// <summary>
        /// Saldo
        /// </summary>
        [DataMember]
        public decimal? Saldo { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        [DataMember]
        public decimal? Valor { get; set; }

        /// <summary>
        /// NumeroFactura
        /// </summary>
        [DataMember]
        public string NumeroFactura { get; set; }

        /// <summary>
        /// NumeroFactura
        /// </summary>
        [DataMember]
        public string NumeroOrden { get; set; }
    }
}