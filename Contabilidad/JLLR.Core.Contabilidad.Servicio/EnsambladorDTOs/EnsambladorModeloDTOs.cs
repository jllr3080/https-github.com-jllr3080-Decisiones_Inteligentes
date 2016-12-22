﻿#region using
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
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModeloDTOs
    {
        #region  DECLARACIONES  E INSTANCIAS
        private readonly ensamblador.EnsambladorEntidad _ensambladorEntidad = new ensamblador.EnsambladorEntidad();
        private readonly ensamblador.EnsambladorModelo _ensambladorModelo = new ensamblador.EnsambladorModelo();
        #endregion

        #region CUENTA POR COBRAR DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.CuentaPorCobrarDTOs CreaCuentaPorCobrarDtOs(modeloDTOs.CuentaPorCobrarDTOs m)
        {
            return new entidadDTOs.CuentaPorCobrarDTOs()
            {
                CuentaPorCobrar = _ensambladorEntidad.CrearCuentaPorCobrar(m.CuentaPorCobrar),
                DetalleCuentaPorCobrar = _ensambladorEntidad.CrearDetalleCuentasPorCobrar(m.DetalleCuentaPorCobrar)
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.CuentaPorCobrarDTOs> CreaCuentasPorCobrarDtOs(List<modeloDTOs.CuentaPorCobrarDTOs> listadoModelo)
        {
            List<entidadDTOs.CuentaPorCobrarDTOs> listaEntidad = new List<entidadDTOs.CuentaPorCobrarDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CreaCuentaPorCobrarDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}