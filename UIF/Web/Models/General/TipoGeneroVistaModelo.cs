#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion
namespace Web.Models.General
{
    public class TipoGeneroVistaModelo
    {
        /// <summary>
        /// Id del tipo de Genero
        /// </summary>
        
        public int TipoGeneroId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }
    }
}