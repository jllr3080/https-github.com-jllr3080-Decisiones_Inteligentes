#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.Venta.Servicio.DTOs
{
    [DataContract]
    public class PrendaMarcaDTOs
    {

        /// <summary>
        /// NumeroOrden
        /// </summary>
        [DataMember]
        public string NumeroOrden { get; set; }

        /// <summary>
        /// FechaIngreso
        /// </summary>
        [DataMember]
        public DateTime? FechaIngreso { get; set; }

        /// <summary>
        /// NombrePrenda
        /// </summary>
        [DataMember]
        public string NombrePrenda { get; set; }

        /// <summary>
        /// NombreSucursal
        /// </summary>
        [DataMember]
        public string NombreSucursal { get; set; }

        /// <summary>
        /// Nombre Marca
        /// </summary>
        [DataMember]
        public string NombreMarca { get; set; }
    }
}