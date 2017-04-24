#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.General;
using Web.Models.Individuo;

#endregion
namespace Web.Models.Seguridad.Negocio
{
    public class UsuarioVistaModelo
    {
        /// <summary>
        /// Id del usuario
        /// </summary>

        public int UsuarioId { get; set; }

        /// <summary>
        /// Sucursal
        /// </summary>

        public SucursalVistaModelo Sucursal { get; set; }

        /// <summary>
        /// PuntoVenta
        /// </summary>

        public PuntoVentaVistaModelo PuntoVenta { get; set; }

        /// <summary>
        /// Individuo
        /// </summary>
   
        public IndividuoVistaModelo Individuo { get; set; }

        /// <summary>
        /// NombreUsuario
        /// </summary>
    
        public string NombreUsuario { get; set; }

        /// <summary>
        /// ClaveUsuario
        /// </summary>
     
        public string ClaveUsuario { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
    
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// DiasVigencia
        /// </summary>
    
        public int? DiasVigencia { get; set; }

        /// <summary>
        /// Habilitado
        /// </summary>

        public bool? Habilitado { get; set; }

        /// <summary>
        /// HabilitadoSeguridad
        /// </summary>
   
        public bool? HabilitadoSeguridad { get; set; }
    }
}