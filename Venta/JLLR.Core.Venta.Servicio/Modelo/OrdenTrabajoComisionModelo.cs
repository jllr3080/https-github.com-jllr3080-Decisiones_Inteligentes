#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;
using System.Web;
using JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;

#endregion

namespace JLLR.Core.Venta.Servicio.Modelo
{

    /// <summary>
    /// Modelo de  orden de trabajo de comision
    /// </summary>

        [DataContract]
    public class OrdenTrabajoComisionModelo
    {
        /// <summary>
        /// Id de la orden de trabajo de la comision
        /// </summary>
        [DataMember]
        public Int64 OrdenTrabajoComisionId { get; set; }

        /// <summary>
        /// Venta de la comision  modelo
        /// </summary>
        [DataMember]
        public VentaComisionModelo VentaComision { get; set; }


        /// <summary>
        /// DetalleOrdenTrabajo
        /// </summary>
        [DataMember]
        public DetalleOrdenTrabajoModelo DetalleOrdenTrabajo{ get; set; }

        /// <summary>
        /// FechaGeneracionComision
        /// </summary>
        [DataMember]
        public DateTime? FechaGeneracionComision{ get; set; }


        /// <summary>
        /// UsuarioId
        /// </summary>
        [DataMember]
        public int? UsuarioId{ get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        [DataMember]
        public decimal? Valor { get; set; }




    }
}