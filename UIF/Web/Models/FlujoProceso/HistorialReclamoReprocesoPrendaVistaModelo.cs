#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.FlujoProceso
{
    public class HistorialReclamoReprocesoPrendaVistaModelo
    {


        /// <summary>
        /// HistorialReclamoReprocesoPrendaId
        /// </summary>
 
        public Int64 HistorialReclamoReprocesoPrendaId { get; set; }

        /// <summary>
        /// DetallePrendaOrdenTrabajoId
        /// </summary>
    
        public int? DetallePrendaOrdenTrabajoId { get; set; }

        /// <summary>
        /// Fecha
        /// </summary>
   
        public DateTime? Fecha { get; set; }

        /// <summary>
        /// PorqueReproceso
        /// </summary>
  
        public string PorqueReproceso { get; set; }

        /// <summary>
        /// UsuarioId
        /// </summary>

        public int? UsuarioId { get; set; }

        /// <summary>
        /// FechaEntrega
        /// </summary>

        public DateTime? FechaEntrega { get; set; }
    }
}