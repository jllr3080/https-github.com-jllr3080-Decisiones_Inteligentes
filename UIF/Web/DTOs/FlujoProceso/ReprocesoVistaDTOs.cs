using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.DTOs.FlujoProceso
{
    public class ReprocesoVistaDTOs
    {
        /// <summary>
        /// Numero de Orden
        /// </summary>
        public string NumeroOrden { get; set; }

        /// <summary>
        /// NombrePrenda
        /// </summary>
        public string NombrePrenda { get; set; }

        /// <summary>
        /// FechaReproceso
        /// </summary>
        public DateTime? FechaReproceso { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// InformacionVisual
        /// </summary>
        public string InformacionVisual { get; set; }

        /// <summary>
        /// EstadoPrenda
        /// </summary>
        public string EstadoPrenda { get; set; }

        /// <summary>
        /// TratamientoEspecial
        /// </summary>
        public string TratamientoEspecial { get; set; }

        /// <summary>
        /// Motivo
        /// </summary>
        public string Motivo { get; set; }

        /// <summary>
        /// TipoReproceso
        /// </summary>
        public string TipoReproceso { get; set; }
    }
}