#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{
    /// <summary>
    /// Punto de  venta modelo
    /// </summary>
    public class PuntoVentaVistaModelo
    {
        /// <summary>
        /// Id del punto venta 
        /// </summary>
        
        public int PuntoVentaId { get; set; }

        /// <summary>
        /// Descripcion del punto de  venta
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Hora de Inicio
        /// </summary>
        public string HoraInicio { get; set; }

        /// <summary>
        /// Hora de Inicio
        /// </summary>
        public string HoraFin { get; set; }
    }
}