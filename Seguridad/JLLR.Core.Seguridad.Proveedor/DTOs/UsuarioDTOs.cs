using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLLR.Core.Seguridad.Proveedor.DTOs
{
    public class UsuarioDTOs
    {

        /// <summary>
        /// Id  del usuario
        /// </summary>
     
        public int UsuarioId { get; set; }

        /// <summary>
        /// Id  de la sucursal
        /// </summary>
       
        public int? SucursalId { get; set; }

        /// <summary>
        /// Nombre de la Sucursal
        /// </summary>
        
        public string NombreSucursal { get; set; }

        /// <summary>
        /// Id  del Punto de  Venta
        /// </summary>
      
        public int? PuntoVentaId { get; set; }

        /// <summary>
        /// Nombre del punto  de venta
        /// </summary>
       
        public string NombrePuntoVenta { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
       
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Horario de atencion del punto de  venta
        /// </summary>
       
        public string HoraInicioPuntoVenta { get; set; }

        /// <summary>
        /// Horario de atencion del punto de  venta
        /// </summary>
       public string HoraFinPuntoVenta { get; set; }


        /// <summary>
        /// id del rol
        /// </summary>
        public int? PerfilId { get; set; }

        /// <summary>
        /// NombrePerfil
        /// </summary>
        public string NombrePerfil{ get; set; }


    }
}
