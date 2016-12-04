#region using

using System;
using System.Runtime.Serialization;

#endregion
namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// Impuesto modelo
    /// </summary>
    [DataContract]
    public class ImpuestoModelo
    {
        /// <summary>
        /// Id del impuesto
        /// </summary>
        [DataMember]
        public int ImpuestoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion{ get; set; }

        /// <summary>
        /// Porcentaje
        /// </summary>
        [DataMember]
        public decimal? Porcentaje { get; set; }

        /// <summary>
        /// Esta Habilitado
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado{ get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        [DataMember]
        public DateTime? FechaCreacion{ get; set; }
    }
}