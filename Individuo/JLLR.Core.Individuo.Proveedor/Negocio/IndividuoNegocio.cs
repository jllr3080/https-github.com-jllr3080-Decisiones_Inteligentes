#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Individuo.Proveedor.DAOs;
using JLLR.Core.Individuo.Proveedor.DTOs;
using JLLR.Core.Individuo.Proveedor.Validacion;

#endregion

namespace JLLR.Core.Individuo.Proveedor.Negocio
{
    /// <summary>
    /// Metodos de  negocio del  individuo
    /// </summary>
    public class IndividuoNegocio
    {

        #region DECLARACIONES  E INSTANCIAS

        private readonly TransaccionalDAOs _transaccionalDaOs = new TransaccionalDAOs();
        private  readonly  ValidacionNegocioDAOs _validacionNegocioDaOs= new ValidacionNegocioDAOs();
        #endregion

        #region TRANSACCIONAL

        #region CLIENTE

        /// <summary>
        /// Obtiene el cliente completo por  numero  de documento
        /// </summary>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <returns></returns>
        public IQueryable<ClienteGeneralDTOs> ObtenerClientePorApellidos(string primerApellido, string segundoApellido)
        {
            try
            {
                return _transaccionalDaOs.ObtenerClientePorApellidos(primerApellido, segundoApellido);
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
                return _transaccionalDaOs.ObtenerDatosClientePorNumeroIdentificacion(numeroIdentificacion);
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
        public IQueryable<ClienteDTOs> ObtenerDatosClientePorApellidos(string apellidoPaterno, string apellidoMaterno)
        {
            try
            {
                return _transaccionalDaOs.ObtenerDatosClientePorApellidos(apellidoPaterno,apellidoMaterno);
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
        public CLIENTE GrabarCliente(ClienteGeneralDTOs clienteGeneralDtOs)
        {
            try
            {
                return  _transaccionalDaOs.GrabarCliente(clienteGeneralDtOs);
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
                    _transaccionalDaOs.ActualizarCliente(clienteGeneralDtOs);
            
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
                return _transaccionalDaOs.ObtenerClientePorNumeroIdentificacion(numeroIdentificacion);
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
        public PROVEEDOR GrabarProveedor(ProveedorDTOs proveedorDtOs)
        {

            try
            {
                return _transaccionalDaOs.GrabarProveedor(proveedorDtOs);
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
                 _transaccionalDaOs.ActualizarProveedor(proveedorDtOs);
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
                return _transaccionalDaOs.ObtenerProveedorPorNumeroIdentificacion(numeroIdentificacion);
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
                return _validacionNegocioDaOs.ValidarExistenciaClientePorNumeroIdentificacion( numeroIdentificacion);
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
