#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  entidad= JLLR.Core.Base.Proveedor.Entidades;
using  modeloParametrizacion = JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion;
#endregion
namespace JLLR.Core.Inventario.Servicio.Ensamblador
{

    /// <summary>
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidad
    {


        #region PRODUCTO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.PRODUCTO CrearProducto(modeloParametrizacion.ProductoModelo m)
        {
            
            return new entidad.PRODUCTO()
            {
               PRODUCTO_ID = m.ProductoId,
               TIPO_PRODUCTO_ID = m.TipoProducto.TipoProductoId,
               MARCA_ID = m.Marca.MarcaId,
               MATERIAL_ID = m.Material.MaterialId,
               MODELO_ID = m.Modelo.ModeloId,
               NOMBRE = m.Nombre,
               FECHA_CREACION = m.FechaCreacion,
               PEDIR_MEDIDA = m.PedirMedida,
               VISIBLE = m.Visible,
               TIEMPO_ENTREGA =m.TiempoEntrega,
               PRENDA_ESPECIAL = m.PrendaEspecial,
               NUMERO_PRENDAS = m.NumeroPrendas,
               USUARIO_ID = m.UsuarioId,
               ESTA_HABILITADO = m.EstaHabilitado


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.PRODUCTO> CrearProductos(List<modeloParametrizacion.ProductoModelo> listadoModelo)
        {
            List<entidad.PRODUCTO> listaEntidad = new List<entidad.PRODUCTO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearProducto(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region PRODUCTO PRECIO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.PRODUCTO_PRECIO CrearProductoPrecio(modeloParametrizacion.ProductoPrecioModelo m)
        {

            return new entidad.PRODUCTO_PRECIO()
            {
              PRODUCTO_PRECIO_ID = m.ProductoPrecioId,
              PRODUCTO_ID = m.Producto.ProductoId,
              PRECIO = m.Precio,
              FECHA_CREACION = m.FechaCreacion,
              ESTA_HABILITADO = m.EstaHabilitado,
              MODIFICABLE = m.Modificable

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.PRODUCTO_PRECIO> CrearProductosPrecio(List<modeloParametrizacion.ProductoPrecioModelo> listadoModelo)
        {
            List<entidad.PRODUCTO_PRECIO> listaEntidad = new List<entidad.PRODUCTO_PRECIO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearProductoPrecio(modelo));
            }
            return listaEntidad;

        }
        #endregion

        

    }
}