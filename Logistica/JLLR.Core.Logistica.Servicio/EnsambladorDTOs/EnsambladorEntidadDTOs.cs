#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.Logistica.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.Logistica.Servicio.DTOs;
using ensamblador = JLLR.Core.Logistica.Servicio.Ensamblador;
#endregion
namespace JLLR.Core.Logistica.Servicio.EnsambladorDTOs
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

        #region ENTREGA ORDEN DE  TRABAJO DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.EntregaOrdenTrabajoDTOs CrearEntregaOrdenTrabajoDtOs(modeloDTOs.EntregaOrdenTrabajoDTOs m)
        {
            return new entidadDTOs.EntregaOrdenTrabajoDTOs()
            {
                EntregaOrdenTrabajo = _ensambladorEntidad.CrearEntregaOrdenTrabajo(m.EntregaOrdenTrabajo),
                DetalleEntregaOrdenTrabajo = _ensambladorEntidad.CrearDetallesEntregaOrdenTrabajo(m.DetalleEntregaOrdenTrabajo)
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.EntregaOrdenTrabajoDTOs> CrearEntregasOrdenTrabajoDtOs(List<modeloDTOs.EntregaOrdenTrabajoDTOs> listadoModelo)
        {
            List<entidadDTOs.EntregaOrdenTrabajoDTOs> listaEntidad = new List<entidadDTOs.EntregaOrdenTrabajoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearEntregaOrdenTrabajoDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion

    }
}