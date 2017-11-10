#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General;

#endregion
namespace JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Individuo
{
    public class IndividuoVistaModelo
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        
        public int IndividuoId { get; set; }

        /// <summary>
        /// Tipo de identificacion
        /// </summary>
        
        public TipoIdentificacionVistaModelo TipoIdentificacion { get; set; }

        /// <summary>
        /// Tipo de individuo
        /// </summary>
 
        public TipoIndividuoVistaModelo TipoIndividuo { get; set; }



        /// <summary>
        /// PrimerCampo
        /// </summary>
        
        public string PrimerCampo { get; set; }

        /// <summary>
        /// Segundo Campo
        /// </summary>
        
        public string SegundoCampo { get; set; }

        /// <summary>
        /// Tercer Campo
        /// </summary>
        
        public string TercerCampo { get; set; }

        /// <summary>
        /// Cuarto Campo
        /// </summary>
        
        public string CuartoCampo { get; set; }

        /// <summary>
        /// NumeroIdentificacion
        /// </summary>
        
        public string NumeroIdentificacion { get; set; }

        /// <summary>
        /// Habilitado
        /// </summary>
        
        public bool? Habilitado { get; set; }

        /// <summary>
        /// FechaCreacion
        /// </summary>
        
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// FechaModificacion
        /// </summary>
        
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// UsuarioId
        /// </summary>
        
        public int? UsuarioId { get; set; }

        /// <summary>
        /// individuoRol
        /// </summary>
        
        public IndividuoRolVistaModelo individuoRol { get; set; }
    }
}
