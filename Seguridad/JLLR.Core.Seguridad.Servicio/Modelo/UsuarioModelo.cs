#region using
using System;
using System.Runtime.Serialization;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Individuo.Servicio.Modelo;

#endregion
namespace JLLR.Core.Seguridad.Servicio.Modelo
{
    /// <summary>
    /// Usuario
    /// </summary>
    [DataContract]
    public class UsuarioModelo
    {

        /// <summary>
        /// Id del usuario
        /// </summary>
        [DataMember]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Sucursal
        /// </summary>
        [DataMember]
        public SucursalModelo Sucursal { get; set; }

        /// <summary>
        /// PuntoVenta
        /// </summary>
        [DataMember]
        public PuntoVentaModelo PuntoVenta { get; set; }

        /// <summary>
        /// Individuo
        /// </summary>
        [DataMember]
        public IndividuoModelo Individuo { get; set; }

        /// <summary>
        /// NombreUsuario
        /// </summary>
        [DataMember]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// ClaveUsuario
        /// </summary>
        [DataMember]
        public string ClaveUsuario { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// DiasVigencia
        /// </summary>
        [DataMember]
        public int? DiasVigencia { get; set; }

        /// <summary>
        /// Habilitado
        /// </summary>
        [DataMember]
        public bool? Habilitado { get; set; }

        /// <summary>
        /// HabilitadoSeguridad
        /// </summary>
        [DataMember]
        public bool? HabilitadoSeguridad { get; set; }
    }
}