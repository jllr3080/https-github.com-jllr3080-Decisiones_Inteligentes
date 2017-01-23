#region  using

using System;
using System.Runtime.Serialization;
using  JLLR.Core.General.Servicio.Modelo;

#endregion
namespace JLLR.Core.FlujoProceso.Servicio.Modelo
{
    /// <summary>
    /// Modelo de historial de proceso
    /// </summary>
    public class HistorialProcesoModelo
    {
        /// <summary>
        /// Id 
        /// </summary>
        [DataMember]
        public int HistorialProcesoId { get; set; }

        /// <summary>
        /// OrdenTrabajoId
        /// </summary>
        [DataMember]
        public Int64? OrdenTrabajoId { get; set; }

        /// <summary>
        /// EtapaProceso
        /// </summary>
        [DataMember]
        public EtapaProcesoModelo EtapaProceso { get; set; }

        /// <summary>
        /// FechaRegistro
        /// </summary>
        [DataMember]
        public DateTime? FechaRegistro { get; set; }


        /// <summary>
        /// FechaInicio
        /// </summary>
        [DataMember]
        public DateTime? FechaInicio { get; set; }

        /// <summary>
        /// FechaFin
        /// </summary>
        [DataMember]
        public DateTime? FechaFin { get; set; }

        /// <summary>
        /// NumeroOrden
        /// </summary>
        [DataMember]
        public string NumeroOrden{ get; set; }

        /// <summary>
        /// Texto
        /// </summary>
        [DataMember]
        public string Texto { get; set; }

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
        /// usuarioRecibeId
        /// </summary>
        [DataMember]
        public int? UsuarioRecibeId { get; set; }

        /// <summary>
        /// usuarioEntregaId
        /// </summary>
        [DataMember]
        public int? UsuarioEntregaId { get; set; }

        /// <summary>
        /// PerfilId
        /// </summary>
        [DataMember]
        public int? PerfilId { get; set; }

        /// <summary>
        /// DetalleOrdenTrabajoId
        /// </summary>
        [DataMember]
        public int? DetalleOrdenTrabajoId { get; set; }

        /// <summary>
        /// PasoPorEstaEtapa
        /// </summary>
        [DataMember]
        public bool? PasoPorEstaEtapa { get; set; }
    }

}