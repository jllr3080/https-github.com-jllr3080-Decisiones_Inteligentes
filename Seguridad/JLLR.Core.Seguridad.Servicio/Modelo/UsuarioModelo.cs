#region using
using System;
using System.Runtime.Serialization;

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
    }
}