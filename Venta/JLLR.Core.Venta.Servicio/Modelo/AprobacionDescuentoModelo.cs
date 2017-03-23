#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.Venta.Servicio.Modelo
{

    /// <summary>
    /// modelo de  aprobacion de desucento
    /// </summary>
    [DataContract]
    public class AprobacionDescuentoModelo
    {

        /// <summary>
        /// AprobacionDescuentoId
        /// </summary>
        [DataMember]
        public Int64 AprobacionDescuentoId { get; set; }

        /// <summary>
        /// OrdenTrabajoDescuento
        /// </summary>
        [DataMember]
        public OrdenTrabajoDescuentoModelo OrdenTrabajoDescuento { get; set; }

        /// <summary>
        /// OrdenTrabajo
        /// </summary>
        [DataMember]
        public OrdenTrabajoModelo OrdenTrabajo { get; set; }


        /// <summary>
        /// usuarioAprobacionId
        /// </summary>
        [DataMember]
        public int? usuarioAprobacionId{ get; set; }

        /// <summary>
        /// FechaAprobacion
        /// </summary>
        [DataMember]
        public DateTime? FechaAprobacion{ get; set; }

        /// <summary>
        /// ValorFranquiciaAprobacion
        /// </summary>
        [DataMember]
        public decimal? ValorFranquiciaAprobacion{ get; set; }

        /// <summary>
        /// ValorMatrizAprobacion
        /// </summary>
        [DataMember]
        public decimal? ValorMatrizAprobacion { get; set; }

    }
}