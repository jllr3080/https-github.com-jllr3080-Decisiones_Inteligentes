#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.ReglaNegocio.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.ReglaNegocio.Servicio.DTOs;
using ensamblador = JLLR.Core.ReglaNegocio.Servicio.Ensamblador;
#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.EnsambladorDTOs
{

    /// <summary>
    /// Transforma un modelo en una entidad a  nivel de DTO
    /// </summary>
    public class EnsambladorEntidadDTOs
    {
        #region REGLA DE  NEGOCIO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.ReglaDTOs CrearReglaNegocio(modeloDTOs.ReglaDTOs m)
        {
            return new entidadDTOs.ReglaDTOs()
            {
                ProductoId = m.ProductoId,
                NombreRegla = m.NombreRegla,
                ReglaId = m.ReglaId,
                Porcentaje = m.Porcentaje
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.ReglaDTOs> CrearReglasNegocio(List<modeloDTOs.ReglaDTOs> listadoModelo)
        {
            List<entidadDTOs.ReglaDTOs> listaEntidad = new List<entidadDTOs.ReglaDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearReglaNegocio(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}