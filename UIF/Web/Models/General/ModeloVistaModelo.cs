#region using
using System;
using System.Collections.Generic;


#endregion

namespace Web.Models.General
{
    public class ModeloVistaModelo
    {
        /// <summary>
        /// Id de la marca del producto
        /// </summary>

        public int ModeloId { get; set; }

        /// <summary>
        /// Descripcion 
        /// </summary>

        public string Descripcion { get; set; }

        /// <summary>
        /// Esta habilitado 
        /// </summary>

        public bool? EstaHabilitado { get; set; }


        /// <summary>
        //Lista de los modelos que tiene ese producto

        public List<MarcaVistaModelo> MarcasModelo { get; set; }
    }
}