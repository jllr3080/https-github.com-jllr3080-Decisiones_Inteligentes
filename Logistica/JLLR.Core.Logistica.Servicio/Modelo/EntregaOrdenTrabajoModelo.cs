﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.Logistica.Servicio.Modelo
{
    /// <summary>
    /// Modelo de  entrega de  trabajo
    /// </summary>
    [DataContract]
    public class EntregaOrdenTrabajoModelo
    {
        /// <summary>
        /// Id 
        /// </summary>
        [DataMember]
        public int EntregaOrdenTrabajoId { get; set; }

        /// <summary>
        /// OrdenTrabajoId 
        /// </summary>
        [DataMember]
        public Int64? OrdenTrabajoId { get; set; }

        /// <summary>
        /// FechaEntrega 
        /// </summary>
        [DataMember]
        public DateTime? FechaEntrega{ get; set; }

        /// <summary>
        /// UsuarioEntregaId 
        /// </summary>
        [DataMember]
        public int? UsuarioEntregaId { get; set; }

        /// <summary>
        /// UsuarioRecibeId 
        /// </summary>
        [DataMember]
        public int? UsuarioRecibeId { get; set; }


        /// <summary>
        /// EtapaProcesoPerfilId 
        /// </summary>
        [DataMember]
        public int? EtapaProcesoPerfilId { get; set; }

        /// <summary>
        /// Etapa Actual 
        /// </summary>
        [DataMember]
        public int? EtapaActual { get; set; }

        /// <summary>
        /// Etapa Actual 
        /// </summary>
        [DataMember]
        public int? SiguienteEtapa { get; set; }

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
    }
}