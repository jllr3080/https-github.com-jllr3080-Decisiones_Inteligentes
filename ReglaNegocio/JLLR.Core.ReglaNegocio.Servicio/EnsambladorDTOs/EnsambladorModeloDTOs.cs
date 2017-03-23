#region using
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.ReglaNegocio.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.ReglaNegocio.Servicio.DTOs;
using ensamblador = JLLR.Core.ReglaNegocio.Servicio.Ensamblador;
#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.EnsambladorDTOs
{

    /// <summary>
    /// Transforma una entidad en un modelo DTO
    /// </summary>
    public class EnsambladorModeloDTOs
    {

        #region REGLA DE  NEGOCIO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.ReglaDTOs CrearReglaNegocio(entidadDTOs.ReglaDTOs e)
        {
            return new modeloDTOs.ReglaDTOs()
            {
                ProductoId = e.ProductoId,
                NombreRegla = e.NombreRegla,
                ReglaId = e.ReglaId,
                Porcentaje = e.Porcentaje
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.ReglaDTOs> CrearReglasNegocio(IQueryable<entidadDTOs.ReglaDTOs> listadoModelo)
        {
            List<modeloDTOs.ReglaDTOs> listaEntidad = new List<modeloDTOs.ReglaDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearReglaNegocio(modelo));
            }
            return listaEntidad;

        }

        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public Collection<modeloDTOs.ReglaDTOs> CrearReglasNegocioColeccion(List<entidadDTOs.ReglaDTOs> listadoModelo)
        {
            Collection<modeloDTOs.ReglaDTOs> listaEntidad = new Collection<modeloDTOs.ReglaDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearReglaNegocio(modelo));
            }
            return listaEntidad;

        }

        #endregion
    }
}