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
    public class NumeroPrendaDTOs
    {
        /// <summary>
        /// Nombre de Producto
        /// </summary>
        [DataMember]
        public string NombreProducto { get; set; }

        /// <summary>
        /// Cantidad
        /// </summary>

        [DataMember]
        public int? Cantidad { get; set; }
    }
}