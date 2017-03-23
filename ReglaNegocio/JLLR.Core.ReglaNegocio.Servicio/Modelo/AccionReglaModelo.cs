#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.Modelo
{
    /// <summary>
    /// Modelo  de la accion de la regla 
    /// </summary>
    [DataContract]
    public class AccionReglaModelo
    {
        /// <summary>
        /// AccionreglaId
        /// </summary>
        [DataMember]
        public int AccionreglaId { get; set; }

        /// <summary>
        /// Regla
        /// </summary>
        [DataMember]
        public ReglaModelo Regla { get; set; }

        /// <summary>
        /// ProductoId
        /// </summary>
        [DataMember]
        public int? ProductoId{ get; set; }

        /// <summary>
        /// EstaHabilitado
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado{ get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        [DataMember]
        public decimal? Valor{ get; set; }

    }
}