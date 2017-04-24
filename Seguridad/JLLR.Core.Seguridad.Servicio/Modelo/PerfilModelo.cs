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
    public class PerfilModelo
    {
        /// <summary>
        /// Perfil Id
        /// </summary>
        [DataMember]
        public int PerfilId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember]
        public string Descripcion { get; set; }
    }
}