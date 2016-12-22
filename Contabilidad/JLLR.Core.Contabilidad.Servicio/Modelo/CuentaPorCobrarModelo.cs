#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.Contabilidad.Servicio.Modelo
{
    /// <summary>
    /// Modelo de  cuenta por pagar
    /// </summary>
    [DataContract]
    public class CuentaPorCobrarModelo
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public Int64 CuentaPorCobrarId { get; set; }

        /// <summary>
        /// IndividuoId
        /// </summary>
        [DataMember]
        public Int64? IndividuoId{ get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion{ get; set; }


        /// <summary>
        /// UsuarioId
        /// </summary>
        [DataMember]
        public int? UsuarioId { get; set; }


        /// <summary>
        /// EstadoCuentaPorSucursal
        /// </summary>
        [DataMember]
        public bool? EstadoCuentaPorSucursal{ get; set; }

        /// <summary>
        /// SucursalId
        /// </summary>
        [DataMember]
        public int? SucursalId{ get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        [DataMember]
        public int? PuntoVentaId { get; set; }

        /// <summary>
        /// EstadoCuentaPorPuntoVenta
        /// </summary>
        [DataMember]
        public bool? EstadoCuentaPorPuntoVenta { get; set; }
    }
}