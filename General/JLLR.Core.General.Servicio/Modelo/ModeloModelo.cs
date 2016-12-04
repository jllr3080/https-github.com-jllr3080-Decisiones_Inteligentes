#region using

using System.Collections.Generic;
using System.Runtime.Serialization;
#endregion

namespace JLLR.Core.General.Servicio.Modelo
{
    /// <summary>
    /// Modelo del producto
    /// </summary>
    [DataContract]
    public class ModeloModelo
    {
        /// <summary>
        /// Id de la marca del producto
        /// </summary>
        [DataMember]
        public int ModeloId { get; set; }

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


        /// <summary>
        //Lista de los modelos que tiene ese producto
        /// </summary>
        [DataMember]
        public List<MarcaModelo> MarcasModelo { get; set; }
    }
}