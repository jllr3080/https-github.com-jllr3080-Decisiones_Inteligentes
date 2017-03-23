#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using JLLR.Core.General.Servicio.Modelo;
#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.Modelo
{
    /// <summary>
    /// modelo de la regla
    /// </summary>
    [DataContract]
    public class ReglaModelo
    {
        /// <summary>
        /// Regla Id
        /// </summary>
        [DataMember]
        public int ReglaId { get; set; }

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
        /// TipoRegla
        /// </summary>
        [DataMember]
        public TipoReglaModelo TipoRegla { get; set; }


        /// <summary>
        /// FechaInicio
        /// </summary>
        [DataMember]
        public DateTime?  FechaInicio{ get; set; }

        /// <summary>
        /// FechaFin
        /// </summary>
        [DataMember]
        public DateTime? FechaFin { get; set; }

        /// <summary>
        /// UsuarioCreacionId
        /// </summary>
        [DataMember]
        public int? UsuarioCreacionId { get; set; }

        /// <summary>
        /// UsuarioModificacionId
        /// </summary>
        [DataMember]
        public int? UsuarioModificacionId { get; set; }

        /// <summary>
        /// NombreRegla
        /// </summary>
        [DataMember]
        public string NombreRegla{ get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// FechaModificacion
        /// </summary>
        [DataMember]
        public DateTime? FechaModificacion { get; set; }
    }
}