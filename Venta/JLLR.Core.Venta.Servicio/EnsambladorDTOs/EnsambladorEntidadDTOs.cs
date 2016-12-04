#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.Venta.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.Venta.Servicio.DTOs;
using ensamblador= JLLR.Core.Venta.Servicio.Ensamblador; 

#endregion

namespace JLLR.Core.Venta.Servicio.EnsambladorDTOs
{

    /// <summary>
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidadDTOs
    {

        #region  DECLARACIONES  E INSTANCIAS
        private readonly ensamblador.EnsambladorEntidad _ensambladorEntidad= new ensamblador.EnsambladorEntidad();
        private readonly ensamblador.EnsambladorModelo _ensambladorModelo= new ensamblador.EnsambladorModelo();
        #endregion

        #region ORDEN TRABAJO DTO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.OrdenTrabajoDTOs CrearOrdenTrabajotOs(modeloDTOs.OrdenTrabajoDTOs m)
        {
            return new entidadDTOs.OrdenTrabajoDTOs()
            {
                OrdenTrabajo = _ensambladorEntidad.CrearOrdenTrabajo( m.OrdenTrabajo),
                DetalleOrdenTrabajos = _ensambladorEntidad.CrearDetalleOrdenesTrabajo(m.DetalleOrdenTrabajo)
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.OrdenTrabajoDTOs> CrearOrdenesTrabajotOs(List<modeloDTOs.OrdenTrabajoDTOs> listadoModelo)
        {
            List<entidadDTOs.OrdenTrabajoDTOs> listaEntidad = new List<entidadDTOs.OrdenTrabajoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearOrdenTrabajotOs(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region CONSULTA ORDEN DE  TRABAJO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidadDTOs.ConsultaOrdenTrabajoDTOs CrearConsultaOrdenTrabajoDTOs(modeloDTOs.ConsultaOrdenTrabajoDTOs m)
        {
            return new entidadDTOs.ConsultaOrdenTrabajoDTOs()
            {
               EstadoPago = m.EstadoPago,
               TipoLavado = m.TipoLavado,
               Marca = m.Marca,
               NumeroOrden = m.NumeroOrden,
               FechaIngreso = m.FechaIngreso,
               FechaEntrega = m.FechaEntrega,
               ValorUnitario = m.ValorUnitario,
               Cantidad = m.Cantidad,
               Color = m.Color,
               Prenda = m.Prenda,
               ValorTotal = m.ValorTotal,
               NombreCliente = m.NombreCliente,
               Observacion = m.Observacion
              
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidadDTOs.ConsultaOrdenTrabajoDTOs> CrearConsultaOrdenesTrabajoDTOs(List<modeloDTOs.ConsultaOrdenTrabajoDTOs> listadoModelo)
        {
            List<entidadDTOs.ConsultaOrdenTrabajoDTOs> listaEntidad = new List<entidadDTOs.ConsultaOrdenTrabajoDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearConsultaOrdenTrabajoDTOs(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}