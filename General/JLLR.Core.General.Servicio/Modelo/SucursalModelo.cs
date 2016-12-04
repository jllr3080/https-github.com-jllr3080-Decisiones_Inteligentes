#region using

using System.Collections.Generic;
using System.Runtime.Serialization;

#endregion
namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// Modelo de  la sucursal
    /// </summary>
    [DataContract]
    public class SucursalModelo
    {
        /// <summary>
        /// Id de la sucursal
        /// </summary>
        [DataMember]
        public int SucursalId { get; set; }

        /// <summary>
        /// Descripcion de la sucursal
        /// </summary>
        [DataMember]
        public string Descripcion{ get; set; }

        /// <summary>
        /// Esta habilitado
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado{ get; set; }

        /// <summary>
        /// Puntos de  venta
        /// </summary>
        [DataMember]
        public List<PuntoVentaModelo> PuntosVenta { get; set; }

    }
}