﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.Individuo.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.Individuo.Servicio.DTOs;
using ensamblador=JLLR.Core.Individuo.Servicio.Ensamblador;
#endregion
namespace JLLR.Core.Individuo.Servicio.EnsambladorDTOs
{
    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModeloDTOs
    {
        #region  DECLARACIONES  E INSTANCIAS
        private readonly ensamblador.EnsambladorEntidad _ensambladorEntidad = new ensamblador.EnsambladorEntidad();
        private readonly ensamblador.EnsambladorModelo _ensambladorModelo = new ensamblador.EnsambladorModelo();
        #endregion

        #region  ClienteDTOs
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloDTOs.ClienteDTOs CrearClienteDTOs(entidadDTOs.ClienteDTOs e)
        {
            if (e != null)
            { 
            return new modeloDTOs.ClienteDTOs
            {
                IndividuoId = e.IndividuoId,
                TelefonoCliente = e.TelefonoCliente,
                DireccionCliente = e.DireccionCliente,
                NombreCompleto = e.NombreCompleto,
                ClienteId = e.ClienteId,
                NumeroDocumento = e.NumeroDocumento
            };
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloDTOs.ClienteDTOs> CrearClientesDTOs(IQueryable<entidadDTOs.ClienteDTOs> listadoEntidad)
        {
            List<modeloDTOs.ClienteDTOs> listaModelo = new List<modeloDTOs.ClienteDTOs>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearClienteDTOs(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  ClienteGeneralDTOs
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloDTOs.ClienteGeneralDTOs CrearClienteGeneralDTOs(entidadDTOs.ClienteGeneralDTOs e)
        {
            if (e == null)
                return null;
            return new modeloDTOs.ClienteGeneralDTOs
            {
               Individuo = _ensambladorModelo.CrearIndividuo(e.Individuo),
               Direccion = _ensambladorModelo.CrearDireccion(e.Direccion),
               Telefono = _ensambladorModelo.CrearTelefono(e.Telefono),
               Cliente = _ensambladorModelo.CrearCliente(e.Cliente),
               CorreoElectronico = _ensambladorModelo.CrearCorreoElectronico(e.CorreoElectronico),
               IndividuoRol = _ensambladorModelo.CrearIndividuoRol(e.IndividuoRol),
               NombreCompleto = e.NombreCompleto,
               DireccionCompleta = e.DireccionCompleta,
               Telefonos =  _ensambladorModelo.CrearColeccionTelefonos(e.Telefonos)
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloDTOs.ClienteGeneralDTOs> CrearClientesGeneralDTOs(IQueryable<entidadDTOs.ClienteGeneralDTOs> listadoEntidad)
        {
            List<modeloDTOs.ClienteGeneralDTOs> listaModelo = new List<modeloDTOs.ClienteGeneralDTOs>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearClienteGeneralDTOs(entidad));
            }
            return listaModelo;

        }

        #endregion


        #region PROVEEDOR

        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloDTOs.ProveedorDTOs CrearProveedorDtOs(entidadDTOs.ProveedorDTOs e)
        {
            if (e == null)
                return null;
            return new modeloDTOs.ProveedorDTOs
            {
                Individuo = _ensambladorModelo.CrearIndividuo(e.Individuo),
                Direccion = _ensambladorModelo.CrearDireccion(e.Direccion),
                Telefono = _ensambladorModelo.CrearTelefono(e.Telefono),
                Proveedor = _ensambladorModelo.CrearProveedor(e.Proveedor),
                CorreoElectronico = _ensambladorModelo.CrearCorreoElectronico(e.CorreoElectronico),
                IndividuoRol = _ensambladorModelo.CrearIndividuoRol(e.IndividuoRol)
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloDTOs.ProveedorDTOs> CrearProveedorDtOses(IQueryable<entidadDTOs.ProveedorDTOs> listadoEntidad)
        {
            List<modeloDTOs.ProveedorDTOs> listaModelo = new List<modeloDTOs.ProveedorDTOs>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearProveedorDtOs(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}