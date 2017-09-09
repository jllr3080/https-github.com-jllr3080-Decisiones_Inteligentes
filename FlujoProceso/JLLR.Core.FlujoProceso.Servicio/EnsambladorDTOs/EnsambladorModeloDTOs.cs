#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.FlujoProceso.Servicio.Ensamblador;
using entidadDTOs = JLLR.Core.FlujoProceso.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.FlujoProceso.Servicio.DTOs;
using _ensambladorGeneral = JLLR.Core.General.Servicio.Ensamblador;
#endregion
namespace JLLR.Core.FlujoProceso.Servicio.EnsambladorDTOs
{

    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModeloDTOs
    {

        private  readonly  EnsambladorModelo _ensambladorModelo= new EnsambladorModelo();

        private readonly _ensambladorGeneral.EnsambladorModelo _ensambladorGeneralModelo =
            new _ensambladorGeneral.EnsambladorModelo();

        #region HISTORIAL PROCESO  DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.HistorialProcesoDTOs CrearConsultaHistorialProcesoDtOs(entidadDTOs.HistorialProcesoDTOs m)
        {
            return new modeloDTOs.HistorialProcesoDTOs()
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
        public List<modeloDTOs.HistorialProcesoDTOs> CrearConsultaHistorialProcesosDtOs(List<entidadDTOs.HistorialProcesoDTOs> listadoModelo)
        {
            List<modeloDTOs.HistorialProcesoDTOs> listaEntidad = new List<modeloDTOs.HistorialProcesoDTOs>();

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
        public modeloDTOs.HistorialReprocesoDTOs CrearHistorialReprocesoDtOs(entidadDTOs.HistorialReprocesoDTOs m)
        {
            return new modeloDTOs.HistorialReprocesoDTOs()
            {
               HistorialProceso = _ensambladorModelo.CrearHistorialProceso(m.HistorialProceso),
               HistorialReprocesos = _ensambladorModelo.CrearListaHistorialReprocesos(m.HistorialReprocesos)

            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.HistorialReprocesoDTOs> CrearHistorialReprocesosDtOs(List<entidadDTOs.HistorialReprocesoDTOs> listadoModelo)
        {
            List<modeloDTOs.HistorialReprocesoDTOs> listaEntidad = new List<modeloDTOs.HistorialReprocesoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearHistorialReprocesoDtOs(modelo));
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
        public modeloDTOs.DetalleHistorialReprocesoDTOs CreardeDetalleHistorialReprocesoDtOs(entidadDTOs.DetalleHistorialReprocesoDTOs m)
        {
            return new modeloDTOs.DetalleHistorialReprocesoDTOs()
            {
              //HistorialReproceso = _ensambladorModelo.CrearHistorialReproceso(m.HistorialReproceso),
              //DetalleHistorialReproceso = _ensambladorModelo.CrearDetalleHistorialReproceso(m.DetalleHistorialReproceso),
              //TipoReproceso = _ensambladorGeneralModelo.CrearTipoReproceso(m.TipoReproceso)

                Motivo = m.Motivo,
                TipoMotivoProceso = m.TipoMotivoProceso

            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.DetalleHistorialReprocesoDTOs> CreardeDetalleHistorialReprocesoDtOses(IQueryable<entidadDTOs.DetalleHistorialReprocesoDTOs> listadoModelo)
        {
            List<modeloDTOs.DetalleHistorialReprocesoDTOs> listaEntidad = new List<modeloDTOs.DetalleHistorialReprocesoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CreardeDetalleHistorialReprocesoDtOs(modelo));
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
        public modeloDTOs.ReprocesoDTOs CrearReprocesoDtOs(entidadDTOs.ReprocesoDTOs e)
        {
            return new modeloDTOs.ReprocesoDTOs()
            {
               Color = e.Color,
               FechaReproceso = e.FechaReproceso,
               Marca = e.Marca,
               NombrePrenda = e.NombrePrenda,
               TipoReproceso = e.TipoReproceso,
               NumeroOrden = e.NumeroOrden,
               TratamientoEspecial = e.TratamientoEspecial,
               Motivo = e.Motivo,
               InformacionVisual = e.InformacionVisual,
               EstadoPrenda = e.EstadoPrenda
             


            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.ReprocesoDTOs> CrearReprocesoDtOses(IQueryable<entidadDTOs.ReprocesoDTOs> listadoModelo)
        {
            List<modeloDTOs.ReprocesoDTOs> listaEntidad = new List<modeloDTOs.ReprocesoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearReprocesoDtOs(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}