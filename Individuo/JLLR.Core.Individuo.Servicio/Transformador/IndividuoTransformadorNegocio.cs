#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.Individuo.Proveedor.DAOs;
using JLLR.Core.Individuo.Proveedor.Negocio;
using JLLR.Core.Individuo.Servicio.DTOs;
using JLLR.Core.Individuo.Servicio.Ensamblador;
using JLLR.Core.Individuo.Servicio.EnsambladorDTOs;
using JLLR.Core.Individuo.Servicio.Modelo;

#endregion
namespace JLLR.Core.Individuo.Servicio.Transformador
{
    /// <summary>
    /// Transforma los metodos de  entidades a  negocio
    /// </summary>
    public class IndividuoTransformadorNegocio
    {

        #region DECLARACIONES  E INSTANCIAS
        private readonly IndividuoNegocio _individuoNegocio = new IndividuoNegocio();
        private readonly EnsambladorEntidadDTOs _ensambladorEntidadDtOs = new EnsambladorEntidadDTOs();
        private readonly EnsambladorModeloDTOs _ensambladorModeloDtOs = new EnsambladorModeloDTOs();
        private readonly EnsambladorEntidad _ensambladorEntidad= new EnsambladorEntidad();
        private readonly EnsambladorModelo _ensambladorModelo = new EnsambladorModelo();
        #endregion

        #region TRANSACCIONAL

        #region CLIENTE

        /// <summary>
        /// Obtiene el cliente completo por  numero  de documento
        /// </summary>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <returns></returns>
        public List<ClienteGeneralDTOs> ObtenerClientePorApellidos(string primerApellido, string segundoApellido)
        {
            try
            {
                return  _ensambladorModeloDtOs.CrearClientesGeneralDTOs(_individuoNegocio.ObtenerClientePorApellidos(primerApellido, segundoApellido));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Obtiene   la informacion del cliente
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        public ClienteDTOs ObtenerDatosClientePorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                
                return _ensambladorModeloDtOs.CrearClienteDTOs(_individuoNegocio.ObtenerDatosClientePorNumeroIdentificacion(numeroIdentificacion));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene   la informacion del cliente
        /// </summary>
        /// <param name="apellidoPaterno"></param>
        /// <param name="apellidoMaterno"></param>
        /// <returns></returns>
        public List<ClienteDTOs> ObtenerDatosClientePorApellidos(string apellidoPaterno, string apellidoMaterno)
        {
            try
            {
                return _ensambladorModeloDtOs.CrearClientesDTOs(_individuoNegocio.ObtenerDatosClientePorApellidos(apellidoPaterno,apellidoMaterno));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Grabar cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        public ClienteModelo GrabarCliente(ClienteGeneralDTOs clienteGeneralDtOs)
        {
            try
            {
                return _ensambladorModelo.CrearCliente(_individuoNegocio.GrabarCliente(_ensambladorEntidadDtOs.CrearClienteGeneralDTOS(clienteGeneralDtOs)));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualza  el  cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        public void ActualizarCliente(ClienteGeneralDTOs clienteGeneralDtOs)
        {
            
            try
            {
                _individuoNegocio.ActualizarCliente(_ensambladorEntidadDtOs.CrearClienteGeneralDTOS(clienteGeneralDtOs));

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Obtiene el cliente completo por  numero  de documento
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        public ClienteGeneralDTOs ObtenerClientePorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                return _ensambladorModeloDtOs.CrearClienteGeneralDTOs(_individuoNegocio.ObtenerClientePorNumeroIdentificacion(numeroIdentificacion));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region PROVEEDOR
        /// <summary>
        /// Grabar Proveedor
        /// </summary>
        /// <param name="proveedorDtOs"></param>
        /// <returns></returns>
        public ProveedorModelo GrabarProveedor(ProveedorDTOs proveedorDtOs)
        {

            try
            {
                return
                    _ensambladorModelo.CrearProveedor(
                        _individuoNegocio.GrabarProveedor(_ensambladorEntidadDtOs.CrearProveedorDtOs(proveedorDtOs)));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualza  el  cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        public void ActualizarProveedor(ProveedorDTOs proveedorDtOs)
        {
            try
            {
                _individuoNegocio.ActualizarProveedor(_ensambladorEntidadDtOs.CrearProveedorDtOs(proveedorDtOs));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Obtiene el proveedor completo por  numero  de documento
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        public ProveedorDTOs ObtenerProveedorPorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                return
                    _ensambladorModeloDtOs.CrearProveedorDtOs(
                        _individuoNegocio.ObtenerProveedorPorNumeroIdentificacion(numeroIdentificacion));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #endregion

        #region VALIDACIONES
        #region CLIENTE
        /// <summary>
        /// Validar si el cliente ya existe  
        /// </summary>
        /// <returns></returns>
        public bool ValidarExistenciaClientePorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                return _individuoNegocio.ValidarExistenciaClientePorNumeroIdentificacion(numeroIdentificacion);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #endregion
    }
}