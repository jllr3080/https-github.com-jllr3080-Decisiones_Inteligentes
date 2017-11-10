#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General
{
   public  class ModeloVistaModelo
    {
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
        /// </summary>
      
        public List<MarcaVistaModelo> MarcasModelo { get; set; }
    }
}
