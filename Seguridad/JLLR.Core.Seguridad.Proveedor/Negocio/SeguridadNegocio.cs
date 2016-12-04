#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Seguridad.Proveedor.DAOs;
using JLLR.Core.Seguridad.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Seguridad.Proveedor.Negocio
{

    /// <summary>
    /// Todos los metodos acerca del  negocio de  seguridades
    /// </summary>
   public class SeguridadNegocio
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly TransaccionalDAOs _transaccionalDaOs= new TransaccionalDAOs();
        #endregion
        #region TRANSACCIONAL
        /// <summary>
        /// Ingresa al sistema 
        /// </summary>
        /// <param name="nombreusuario"></param>
        /// <param name="claveUsuario"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        public UsuarioDTOs IngresoSistema(string nombreusuario, string claveUsuario, int puntoVentaId, int sucursalId)
        {
            try
            {
                return _transaccionalDaOs.IngresoSistema(nombreusuario, claveUsuario, puntoVentaId, sucursalId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Genera el menu  de acuerdo al usuario  revisa  el perfil
        /// </summary>
        /// <param name="usuarioId"></param>
        public IQueryable<AccesoDTOs> GenerarMenu(int usuarioId)
        {

            try
            {
                return _transaccionalDaOs.GenerarMenu(usuarioId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
