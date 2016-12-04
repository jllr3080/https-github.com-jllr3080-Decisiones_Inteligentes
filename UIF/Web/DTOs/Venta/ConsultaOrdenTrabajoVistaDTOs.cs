#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.DTOs.Venta
{
    public class ConsultaOrdenTrabajoVistaDTOs
    {

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        
        public string NombreCliente { get; set; }

        /// <summary>
        /// FechaIngreso
        /// </summary>
        
        public DateTime? FechaIngreso { get; set; }

        /// <summary>
        /// FechaEntrega
        /// </summary>
        
        public DateTime? FechaEntrega { get; set; }

        /// <summary>
        /// NumeroOrden
        /// </summary>
        
        public string NumeroOrden { get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        
        public string EstadoPago { get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        
        public string TipoLavado { get; set; }

        /// <summary>
        /// EstadoPago
        /// </summary>
        
        public int? Cantidad { get; set; }

        /// <summary>
        /// Prenda
        /// </summary>
        
        public string Prenda { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        
        public string Color { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        
        public string Marca { get; set; }

        /// <summary>
        /// ValorUnitario
        /// </summary>
        
        public decimal? ValorUnitario { get; set; }

        /// <summary>
        /// ValorTotal
        /// </summary>
        
        public decimal? ValorTotal { get; set; }

        /// <summary>
        /// Observacion
        /// </summary>
        
        public string Observacion { get; set; }
    }
}