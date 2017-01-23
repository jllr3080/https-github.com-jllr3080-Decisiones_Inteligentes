#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.Seguridad.Servicio.DTOs
{
    /// <summary>
    /// Modelo  de Usuario  para  que pueda   loguearse al aplicativo
    /// </summary>
    [DataContract]
    public class UsuarioDTOs:BaseDTOs
    {
        /// <summary>
        /// Id  del usuario
        /// </summary>
        [DataMember]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Id  de la sucursal
        /// </summary>
        [DataMember]
        public int? SucursalId { get; set; }

        /// <summary>
        /// Nombre de la Sucursal
        /// </summary>
        [DataMember]
        public string NombreSucursal { get; set; }

        /// <summary>
        /// Id  del Punto de  Venta
        /// </summary>
        [DataMember]
        public int? PuntoVentaId { get; set; }

        /// <summary>
        /// Nombre del punto  de venta
        /// </summary>
        [DataMember]
        public string NombrePuntoVenta { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        [DataMember]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Horario de atencion del punto de  venta
        /// </summary>
        [DataMember]
        public string HoraInicioPuntoVenta { get; set; }

        /// <summary>
        /// Horario de atencion del punto de  venta
        /// </summary>
        [DataMember]
        public string HoraFinPuntoVenta { get; set; }



        /// <summary>
        /// id del rol
        /// </summary>
        [DataMember]
        public int? PerfilId { get; set; }

        /// <summary>
        /// NombrePerfil
        /// </summary>
        [DataMember]
        public string NombrePerfil { get; set; }

    }
}