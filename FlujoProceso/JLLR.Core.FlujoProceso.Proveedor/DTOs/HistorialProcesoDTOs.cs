#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.FlujoProceso.Proveedor.DTOs
{
    /// <summary>
    /// DTO historial del proceso
    /// </summary>
    public class HistorialProcesoDTOs
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
        public Int64? OrdenTrabajoId{ get; set; }
        /// <summary>
        /// UsuarioEntregaId   
        /// </summary>

        public int? UsuarioEntregaId { get; set; }

        /// <summary>
        /// UsuarioEntregaId   
        /// </summary>

        public int? UsuarioRecibeId { get; set; }

    }
}
