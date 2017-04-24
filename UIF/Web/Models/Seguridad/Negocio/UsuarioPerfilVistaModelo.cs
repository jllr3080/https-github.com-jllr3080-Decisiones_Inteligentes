#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#endregion
namespace Web.Models.Seguridad.Negocio
{
    public class UsuarioPerfilVistaModelo
    {
        /// <summary>
        /// UsuarioPerfilId
        /// </summary>
  
        public int UsuarioPerfilId { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        
        public UsuarioVistaModelo Usuario { get; set; }

        /// <summary>
        /// Perfil
        /// </summary>
   
        public PerfilVistaModelo Perfil { get; set; }
    }
}