#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.Venta.Servicio.DTOs
{
    [DataContract]
    public class ParametroDescuentoDTOs
    {
        
        /// <summary>
        /// OrdenTrabajoId
        /// </summary>
        [DataMember]
        public int OrdenTrabajoId { get; set; }

        /// <summary>
        /// ValorDescuentoFranquicia
        /// </summary>
        [DataMember]
        public decimal? ValorDescuentoFranquicia { get; set; }
        
        /// <summary>
        /// ValorDescuentoMatriz
        /// </summary>
        [DataMember]
        public decimal? ValorDescuentoMatriz  { get; set; }

        /// <summary>
        /// UsuarioId
        /// </summary>
        [DataMember]
        public int? UsuarioId { get; set; }
    }
}