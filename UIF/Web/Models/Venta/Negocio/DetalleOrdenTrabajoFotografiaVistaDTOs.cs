#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Venta.Negocio
{
    public class DetalleOrdenTrabajoFotografiaVistaDTOs
    {
        /// <summary>
        /// Nombre  de  Usuario
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        ///DetalleOrdenTrabajoFotografia
        /// </summary>
        public DetalleOrdenTrabajoFotografiaVistaModelo DetalleOrdenTrabajoFotografia { get; set; }
    }
}