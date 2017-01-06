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
        public modeloDTOs.CuentaPorCobrarDTOs CreaCuentaPorCobrarDtOs(entidadDTOs.CuentaPorCobrarDTOs e)
        {
            return new modeloDTOs.CuentaPorCobrarDTOs()
            {
                CuentaPorCobrar = _ensambladorModelo.CrearCuentaPorCobrar(e.CuentaPorCobrar),
                HistorialCuentaPorCobrar = _ensambladorModelo.CrearHistorialCuentaPorCobrar(e.HistorialCuentaPorCobrar),
                Cliente = e.Cliente
                
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.CuentaPorCobrarDTOs> CreaCuentasPorCobrarDtOs(List<entidadDTOs.CuentaPorCobrarDTOs> listadoModelo)
        {
            List<modeloDTOs.CuentaPorCobrarDTOs> listaEntidad = new List<modeloDTOs.CuentaPorCobrarDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CreaCuentaPorCobrarDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}