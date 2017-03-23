using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Venta.Negocio
{
    public class OrdenTrabajoDescuentoVistaModelo
    {
        /// <summary>
        /// OrdenTrabajoDescuentoId
        /// </summary>
        
        public Int64 OrdenTrabajoDescuentoId { get; set; }

        /// <summary>
        /// OrdenTrabajoModelo
        /// </summary>
        
        public OrdenTrabajoVistaModelo OrdenTrabajo { get; set; }

        /// <summary>
        /// HistorialRegla
        /// </summary>
        
        public HistorialReglaVistaModelo HistorialRegla { get; set; }

        /// <summary>
        /// Motivo
        /// </summary>
        
        public string Motivo { get; set; }


        /// <summary>
        /// Valor
        /// </summary>
        
        public decimal? Valor { get; set; }

        /// <summary>
        /// PorcentajeFranquicia
        /// </summary>
        
        public decimal? PorcentajeFranquicia { get; set; }

        /// <summary>
        /// PorcentajeFranquicia
        /// </summary>
        
        public decimal? PorcentajeMatriz { get; set; }

        /// <summary>
        /// EstadoProceso
        /// </summary>
        
        public bool? EstadoProceso { get; set; }


        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// FechaActualizacion
        /// </summary>
        
        public DateTime? FechaActualizacion { get; set; }

        /// <summary>
        /// UsuarioCreacionId
        /// </summary>
        
        public int? UsuarioCreacionId { get; set; }

        /// <summary>
        /// UsuarioActualizacionId
        /// </summary>
        
        public int? UsuarioActualizacionId { get; set; }
    }
}