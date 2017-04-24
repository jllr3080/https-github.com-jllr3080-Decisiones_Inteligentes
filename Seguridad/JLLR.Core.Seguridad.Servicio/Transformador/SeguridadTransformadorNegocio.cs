#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.Seguridad.Proveedor.Negocio;
using JLLR.Core.Seguridad.Servicio.Ensamblador;
using dtoProveedor= JLLR.Core.Seguridad.Proveedor.DTOs;
using  dtoServicio=JLLR.Core.Seguridad.Servicio.DTOs;
using entidad=JLLR.Core.Seguridad.Proveedor;
//using modelo=JLLR.Core.Seguridad.Servicio.
using JLLR.Core.Seguridad.Servicio.EnsambladorDTOs;
using JLLR.Core.Seguridad.Servicio.Modelo;

#endregion
namespace JLLR.Core.Seguridad.Servicio.Transformador
{
    /// <summary>
    /// Transforma  las  entidades a modelos de  todos los metodos
    /// </summary>
    public class SeguridadTransformadorNegocio
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly  SeguridadNegocio _seguridadNegocio= new SeguridadNegocio();
        private readonly EnsambladorEntidadDTOs _ensambladorDtOs = new EnsambladorEntidadDTOs();
        private readonly EnsambladorModeloDTOs _ensambladorModeloDtOs= new EnsambladorModeloDTOs();
        private readonly  EnsambladorEntidad _ensambladorEntidad= new EnsambladorEntidad();
        private readonly EnsambladorModelo _ensambladorModelo= new EnsambladorModelo();


        #endregion

        #region TRANSACCIONAL
        /// <summary>
        /// Ingresa al sistema 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        public  dtoServicio.UsuarioDTOs IngresoSistema(string nombreusuario, string claveUsuario, int puntoVentaId, int sucursalId)
        {
            try
            {
                return
                    _ensambladorModeloDtOs.CrearUsuarioDTOs(_seguridadNegocio.IngresoSistema(nombreusuario, claveUsuario,
                        puntoVentaId, sucursalId));
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
        public List<dtoServicio.AccesoDTOs> GenerarMenu(int usuarioId)
        {

            try
            {
                return _ensambladorModeloDtOs.CrearAccesosDTOs(_seguridadNegocio.GenerarMenu(usuarioId));
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
                return  _ensambladorModelo.CrearUsuario(_seguridadNegocio.GrabarUsuario(_ensambladorEntidad.CrearUsuario(usuario)));
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
               _seguridadNegocio.GrabarUsuarioPerfil(_ensambladorEntidad.CrearUsuarioPerfil(usuarioPerfil));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}