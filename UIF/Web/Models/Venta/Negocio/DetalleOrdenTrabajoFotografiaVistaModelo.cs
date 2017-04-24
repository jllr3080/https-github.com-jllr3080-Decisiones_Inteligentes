#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Venta.Negocio
{
    public class DetalleOrdenTrabajoFotografiaVistaModelo
    {
        /// <summary>
        /// Id  del modelo
        /// </summary>
       
        public int DetalleOrdenTrabajoFotografiaId { get; set; }

        /// <summary>
        /// DetallePrendaOrdenTrabajo
        /// </summary>
        
        public DetallePrendaOrdenTrabajoVistaModelo DetallePrendaOrdenTrabajo { get; set; }


        /// <summary>
        /// UsuarioId
        /// </summary>
       
        public int? UsuarioId { get; set; }

        /// <summary>
        /// FechaRegistro
        /// </summary>
        
        public DateTime? FechaRegistro { get; set; }

        /// <summary>
        /// ImagenPrenda
        /// </summary>
       
        public byte[] ImagenPrenda { get; set; }
    }
}