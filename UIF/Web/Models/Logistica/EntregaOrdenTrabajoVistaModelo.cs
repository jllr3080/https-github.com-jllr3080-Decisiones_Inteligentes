#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Logistica
{
    public class EntregaOrdenTrabajoVistaModelo
    {

        /// <summary>
        /// Id 
        /// </summary>
        
        public int EntregaOrdenTrabajoId { get; set; }

        /// <summary>
        /// OrdenTrabajoId 
        /// </summary>
        
        public Int64? OrdenTrabajoId { get; set; }

        /// <summary>
        /// FechaEntrega 
        /// </summary>
        
        public DateTime? FechaEntrega { get; set; }

        /// <summary>
        /// UsuarioEntregaId 
        /// </summary>
        
        public int? UsuarioEntregaId { get; set; }

        /// <summary>
        /// UsuarioRecibeId 
        /// </summary>
        
        public int? UsuarioRecibeId { get; set; }

        /// <summary>
        /// EtapaProcesoPerfilId 
        /// </summary>
        
        public int? EtapaProcesoPerfilId { get; set; }

        /// <summary>
        /// Etapa Actual 
        /// </summary>
        
        public int? EtapaActual { get; set; }

        /// <summary>
        /// Etapa Actual 
        /// </summary>
        
        public int? SiguienteEtapa { get; set; }

        /// <summary>
        /// SucursalId
        /// </summary>
        
        public int? SucursalId { get; set; }

        /// <summary>
        /// PuntoVentaId
        /// </summary>
        
        public int? PuntoVentaId { get; set; }
    }
}