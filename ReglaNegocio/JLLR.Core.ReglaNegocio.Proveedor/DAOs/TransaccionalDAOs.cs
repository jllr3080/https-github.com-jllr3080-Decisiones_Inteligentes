#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.ReglaNegocio.Proveedor.DTOs;

#endregion

namespace JLLR.Core.ReglaNegocio.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  transaccionales en general
    /// </summary>
    public class TransaccionalDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias 
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtener las reglas para aplicar     
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public IQueryable<ReglaDTOs> ObtenerReglasPorPuntoVentaIdYSucursalId(int puntoVentaId, int sucursalId)
        {
            try
            {
                var reglasNegocio = from regla in _entidad.REGLA
                    join accionRegla in _entidad.ACCION_REGLA on regla.REGLA_ID equals accionRegla.REGLA_ID
                    where
                        regla.PUNTO_VENTA_ID == puntoVentaId && regla.SUCURSAL_ID == sucursalId &&
                        accionRegla.ESTA_HABILITADO == true
                    select new ReglaDTOs
                    {
                        ProductoId = accionRegla.PRODUCTO_ID,
                        NombreRegla = regla.NOMBRE_REGLA,
                        Porcentaje = accionRegla.VALOR,
                        ReglaId = regla.REGLA_ID
                    };
                return reglasNegocio.OrderBy(m=>m.NombreRegla);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Obtener las reglas para aplicar     
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public ReglaDTOs ObtenerReglasPorParametrosEntrada(ParametroEntradaReglaNegocioDTOs parametroEntradaReglaNegocio)
        {
            try
            {
                var reglasNegocio = from regla in _entidad.REGLA
                                    join accionRegla in _entidad.ACCION_REGLA on regla.REGLA_ID equals accionRegla.REGLA_ID
                                    where
                                        regla.PUNTO_VENTA_ID == parametroEntradaReglaNegocio.PuntoVentaId && regla.SUCURSAL_ID == parametroEntradaReglaNegocio.SucursalId &&
                                        accionRegla.ESTA_HABILITADO == true && accionRegla.PRODUCTO_ID== parametroEntradaReglaNegocio.ProductoId
                                    select new ReglaDTOs
                                    {
                                        ProductoId = accionRegla.PRODUCTO_ID,
                                        NombreRegla = regla.NOMBRE_REGLA,
                                        Porcentaje = accionRegla.VALOR,
                                        ReglaId = regla.REGLA_ID
                                    };
                return reglasNegocio.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Obtiene  las  promociones  vigentes 
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>

        public IQueryable<REGLA> ObtenerPromocionesVigentes(int puntoVentaId, int sucursalId)
        {
            try
            {
                var promociones = from promocion in _entidad.REGLA
                    join accionRegla in _entidad.ACCION_REGLA on promocion.REGLA_ID equals accionRegla.REGLA_ID
                    where
                        promocion.PUNTO_VENTA_ID == puntoVentaId && promocion.SUCURSAL_ID == sucursalId &&
                        accionRegla.ESTA_HABILITADO == true 
                    select promocion;


                return promociones.Distinct();


            }
            catch (Exception ex)
            {

                throw;
            }
        }


        #region ADMINISTRACION PROMOCIONES

        /// <summary>
        /// Grabar promociones
        /// </summary>
        /// <param name="reglaCompletaDtOs"></param>
        public void GrabarPromocionesCompleta(ReglaCompletaDTOs reglaCompletaDtOs)
        {
            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                  

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        /// <summary>
        /// Actualizar promociones
        /// </summary>
        /// <param name="reglaCompletaDtOs"></param>
        public void ActualizarPromocionesCompleta(ReglaCompletaDTOs reglaCompletaDtOs)
        {
            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        /// <summary>
        /// Obtiene las promociones
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>

        public IQueryable<ReglaCompletaDTOs> ObtenerPromociones(int puntoVentaId)
        {
            try
            {
                var promociones = from regla in _entidad.REGLA
                    join accionRegla in _entidad.ACCION_REGLA on regla.REGLA_ID equals accionRegla.REGLA_ID
                                  where regla.PUNTO_VENTA_ID == puntoVentaId
                    select new ReglaCompletaDTOs
                    {
                        Regla = regla,
                        AccionReglas = regla.ACCION_REGLA.ToList()
                    };

                return promociones ;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        #endregion


    }
}
