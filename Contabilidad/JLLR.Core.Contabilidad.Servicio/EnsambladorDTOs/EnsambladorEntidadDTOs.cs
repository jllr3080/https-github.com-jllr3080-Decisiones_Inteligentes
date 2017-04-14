#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.Contabilidad.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.Contabilidad.Servicio.DTOs;
using ensamblador = JLLR.Core.Contabilidad.Servicio.Ensamblador;
#endregion
namespace JLLR.Core.Contabilidad.Servicio.EnsambladorDTOs
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

        #region CUENTA POR  COBRAR DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.CuentaPorCobrarDTOs CrearCuentaPorCobrarDtOs(modeloDTOs.CuentaPorCobrarDTOs m)
        {
            return new entidadDTOs.CuentaPorCobrarDTOs()
            {
                CuentaPorCobrar = _ensambladorEntidad.CrearCuentaPorCobrar(m.CuentaPorCobrar),
                Cliente = m.Cliente,
                HistorialCuentaPorCobrar = _ensambladorEntidad.CrearHistorialCuentaPorCobrar(m.HistorialCuentaPorCobrar)
              
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.CuentaPorCobrarDTOs> CrearCuentasPorCobrarDtOs(List<modeloDTOs.CuentaPorCobrarDTOs> listadoModelo)
        {
            List<entidadDTOs.CuentaPorCobrarDTOs> listaEntidad = new List<entidadDTOs.CuentaPorCobrarDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearCuentaPorCobrarDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region ASIENTO  DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.AsientoDTOs CrearAsiento(modeloDTOs.AsientoDTOs m)
        {
            return new entidadDTOs.AsientoDTOs()
            {
                CuentaPorCobrar = _ensambladorEntidad.CrearCuentaPorCobrar(m.CuentaPorCobrar),
                HistorialCuentaPorCobrar = _ensambladorEntidad.CrearHistorialCuentaPorCobrar(m.HistorialCuentaPorCobrar),
                HistorialCuentaPorPagar = _ensambladorEntidad.CrearHistorialCuentaPorPagar(m.HistorialCuentaPorPagar),
                 CuentaPorPagar = _ensambladorEntidad.CrearCuentaPorPagar(m.CuentaPorPagar)

            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.AsientoDTOs> CrearAsientos(List<modeloDTOs.AsientoDTOs> listadoModelo)
        {
            List<entidadDTOs.AsientoDTOs> listaEntidad = new List<entidadDTOs.AsientoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearAsiento(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region CUENTA POR  PAGAR DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.CuentaPorPagarDTOs CreaCuentaPorPagarDtOs(modeloDTOs.CuentaPorPagarDTOs m)
        {
            return new entidadDTOs.CuentaPorPagarDTOs()
            {
                CuentaPorPagar = _ensambladorEntidad.CrearCuentaPorPagar(m.CuentaPorPagar),
                proveedor = m.proveedor,
                HistorialCuentaPorPagar = _ensambladorEntidad.CrearHistorialCuentaPorPagar(m.HistorialCuentaPorPagar)

            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.CuentaPorPagarDTOs> CreaCuentasPorPagarDtOs(List<modeloDTOs.CuentaPorPagarDTOs> listadoModelo)
        {
            List<entidadDTOs.CuentaPorPagarDTOs> listaEntidad = new List<entidadDTOs.CuentaPorPagarDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CreaCuentaPorPagarDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}