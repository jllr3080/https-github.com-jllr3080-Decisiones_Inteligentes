#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Venta.Proveedor.DTOs
{

    public  class DetalleOrdenTrabajoObservacionDTOs
    {

        /// <summary>
        /// Nombre Usuario
        /// </summary>
        public string NombreUsuario { get; set; }


        /// <summary>
        /// Observaciones d elas prendas    
        /// </summary>
        public DETALLE_ORDEN_TRABAJO_OBSERVACION DetalleOrdenTrabajoObservacion { get; set; }
    }
}
