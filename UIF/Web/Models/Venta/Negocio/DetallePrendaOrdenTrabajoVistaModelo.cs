#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.Venta.Negocio
{
    public class DetallePrendaOrdenTrabajoVistaModelo
    {
        /// <summary>
        /// DetallePrendaOrdenTrabajoId
        /// </summary>
        
        public int DetallePrendaOrdenTrabajoId { get; set; }

        /// <summary>
        /// DetalleOrdenTrabajoId
        /// </summary>
        
        public int? DetalleOrdenTrabajoId { get; set; }

        /// <summary>
        /// MarcaId
        /// </summary>
        
        public int? MarcaId { get; set; }


        /// <summary>
        /// MarcaId
        /// </summary>

        public string NombreMarca{ get; set; }

        /// <summary>
        /// ColorId
        /// </summary>

        public int? ColorId { get; set; }

        public string NombreColor { get; set; }

        /// <summary>
        /// EstadoPrenda
        /// </summary>

        public string EstadoPrenda { get; set; }

        /// <summary>
        /// EstadoPrenda
        /// </summary>
        
        public string InformacionVisual { get; set; }

        /// <summary>
        /// NumeroInternoPrenda
        /// </summary>
        
        public string NumeroInternoPrenda { get; set; }


        /// <summary>
        /// TratamientoEspecial
        /// </summary>

        public string TratamientoEspecial { get; set; }

        /// <summary>
        /// DetalleOrdenTrabajoObservacion
        /// </summary>

        public List<DetalleOrdenTrabajoObservacionVistaModelo> DetalleOrdenTrabajoObservacion { get; set; }

    }
}