#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.Individuo.Servicio.DTOs;
using JLLR.Core.Individuo.Servicio.Modelo;
using JLLR.Core.Individuo.Servicio.Transformador;
#endregion

namespace JLLR.Core.Individuo.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioIndividuo : IServicioIndividuo
    {

        #region DECLARACIONES  E INSTANCIAS
        private readonly IndividuoTransformadorNegocio _individuoTransformadorNegocio = new IndividuoTransformadorNegocio();
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
                return _individuoTransformadorNegocio.ObtenerClientePorApellidos(primerApellido, segundoApellido);
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
                return _individuoTransformadorNegocio.ObtenerDatosClientePorNumeroIdentificacion(numeroIdentificacion);
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
                return _individuoTransformadorNegocio.ObtenerDatosClientePorApellidos(apellidoPaterno,apellidoMaterno);
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
                    return _individuoTransformadorNegocio.GrabarCliente(clienteGeneralDtOs);
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
                _individuoTransformadorNegocio.ActualizarCliente(clienteGeneralDtOs);

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
                return _individuoTransformadorNegocio.ObtenerClientePorNumeroIdentificacion(numeroIdentificacion);
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
                return _individuoTransformadorNegocio.GrabarProveedor(proveedorDtOs);

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
                _individuoTransformadorNegocio.ActualizarProveedor(proveedorDtOs);
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
                return _individuoTransformadorNegocio.ObtenerProveedorPorNumeroIdentificacion(numeroIdentificacion);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #endregion

        #region  TELEFONO

        /// <summary>
        /// Obtiene los numeros de  telefono 
        /// </summary>
        /// <param name="individuoId"></param>
        /// <returns></returns>
        public List<TelefonoModelo> ObtenerTelefonosPorIndividuoId(int individuoId)
        {
            try
            {
                return _individuoTransformadorNegocio.ObtenerTelefonosPorIndividuoId(individuoId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Eliminar  los  telefonos
        /// </summary>
        /// <param name="telefono"></param>
        public void EliminaTelefono(TelefonoModelo telefono)
        {
            try
            {
                _individuoTransformadorNegocio.EliminaTelefono(telefono);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
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
                return _individuoTransformadorNegocio.ValidarExistenciaClientePorNumeroIdentificacion(numeroIdentificacion);
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
