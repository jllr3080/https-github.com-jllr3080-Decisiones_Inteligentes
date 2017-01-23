#region using
using System;
#endregion
namespace Web.DTOs.FlujoProceso
{
    public class HistorialProcesoVistaDTOs
    {

        /// <summary>
        /// Numero de Orden
        /// </summary>

        public string NumeroOrden { get; set; }

        /// <summary>
        /// Numero de  prendas
        /// </summary>
  
        public int? NumeroPrendas { get; set; }

        /// <summary>
        /// FechaRegistro   
        /// </summary>
        public DateTime? FechaRegistro { get; set; }



        /// <summary>
        /// NombrePuntoVenta   
        /// </summary>
        
        public string NombrePuntoVenta { get; set; }

        /// <summary>
        /// UsuarioEntrega   
        /// </summary>
     
        public string UsuarioEntrega { get; set; }

        /// <summary>
        /// UsuarioRecibe   
        /// </summary>

        public string UsuarioRecibe { get; set; }

        

        /// <summary>
        /// OrdenTrabajoId   
        /// </summary>

        public Int64? OrdenTrabajoId { get; set; }

        /// <summary>
        /// UsuarioEntregaId   
        /// </summary>

        public int? UsuarioEntregaId { get; set; }

        /// <summary>
        /// UsuarioEntregaId   

        public int? UsuarioRecibeId { get; set; }
    }
}