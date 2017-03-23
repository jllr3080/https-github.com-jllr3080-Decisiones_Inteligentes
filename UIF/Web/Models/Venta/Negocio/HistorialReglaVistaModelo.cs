using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.ReglaNegocio;

namespace Web.Models.Venta.Negocio
{
    public class HistorialReglaVistaModelo
    {

        /// <summary>
        /// Historial de la  regla id
        /// </summary>
        
        public Int64 HistorialReglaId { get; set; }

        /// <summary>
        /// OrdenTrabajo    
        /// </summary>
        
        public OrdenTrabajoVistaModelo OrdenTrabajo { get; set; }

        /// <summary>
        /// AccionRegla    
        /// </summary>
        
        public AccionReglaVistaModelo AccionRegla { get; set; }


        /// <summary>
        /// FechaEjecucion    
        /// </summary>
        
        public DateTime? FechaEjecucion { get; set; }

        /// <summary>
        /// UsuarioId    
        /// </summary>
        
        public int? UsuarioId { get; set; }
    }
}