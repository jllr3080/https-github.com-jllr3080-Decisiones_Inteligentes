#region  usnig
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.DTOs
{

    /// <summary>
    /// DTO para indicar los valores  para  revisar la aplicacion de las  reglas
    /// </summary>
    [DataContract]
    public class ReglaDTOs
    {

        /// <summary>
        /// ReglaId
        /// </summary>
        [DataMember]
        public int ReglaId { get; set; }

        /// <summary>
        /// NombreRegla
        /// </summary>
        [DataMember]
        public string NombreRegla{ get; set; }

        /// <summary>
        /// Porcentaje
        /// </summary>
        [DataMember]
        public decimal? Porcentaje { get; set; }


        /// <summary>
        /// ProductoId
        /// </summary>
        [DataMember]
        public int? ProductoId{ get; set; }


    }
}