#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
#endregion
namespace JLLR.Core.Seguridad.Servicio.Modelo
{
    [DataContract]
    public class UsuarioPerfilModelo
    {
        /// <summary>
        /// UsuarioPerfilId
        /// </summary>
        [DataMember]
        public int UsuarioPerfilId { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        [DataMember]
        public UsuarioModelo Usuario { get; set; }

        /// <summary>
        /// Perfil
        /// </summary>
        [DataMember]
        public PerfilModelo Perfil { get; set; }
    }
}