#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion

namespace JLLR.Core.Venta.Servicio.Modelo
{
    /// <summary>
    /// Modelo del detalle d ela prenda
    /// </summary>
    [DataContract]
    public class DetallePrendaOrdenTrabajoModelo
    {

        /// <summary>
        /// DetallePrendaOrdenTrabajoId
        /// </summary>
        [DataMember]
        public int DetallePrendaOrdenTrabajoId { get; set; }

        /// <summary>
        /// DetalleOrdenTrabajoId
        /// </summary>
        [DataMember]
        public int? DetalleOrdenTrabajoId { get; set; }

        /// <summary>
        /// MarcaId
        /// </summary>
        [DataMember]
        public int? MarcaId { get; set; }

        /// <summary>
        /// ColorId
        /// </summary>
        [DataMember]
        public int? ColorId { get; set; }

        /// <summary>
        /// EstadoPrenda
        /// </summary>
        [DataMember]
        public string EstadoPrenda{ get; set; }

        /// <summary>
        /// EstadoPrenda
        /// </summary>
        [DataMember]
        public string InformacionVisual { get; set; }

        /// <summary>
        /// NumeroInternoPrenda
        /// </summary>
        [DataMember]
        public string NumeroInternoPrenda { get; set; }

        /// <summary>
        /// TratamientoEspecial
        /// </summary>
        [DataMember]
        public string TratamientoEspecial { get; set; }
        /// <summary>
        /// DetalleOrdenTrabajoObservacion
        /// </summary>
        [DataMember]
        public List<DetalleOrdenTrabajoObservacionModelo> DetalleOrdenTrabajoObservacion { get; set; }

    }
}