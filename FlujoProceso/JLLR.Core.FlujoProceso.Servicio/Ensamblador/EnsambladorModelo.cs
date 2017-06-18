#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.FlujoProceso.Servicio.ServicioDelegado;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.FlujoProceso.Servicio.Modelo;
using modeloGeneral=JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.FlujoProceso.Servicio.Ensamblador
{

    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModelo
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly  ServicioDelegadoGeneral _servicioDelegadoGeneral= new ServicioDelegadoGeneral();
        #endregion          

        #region  HISTORIAL PROCESO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.HistorialProcesoModelo CrearHistorialProceso(entidad.HISTORIAL_PROCESO e)
        {
            modeloGeneral.EtapaProcesoModelo etapaProceso =_servicioDelegadoGeneral.ObtenerEtapaProcesoPorEtapaProcesoId(Convert.ToInt32(e.ETAPA_PROCESO_ID));
            
            return new modelo.HistorialProcesoModelo
            {
                HistorialProcesoId = e.HISTORIAL_PROCESO_ID,
                OrdenTrabajoId =Convert.ToInt32( e.ORDEN_TRABAJO_ID),
                NumeroOrden = e.NUMERO_ORDEN,
                FechaRegistro = e.FECHA_REGISTRO,
                FechaInicio = e.FECHA_INICIO,
                FechaFin = e.FECHA_FIN,
                EtapaProceso = etapaProceso,
                Texto = e.TEXTO,
                PuntoVentaId = e.PUNTO_VENTA_ID,
                SucursalId = e.SUCURSAL_ID,
                DetalleOrdenTrabajoId = e.DETALLE_ORDEN_TRABAJO_ID,
                PerfilId = e.PERFIL_ID,
                UsuarioRecibeId = e.USUARIO_RECIBE_ID,
                UsuarioEntregaId = e.USUARIO_ENTREGA_ID,
                PasoPorEstaEtapa = e.PASO_ESTA_ETAPA,
                SeEnvio = e.SE_ENVIO


            };

        }


        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.HistorialProcesoModelo CrearHistorialProcesosAuxiliar(entidad.HISTORIAL_PROCESO e)
        {
            modeloGeneral.EtapaProcesoModelo etapaProceso = new modeloGeneral.EtapaProcesoModelo();
            etapaProceso.EtapaProcesoId =Convert.ToInt32(e.ETAPA_PROCESO_ID);

            return new modelo.HistorialProcesoModelo
            {
                HistorialProcesoId = e.HISTORIAL_PROCESO_ID,
                OrdenTrabajoId = Convert.ToInt32(e.ORDEN_TRABAJO_ID),
                NumeroOrden = e.NUMERO_ORDEN,
                FechaRegistro = e.FECHA_REGISTRO,
                FechaInicio = e.FECHA_INICIO,
                FechaFin = e.FECHA_FIN,
                EtapaProceso = etapaProceso,
                Texto = e.TEXTO,
                PuntoVentaId = e.PUNTO_VENTA_ID,
                SucursalId = e.SUCURSAL_ID,
                DetalleOrdenTrabajoId = e.DETALLE_ORDEN_TRABAJO_ID,
                PerfilId = e.PERFIL_ID,
                UsuarioRecibeId = e.USUARIO_RECIBE_ID,
                UsuarioEntregaId = e.USUARIO_ENTREGA_ID,
                PasoPorEstaEtapa = e.PASO_ESTA_ETAPA,
                SeEnvio = e.SE_ENVIO


            };

        }
        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.HistorialProcesoModelo> CrearHistorialProcesos(IQueryable<entidad.HISTORIAL_PROCESO> listadoEntidad)
        {
            List<modelo.HistorialProcesoModelo> listaModelo = new List<modelo.HistorialProcesoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearHistorialProceso(entidad));
            }
            return listaModelo;

        }
        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.HistorialProcesoModelo> CrearHistorialProcesosAuxiliar(IQueryable<entidad.HISTORIAL_PROCESO> listadoEntidad)
        {
            List<modelo.HistorialProcesoModelo> listaModelo = new List<modelo.HistorialProcesoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearHistorialProcesosAuxiliar(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  HISTORIAL RECLAMO REPROCESO PRENDA
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.HistorialReclamoReprocesoPrendaModelo CrearHistorialReclamoReprocesoPrenda(entidad.HISTORIAL_RECLAMO_REPROCESO_PRENDA e)
        {
      

            return new modelo.HistorialReclamoReprocesoPrendaModelo
            {
                UsuarioId = e.USUARIO_ID,
                DetallePrendaOrdenTrabajoId = e.DETALLE_PRENDA_ORDEN_TRABAJO_ID,
                FechaEntrega = e.FECHA_ENTREGA,
                Fecha = e.FECHA,
                PorqueReproceso = e.PORQUE_REPROCESO,
                HistorialReclamoReprocesoPrendaId = e.HISTORIAL_RECLAMO_REPROCESO_PRENDA_ID
            };

        }
        
        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.HistorialReclamoReprocesoPrendaModelo> CrearHistorialReclamoReprocesoPrendas(IQueryable<entidad.HISTORIAL_RECLAMO_REPROCESO_PRENDA> listadoEntidad)
        {
            List<modelo.HistorialReclamoReprocesoPrendaModelo> listaModelo = new List<modelo.HistorialReclamoReprocesoPrendaModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearHistorialReclamoReprocesoPrenda(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  HISTORIAL REPROCESO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.HistorialReprocesoModelo CrearHistorialReproceso(entidad.HISTORIAL_REPROCESO e)
        {

            modelo.HistorialProcesoModelo _historialProceso= new Modelo.HistorialProcesoModelo
            {
                HistorialProcesoId =Convert.ToInt32(e.HISTORIAL_PROCESO_ID)
            };


            return new modelo.HistorialReprocesoModelo
            {
              DetallePrendaOrdenTrabajoId = e.DETALLE_PRENDA_ORDEN_TRABAJO_ID,
              Motivo = e.MOTIVO,
              HistorialProceso = _historialProceso,
              HistorialReprocesoId = e.HISTORIAL_REPROCESO_ID

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.HistorialReprocesoModelo> CrearHistorialReprocesos(IQueryable<entidad.HISTORIAL_REPROCESO> listadoEntidad)
        {
            List<modelo.HistorialReprocesoModelo> listaModelo = new List<modelo.HistorialReprocesoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearHistorialReproceso(entidad));
            }
            return listaModelo;

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.HistorialReprocesoModelo> CrearListaHistorialReprocesos(List<entidad.HISTORIAL_REPROCESO> listadoEntidad)
        {
            List<modelo.HistorialReprocesoModelo> listaModelo = new List<modelo.HistorialReprocesoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearHistorialReproceso(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}