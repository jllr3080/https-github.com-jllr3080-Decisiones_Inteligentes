#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Web.Models.General
{
    public class ParametroVistaModelo
    {
        /// <summary>
        /// ParametroId
        /// </summary>
        
        public int ParametroId { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        
        public string Descripcion { get; set; }

        /// <summary>
        /// Texto
        /// </summary>
        
        public string Texto { get; set; }

        /// <summary>
        /// NumeroEntero
        /// </summary>
        
        public int? NumeroEntero { get; set; }

        /// <summary>
        /// Fecha
        /// </summary>
        
        public DateTime? Fecha { get; set; }

        /// <summary>
        /// Boolenao
        /// </summary>
        
        public Boolean? Boolenao { get; set; }

        /// <summary>
        /// NumeroDecimal
        /// </summary>
        
        public decimal? NumeroDecimal { get; set; }
    }
}