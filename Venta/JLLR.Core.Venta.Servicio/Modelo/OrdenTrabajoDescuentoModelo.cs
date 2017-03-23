#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.Venta.Servicio.Modelo
{
    /// <summary>
    /// Modelo d e  orden de trabajo y descuento
    /// </summary>

    [DataContract]
    public class OrdenTrabajoDescuentoModelo
    {

        /// <summary>
        /// OrdenTrabajoDescuentoId
        /// </summary>
        [DataMember]
        public Int64 OrdenTrabajoDescuentoId { get; set; }

        /// <summary>
        /// OrdenTrabajoModelo
        /// </summary>
        [DataMember]
        public  OrdenTrabajoModelo OrdenTrabajo { get; set; }

        /// <summary>
        /// HistorialRegla
        /// </summary>
        [DataMember]
        public HistorialReglaModelo HistorialRegla { get; set; }

        /// <summary>
        /// Motivo
        /// </summary>
        [DataMember]
        public string Motivo { get; set; }


        /// <summary>
        /// Valor
        /// </summary>
        [DataMember]
        public decimal? Valor { get; set; }

        /// <summary>
        /// PorcentajeFranquicia
        /// </summary>
        [DataMember]
        public decimal? PorcentajeFranquicia { get; set; }

        /// <summary>
        /// PorcentajeFranquicia
        /// </summary>
        [DataMember]
        public decimal? PorcentajeMatriz { get; set; }

        /// <summary>
        /// EstadoProceso
        /// </summary>
        [DataMember]
        public bool? EstadoProceso{ get; set; }


        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion{ get; set; }

        /// <summary>
        /// FechaActualizacion
        /// </summary>
        [DataMember]
        public DateTime? FechaActualizacion { get; set; }

        /// <summary>
        /// UsuarioCreacionId
        /// </summary>
        [DataMember]
        public int? UsuarioCreacionId { get; set; }

        /// <summary>
        /// UsuarioActualizacionId
        /// </summary>
        [DataMember]
        public int? UsuarioActualizacionId { get; set; }

    }
}
