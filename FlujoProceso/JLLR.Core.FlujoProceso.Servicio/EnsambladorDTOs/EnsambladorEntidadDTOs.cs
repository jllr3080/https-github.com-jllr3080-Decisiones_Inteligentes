#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.FlujoProceso.Servicio.Ensamblador;
using entidadDTOs = JLLR.Core.FlujoProceso.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.FlujoProceso.Servicio.DTOs;
using  _ensambladorGeneral= JLLR.Core.General.Servicio.Ensamblador;

#endregion
namespace JLLR.Core.FlujoProceso.Servicio.EnsambladorDTOs
{
    /// <summary>
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidadDTOs
    {
        private readonly  EnsambladorEntidad  _ensambladorEntidad= new EnsambladorEntidad();
        private readonly _ensambladorGeneral.EnsambladorEntidad _ensambladorGeneralEntidad= new _ensambladorGeneral.EnsambladorEntidad();
        #region HISTORIAL PROCESO  DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.HistorialProcesoDTOs CrearConsultaHistorialProcesoDtOs(modeloDTOs.HistorialProcesoDTOs m)
        {
            return new entidadDTOs.HistorialProcesoDTOs()
            {
               NumeroOrden = m.NumeroOrden,
               OrdenTrabajoId = m.OrdenTrabajoId,
               NombrePuntoVenta = m.NombrePuntoVenta,
               UsuarioEntrega = m.UsuarioEntrega,
               UsuarioRecibe = m.UsuarioRecibe,
               NumeroPrendas = m.NumeroPrendas,
               FechaRegistro = m.FechaRegistro

            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.HistorialProcesoDTOs> CrearConsultaHistorialProcesosDtOs(List<modeloDTOs.HistorialProcesoDTOs> listadoModelo)
        {
            List<entidadDTOs.HistorialProcesoDTOs> listaEntidad = new List<entidadDTOs.HistorialProcesoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearConsultaHistorialProcesoDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region HISTORIAL REPROCESO  DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.HistorialReprocesoDTOs CrearHistorialReprocesoDtOs(modeloDTOs.HistorialReprocesoDTOs m)
        {
            return new entidadDTOs.HistorialReprocesoDTOs()
            {
               HistorialProceso = _ensambladorEntidad.CrearHistorialProceso(m.HistorialProceso),
               HistorialReprocesos = _ensambladorEntidad.CrearHistorialReprocesos(m.HistorialReprocesos)

            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.HistorialReprocesoDTOs> CrearHistorialReprocesosDtOs(List<modeloDTOs.HistorialReprocesoDTOs> listadoModelo)
        {
            List<entidadDTOs.HistorialReprocesoDTOs> listaEntidad = new List<entidadDTOs.HistorialReprocesoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearHistorialReprocesoDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion
        
        #region DETALLE  HISTORIAL REPROCESO  DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.DetalleHistorialReprocesoDTOs CreardeDetalleHistorialReprocesoDtOs(modeloDTOs.DetalleHistorialReprocesoDTOs m)
        {
            return new entidadDTOs.DetalleHistorialReprocesoDTOs()
            {
                //HistorialReproceso = _ensambladorEntidad.CrearHistorialReproceso(m.HistorialReproceso),
                //DetalleHistorialReproceso = _ensambladorEntidad.CrearDetalleHistorialReproceso(m.DetalleHistorialReproceso),
                //TipoReproceso = _ensambladorGeneralEntidad.CrearTipoReproceso(m.TipoReproceso)
                Motivo = m.Motivo,
                TipoMotivoProceso = m.TipoMotivoProceso


            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.DetalleHistorialReprocesoDTOs> CreardeDetalleHistorialReprocesoDtOses(List<modeloDTOs.DetalleHistorialReprocesoDTOs> listadoModelo)
        {
            List<entidadDTOs.DetalleHistorialReprocesoDTOs> listaEntidad = new List<entidadDTOs.DetalleHistorialReprocesoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CreardeDetalleHistorialReprocesoDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region  REPROCESO  DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.ReprocesoDTOs CrearReprocesoDtOs(modeloDTOs.ReprocesoDTOs m)
        {
            return new entidadDTOs.ReprocesoDTOs()
            {
               NumeroOrden = m.NumeroOrden,
               TratamientoEspecial = m.TratamientoEspecial,
               Motivo = m.Motivo,
               InformacionVisual = m.InformacionVisual,
               EstadoPrenda = m.EstadoPrenda,
               TipoReproceso = m.TipoReproceso,
               NombrePrenda = m.NombrePrenda,
               Marca = m.Marca,
               Color = m.Color,
               FechaReproceso = m.FechaReproceso


            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.ReprocesoDTOs> CrearReprocesoDtOses(List<modeloDTOs.ReprocesoDTOs> listadoModelo)
        {
            List<entidadDTOs.ReprocesoDTOs> listaEntidad = new List<entidadDTOs.ReprocesoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearReprocesoDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}