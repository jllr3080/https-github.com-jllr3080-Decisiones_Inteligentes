#region using

using System.Runtime.Serialization;

#endregion

namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Punto de  venta modelo
    /// </summary>
    [DataContract]
    public class PuntoVentaModelo
    {
        /// <summary>
        /// Id del punto venta 
        /// </summary>
        [DataMember]
        public int PuntoVentaId { get; set; }

        /// <summary>
        /// Descripcion del punto de  venta
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// Hora de Inicio
        /// </summary>
        [DataMember]
        public string HoraInicio { get; set; }

        /// <summary>
        /// Hora de Inicio
        /// </summary>
        [DataMember]
        public string HoraFin { get; set; }
    }
}