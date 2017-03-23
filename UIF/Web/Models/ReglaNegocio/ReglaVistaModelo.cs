using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.General;

namespace Web.Models.ReglaNegocio
{
    public class ReglaVistaModelo
    {
        /// <summary>
        /// Regla Id
        /// </summary>
        
        public int ReglaId { get; set; }

        /// <summary>
        /// Sucursal
        /// </summary>
        
        public SucursalVistaModelo Sucursal { get; set; }

        /// <summary>
        /// PuntoVenta
        /// </summary>
        
        public PuntoVentaVistaModelo PuntoVenta { get; set; }

        /// <summary>
        /// TipoRegla
        /// </summary>
        
        public TipoReglaVistaModelo TipoRegla { get; set; }


        /// <summary>
        /// FechaInicio
        /// </summary>
        
        public DateTime? FechaInicio { get; set; }

        /// <summary>
        /// FechaFin
        /// </summary>
        
        public DateTime? FechaFin { get; set; }

        /// <summary>
        /// UsuarioCreacionId
        /// </summary>
        
        public int? UsuarioCreacionId { get; set; }

        /// <summary>
        /// UsuarioModificacionId
        /// </summary>
        
        public int? UsuarioModificacionId { get; set; }

        /// <summary>
        /// NombreRegla
        /// </summary>
        
        public string NombreRegla { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// FechaModificacion
        /// </summary>
        
        public DateTime? FechaModificacion { get; set; }
    }
}