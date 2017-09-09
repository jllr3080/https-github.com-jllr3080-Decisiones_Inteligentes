using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.General
{
    public class ColeccionVistaModelo
    {


    }


    public class TipoDocumentoVistaModelo
    {
        /// <summary>
        /// Tipo de  Busqueda
        /// </summary>
        public int TipoBusquedaId { get; set; }

        /// <summary>
        ///   Busqueda
        /// </summary>
        public string Busqueda { get; set; }
    }

}