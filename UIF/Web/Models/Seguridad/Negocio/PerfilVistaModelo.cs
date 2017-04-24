#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.Seguridad.Negocio
{
    public class PerfilVistaModelo
    {
        /// <summary>
        /// Perfil Id
        /// </summary>
        
        public int PerfilId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
   
        public string Descripcion { get; set; }
    }
}