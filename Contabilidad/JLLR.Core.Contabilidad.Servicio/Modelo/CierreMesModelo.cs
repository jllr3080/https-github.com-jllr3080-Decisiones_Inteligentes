#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.Web;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Seguridad.Servicio.Modelo;

#endregion

namespace JLLR.Core.Contabilidad.Servicio.Modelo
{
    [DataContract]
    public class CierreMesModelo
    {
        /// <summary>
        /// Cierre Mes Id
        /// </summary>
        [DataMember]
        public int CierreMesId { get; set; }

        /// <summary>
        /// Sucursal
        /// </summary>
        [DataMember]
        public SucursalModelo Sucursal { get; set; }

        /// <summary>
        /// PuntoVenta
        /// </summary>
        [DataMember]
        public PuntoVentaModelo PuntoVenta { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        [DataMember]
        public UsuarioModelo Usuario { get; set; }


        /// <summary>
        /// CuentaPorPagar
        /// </summary>
        [DataMember]
        public CuentaPorPagarModelo CuentaPorPagar { get; set; }

        /// <summary>
        /// Mes
        /// </summary>
        [DataMember]
        public MesModelo Mes { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        [DataMember]
        public decimal? Valor { get; set; }
    }
}