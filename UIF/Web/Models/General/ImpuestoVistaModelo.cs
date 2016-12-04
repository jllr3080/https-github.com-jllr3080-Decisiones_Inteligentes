#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{
    /// <summary>
    /// Impuesto modelo
    /// </summary>
    public class ImpuestoVistaModelo
    {

        /// <summary>
        /// Id del impuesto
        /// </summary>
        
        public int ImpuestoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Porcentaje
        /// </summary>
        
        public decimal? Porcentaje { get; set; }

        /// <summary>
        /// Esta Habilitado
        /// </summary>
        
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }
    }
}