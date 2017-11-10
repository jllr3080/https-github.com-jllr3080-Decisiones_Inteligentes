#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.Individuo.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.Individuo.Servicio.DTOs;
using  ensamblador=JLLR.Core.Individuo.Servicio.Ensamblador;
#endregion
namespace JLLR.Core.Individuo.Servicio.EnsambladorDTOs
{
    /// <summary>
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidadDTOs
    {
        #region  DECLARACIONES  E INSTANCIAS
        private readonly ensamblador.EnsambladorEntidad _ensambladorEntidad = new ensamblador.EnsambladorEntidad();
        private readonly ensamblador.EnsambladorModelo _ensambladorModelo = new ensamblador.EnsambladorModelo();
        #endregion

        #region ClienteDTOs
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.ClienteDTOs CrearClienteDTOS(modeloDTOs.ClienteDTOs m)
        {
            return new entidadDTOs.ClienteDTOs()
            {
             IndividuoId = m.IndividuoId,
             TelefonoCliente = m.TelefonoCliente,
             DireccionCliente = m.DireccionCliente,
             NombreCompleto = m.NombreCompleto,
             ClienteId = m.ClienteId,
             NumeroDocumento = m.NumeroDocumento
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.ClienteDTOs> CrearClientesDTOS(List<modeloDTOs.ClienteDTOs> listadoModelo)
        {
            List<entidadDTOs.ClienteDTOs> listaEntidad = new List<entidadDTOs.ClienteDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearClienteDTOS(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region ClienteGeneralDTOs
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.ClienteGeneralDTOs CrearClienteGeneralDTOS(modeloDTOs.ClienteGeneralDTOs m)
        {
            if (m == null)
                return null;
            return new entidadDTOs.ClienteGeneralDTOs()
            {
               Individuo = _ensambladorEntidad.CrearIndividuo(m.Individuo),
               Direccion = _ensambladorEntidad.CrearDireccion(m.Direccion),
               Telefono = _ensambladorEntidad.CrearTelefono(m.Telefono),
               CorreoElectronico = _ensambladorEntidad.CrearCorreoElectronico(m.CorreoElectronico),
               Cliente = _ensambladorEntidad.CrearCliente(m.Cliente),
               IndividuoRol = _ensambladorEntidad.CrearIndividuoRol(m.IndividuoRol),
               NombreCompleto = m.NombreCompleto,
               DireccionCompleta = m.DireccionCompleta,
               Telefonos =m.Telefonos!=null? _ensambladorEntidad.CrearTelefonos(m.Telefonos):null

            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.ClienteGeneralDTOs> CrearClientesGeneralDTOS(List<modeloDTOs.ClienteGeneralDTOs> listadoModelo)
        {
            List<entidadDTOs.ClienteGeneralDTOs> listaEntidad = new List<entidadDTOs.ClienteGeneralDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearClienteGeneralDTOS(modelo));
            }
            return listaEntidad;

        }
        #endregion


        #region PROVEEDOR
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.ProveedorDTOs CrearProveedorDtOs(modeloDTOs.ProveedorDTOs m)
        {
            if (m == null)
                return null;
            return new entidadDTOs.ProveedorDTOs()
            {
                Individuo = _ensambladorEntidad.CrearIndividuo(m.Individuo),
                Direccion = _ensambladorEntidad.CrearDireccion(m.Direccion),
                Telefono = _ensambladorEntidad.CrearTelefono(m.Telefono),
                CorreoElectronico = _ensambladorEntidad.CrearCorreoElectronico(m.CorreoElectronico),
                Proveedor = _ensambladorEntidad.CrearProveedor(m.Proveedor),
                IndividuoRol = _ensambladorEntidad.CrearIndividuoRol(m.IndividuoRol)

            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.ProveedorDTOs> CrearProveedorDtOses(List<modeloDTOs.ProveedorDTOs> listadoModelo)
        {
            List<entidadDTOs.ProveedorDTOs> listaEntidad = new List<entidadDTOs.ProveedorDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearProveedorDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}