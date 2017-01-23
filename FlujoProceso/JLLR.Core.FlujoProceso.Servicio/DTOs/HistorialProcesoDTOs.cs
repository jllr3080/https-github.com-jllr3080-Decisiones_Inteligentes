#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.FlujoProceso.Servicio.DTOs
{
    /// <summary>
    /// DTO de historial de proceso
    /// </summary>
    [DataContract]
    public class HistorialProcesoDTOs
    {
        /// <summary>
        /// Numero de Orden
        /// </summary>
        [DataMember]
        public string NumeroOrden { get; set; }

        /// <summary>
        /// Numero de  prendas
        /// </summary>
        [DataMember]
        public int? NumeroPrendas { get; set; }

        /// <summary>
        /// FechaRegistro   
        /// </summary>
        [DataMember]
        public DateTime? FechaRegistro { get; set; }



        /// <summary>
        /// NombrePuntoVenta   
        /// </summary>
        [DataMember]
        public string NombrePuntoVenta { get; set; }

        /// <summary>
        /// UsuarioEntrega   
        /// </summary>
        [DataMember]
        public string UsuarioEntrega { get; set; }

        /// <summary>
        /// UsuarioRecibe   
        /// </summary>
        [DataMember]
        public string UsuarioRecibe { get; set; }

        /// <summary>
        /// OrdenTrabajoId   
        /// </summary>
        [DataMember]
        public Int64? OrdenTrabajoId { get; set; }

        /// <summary>
        /// UsuarioEntregaId   
        /// </summary>
        [DataMember]
        public int? UsuarioEntregaId { get; set; }

        /// <summary>
        /// UsuarioEntregaId   
        /// </summary>
        [DataMember]
        public int? UsuarioRecibeId { get; set; }
    }
}