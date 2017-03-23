#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.General.Servicio.Modelo
{
    [DataContract]
    public class ParametroModelo
    {

        /// <summary>
        /// ParametroId
        /// </summary>
        [DataMember]
        public int ParametroId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion{ get; set; }

        /// <summary>
        /// Texto
        /// </summary>
        [DataMember]
        public string Texto { get; set; }

        /// <summary>
        /// NumeroEntero
        /// </summary>
        [DataMember]
        public int? NumeroEntero{ get; set; }

        /// <summary>
        /// Fecha
        /// </summary>
        [DataMember]
        public DateTime? Fecha{ get; set; }

        /// <summary>
        /// Boolenao
        /// </summary>
        [DataMember]
        public Boolean? Boolenao { get; set; }

        /// <summary>
        /// NumeroDecimal
        /// </summary>
        [DataMember]
        public decimal? NumeroDecimal { get; set; }
    }
}