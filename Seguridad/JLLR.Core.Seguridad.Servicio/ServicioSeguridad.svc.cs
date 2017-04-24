#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Seguridad.Servicio.DTOs;
using JLLR.Core.Seguridad.Servicio.Modelo;
using JLLR.Core.Seguridad.Servicio.Transformador;
#endregion
namespace JLLR.Core.Seguridad.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioSeguridad : IServicioSeguridad
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly SeguridadTransformadorNegocio _seguridadTransformadorNegocio= new SeguridadTransformadorNegocio();
        #endregion
        #region TRANSACCIONAL
        /// <summary>
        /// Ingresa al sistema 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        public UsuarioDTOs IngresoSistema(string nombreusuario, string claveUsuario, int puntoVentaId, int sucursalId)
        {
            try
            {
                return _seguridadTransformadorNegocio.IngresoSistema(nombreusuario, claveUsuario, puntoVentaId,
                    sucursalId);


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Genera el menu  de acuerdo al usuario  revisa  el perfil
        /// </summary>
        /// <param name="usuarioId"></param>
        public List<AccesoDTOs> GenerarMenu(int usuarioId)
        {

            try
            {
                return _seguridadTransformadorNegocio.GenerarMenu(usuarioId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region USUARIO
        /// <summary>
        /// Graba el usuario
        /// </summary>
        /// <param name="usuario"></param>
        public UsuarioModelo GrabarUsuario(UsuarioModelo usuario)
        {

            try
            {
             return _seguridadTransformadorNegocio.GrabarUsuario(usuario);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        #endregion

        #region USUARIO PERFIL
        /// <summary>
        /// Graba  Usuario Perfil
        /// </summary>
        /// <param name="usuarioPerfil"></param>
        public void GrabarUsuarioPerfil(UsuarioPerfilModelo usuarioPerfil)
        {
            try
            {
               _seguridadTransformadorNegocio.GrabarUsuarioPerfil(usuarioPerfil);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
