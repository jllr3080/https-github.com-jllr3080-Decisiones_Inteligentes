#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.Venta.Servicio.Modelo;

#endregion
namespace JLLR.Core.Venta.Servicio.DTOs
{
    [DataContract]
    public class DetalleOrdenTrabajoFotografiaDTOs
    {

        /// <summary>
        /// Nombre  de  Usuario
        /// </summary>
        [DataMember]
        public string NombreUsuario { get; set; }

        /// <summary>
        ///DetalleOrdenTrabajoFotografia
        /// </summary>
        [DataMember]
        public DetalleOrdenTrabajoFotografiaModelo DetalleOrdenTrabajoFotografia { get; set; }
    }
}