#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using modeloVistaGeneral = Web.Models.General;
#endregion

namespace Web.Models.Individuo
{
    public class DireccionVistaModelo
    {

        /// <summary>
        /// DireccionId
        /// </summary>
        
        public int DireccionId { get; set; }


        /// <summary>
        /// Individuo
        /// </summary>
        
        public IndividuoVistaModelo Individuo { get; set; }

        /// <summary>
        /// TipoDireccion
        /// </summary>
        
        public modeloVistaGeneral.TipoDireccionVistaModelo TipoDireccion { get; set; }

        /// <summary>
        /// Pais
        /// </summary>
        
        public modeloVistaGeneral.PaisVistaModelo Pais { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        
        public modeloVistaGeneral.EstadoVistaModelo Estado { get; set; }

        /// <summary>
        /// Ciudad
        /// </summary>
        
        public modeloVistaGeneral.CiudadVistaModelo Ciudad { get; set; }


        /// <summary>
        /// Parroquia
        /// </summary>
        
        public modeloVistaGeneral.ParroquiaVistaModelo Parroquia { get; set; }


        /// <summary>
        /// DescripcionDireccion
        /// </summary>

        public string DescripcionDireccion { get; set; }


        /// <summary>
        /// CallePrincipal
        /// </summary>
        
        public string CallePrincipal { get; set; }

        /// <summary>
        /// CalleSecundaria
        /// </summary>
        public string CalleSecundaria { get; set; }

        /// <summary>
        /// NumeroCasa
        /// </summary>
        public string NumeroCasa { get; set; }


        /// <summary>
        /// Referencia
        /// </summary>
        public string Referencia { get; set; }
    }
}