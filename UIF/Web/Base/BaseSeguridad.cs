using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Web.Base
{
    public class BaseSeguridad: ICustomPrincipal
    {
        
            public IIdentity Identity { get; private set; }
            public bool IsInRole(string role) { return false; }

            public BaseSeguridad(string email)
            {
                this.Identity = new GenericIdentity(email);
            }

        public BaseSeguridad()
        {
        }

        /// <summary>
        /// Id del usuario
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// NOmbre del Usuario
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Id  de la sucursal
        /// </summary>
        public int? SucursalId { get; set; }
       
        /// <summary>
        /// Nombre  de la sucursal
        /// </summary>
         public string NombreSucursal { get; set; }

        /// <summary>
        /// Id  del punto de  venta
        /// </summary>
        public int? PuntoVentaId { get; set; }

        /// <summary>
        /// Nombre del punto de  venta
        /// </summary>
        public string NombrePuntoVenta { get; set; }
        /// <summary>
        /// Horario de atencion del punto de  venta
        /// </summary>

        public string HoraInicioPuntoVenta { get; set; }

        /// <summary>
        /// Horario de atencion del punto de  venta
        /// </summary>

        public string HoraFinPuntoVenta { get; set; }

        /// <summary>
        /// perfil  Id
        /// </summary>

        public int? PerfilId { get; set; }

        /// <summary>
        /// NombrePerfil
        /// </summary>
        public string NombrePerfil { get; set; }



    }
    interface ICustomPrincipal : IPrincipal
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
         int Id { get; set; }
        /// <summary>
        /// NOmbre del Usuario
        /// </summary>
        string NombreUsuario { get; set; }
        /// <summary>
        /// Id  de la sucursal
        /// </summary>
         int? SucursalId { get; set; }

        /// <summary>
        /// Nombre  de la sucursal
        /// </summary>
         string NombreSucursal { get; set; }

        /// <summary>
        /// Id  del punto de  venta
        /// </summary>
         int? PuntoVentaId { get; set; }

        /// <summary>
        /// Nombre del punto de  venta
        /// </summary>
         string NombrePuntoVenta { get; set; }
        /// <summary>
        /// Horario de atencion del punto de  venta
        /// </summary>

         string HoraInicioPuntoVenta { get; set; }

        /// <summary>
        /// Horario de atencion del punto de  venta
        /// </summary>

         string HoraFinPuntoVenta { get; set; }
    }
}