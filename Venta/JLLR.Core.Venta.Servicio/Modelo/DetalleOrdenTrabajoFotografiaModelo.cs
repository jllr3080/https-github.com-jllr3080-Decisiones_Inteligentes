#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.Venta.Servicio.Modelo
{
    [DataContract]
    public class DetalleOrdenTrabajoFotografiaModelo
    {
        /// <summary>
        /// Id  del modelo
        /// </summary>
        [DataMember]
        public int DetalleOrdenTrabajoFotografiaId { get; set; }

        /// <summary>
        /// DetallePrendaOrdenTrabajo
        /// </summary>
        [DataMember]
        public DetallePrendaOrdenTrabajoModelo DetallePrendaOrdenTrabajo { get; set; }


        /// <summary>
        /// UsuarioId
        /// </summary>
        [DataMember]
        public int? UsuarioId { get; set; }

        /// <summary>
        /// FechaRegistro
        /// </summary>
        [DataMember]
        public DateTime? FechaRegistro { get; set; }

        /// <summary>
        /// ImagenPrenda
        /// </summary>
        [DataMember]
        public byte[] ImagenPrenda { get; set; }

    }
}