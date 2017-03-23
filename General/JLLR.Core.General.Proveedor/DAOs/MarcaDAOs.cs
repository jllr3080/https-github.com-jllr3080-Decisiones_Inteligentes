#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.General.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de  la marca  del producto
    /// </summary>
    public class MarcaDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene las marcas de las prendas
        /// </summary>
        /// <returns></returns>
        public IQueryable<MARCA> ObtenerMarcas()
        {
            try
            {
                var marcas = from marca in _entidad.MARCA
                             select marca;

                return marcas.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba las  marcas
        /// </summary>
        /// <param name="marca"></param>
       
        public void GrabarMarca(MARCA marca)
        {
            try
            {
                _entidad.MARCA.Add(marca);
                _entidad.SaveChanges();
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        ///  valida si  existe la marca ya  creada
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public MARCA ValidarSiExisteMarcaPorDescripcion(string descripcion)
        {
            try
            {
                var marcas = from marca in _entidad.MARCA
                    where marca.DESCRIPCION == descripcion
                    select marca;

                return marcas.FirstOrDefault();

            }
            catch (Exception ex)
            {
                
                throw;
            }

        }
    }
}
