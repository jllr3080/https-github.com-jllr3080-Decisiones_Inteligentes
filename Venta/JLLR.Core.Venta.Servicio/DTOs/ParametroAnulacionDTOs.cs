#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.Venta.Servicio.DTOs
{
    public class ParametroAnulacionDTOs
    {
        /// <summary>
        /// Numero de  orden
        /// </summary>
        [DataMember]
        public string NumeroOrden { get; set; }
        /// <summary>
        /// sucursalId
        /// </summary>
        [DataMember]
        public int SucursalId { get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        [DataMember]
        public int PuntoVentaId { get; set; }
        /// <summary>
        
        /// OrdenTrabajoId
        /// </summary>
        [DataMember]
        public int OrdenTrabajoId { get; set; }


        /// OrdenTrabajoId
        /// </summary>
        [DataMember]
        public int DetalleOrdenTrabajoId{ get; set; }


        /// <summary>
        /// Texto
        /// </summary>
        [DataMember]
        public string Texto { get; set; }
        /// <summary>
        /// usuarioId
        /// </summary>
        [DataMember]
        public int UsuarioId { get; set; }

    }
}