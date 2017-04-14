#region  using

using System;
using System.Runtime.Serialization;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Individuo.Servicio.Modelo;
using JLLR.Core.Seguridad.Servicio.Modelo;

#endregion
namespace JLLR.Core.Venta.Servicio.Modelo.Parametrizacion
{
    /// <summary>
    /// Venta de comision
    /// </summary>
    [DataContract]
    public class VentaComisionModelo
    {
        /// <summary>
        /// Id 
        /// </summary>
        [DataMember]
        public int VentaComisionId { get; set; }

        /// <summary>
        ///VendedorId
        /// </summary>
        [DataMember]
        public int? VendedorId { get; set; }

        /// <summary>
        ///FechaComision
        /// </summary>
        [DataMember]
        public DateTime? FechaComision { get; set; }

        /// <summary>
        ///EstaHabilitado
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado { get; set; }

        /// <summary>
        ///PorcentajeComision
        /// </summary>
        [DataMember]
        public decimal? PorcentajeComision { get; set; }

        /// <summary>
        ///SucursalId
        /// </summary>
        [DataMember]
        public int? SucursalId { get; set; }


        /// <summary>
        ///PuntoVentaId
        /// </summary>
        [DataMember]
        public int? PuntoVentaId { get; set; }

        /// <summary>
        ///TipoLavadoId
        /// </summary>
        [DataMember]
        public int? TipoLavadoId { get; set; }

        /// <summary>
        ///TipoLavadoId
        /// </summary>
        [DataMember]
        public bool? VieneRegla { get; set; }
    }
}