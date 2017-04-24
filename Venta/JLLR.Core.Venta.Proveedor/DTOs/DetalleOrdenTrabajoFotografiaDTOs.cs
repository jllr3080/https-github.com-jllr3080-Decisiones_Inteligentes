#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Venta.Proveedor.DTOs
{
    public class DetalleOrdenTrabajoFotografiaDTOs:BaseDAOs
    {
        /// <summary>
        /// Nombre  de  Usuario
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        ///DetalleOrdenTrabajoFotografia
        /// </summary>
        public DETALLE_TRABAJO_FOTOGRAFIA DetalleOrdenTrabajoFotografia { get; set; }


    }
}
