#region using

using System.Runtime.Serialization;

#endregion
namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// Modelo del estado de pago
    /// </summary>
    [DataContract]
    public class EstadoPagoModelo
    {
        /// <summary>
        /// Id del estado del pago
        /// </summary>
        [DataMember]
        public int EstadoPagoId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }
    }
}