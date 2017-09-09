#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.FlujoProceso.Servicio.DTOs
{

    [DataContract]
    public class ReprocesoDTOs
    {
        /// Numero de Orden
        /// </summary>
        [DataMember]
        public string NumeroOrden { get; set; }

        /// <summary>
        /// NombrePrenda
        /// </summary>
        [DataMember]
        public string NombrePrenda { get; set; }

        /// <summary>
        /// FechaReproceso
        /// </summary>
        [DataMember]
        public DateTime? FechaReproceso { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        [DataMember]
        public string Marca { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        [DataMember]
        public string Color { get; set; }

        /// <summary>
        /// InformacionVisual
        /// </summary>
        [DataMember]
        public string InformacionVisual { get; set; }

        /// <summary>
        /// EstadoPrenda
        /// </summary>
        [DataMember]
        public string EstadoPrenda { get; set; }

        /// <summary>
        /// TratamientoEspecial
        /// </summary>
        [DataMember]
        public string TratamientoEspecial { get; set; }

        /// <summary>
        /// Motivo
        /// </summary>
        [DataMember]
        public string Motivo { get; set; }

        /// <summary>
        /// TipoReproceso
        /// </summary>
        [DataMember]
        public string TipoReproceso { get; set; }
    }
}