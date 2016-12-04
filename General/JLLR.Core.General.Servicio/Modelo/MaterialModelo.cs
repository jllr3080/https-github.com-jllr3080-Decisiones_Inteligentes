#region using
using System.Runtime.Serialization;
#endregion


namespace JLLR.Core.General.Servicio.Modelo
{

    /// <summary>
    /// Material del producto
    /// </summary>
    public class MaterialModelo
    {

        /// <summary>
        /// Id del material del producto
        /// </summary>
        [DataMember]
        public int MaterialId { get; set; }

        /// <summary>
        /// Descripcion 
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }

        /// <summary>
        /// Esta habilitado 
        /// </summary>
        [DataMember]
        public bool? EstaHabilitado { get; set; }
    }
}