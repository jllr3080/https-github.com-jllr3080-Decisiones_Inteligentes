#region using
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
    /// Metodos de  color
    /// </summary>
    public class ColorDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Obtiene los  colores de las prendas
        /// </summary>
        /// <returns></returns>
        public IQueryable<COLOR> ObetenerTodosColores()
        {
            try
            {
                var colores = from color in _entidad.COLOR
                              select color;

                return colores.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiene los  colores de las prendas
        /// </summary>
        /// <returns></returns>
        public IQueryable<COLOR> ObetenerColores()
        {
            try
            {
                var colores = from color in _entidad.COLOR
                              where color.ESTA_HABILITADO==true
                              select color;

                return colores.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Graba los colores
        /// </summary>
        /// <param name="color"></param>
        public void GrabarColor(COLOR color)
        {
            try
            {
                _entidad.COLOR.Add(color);
                _entidad.SaveChanges();


            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Actualiza el color
        /// </summary>
        /// <param name="color"></param>
        public void ActualizaColor(COLOR color)
        {
            try
            {
                var original = _entidad.COLOR.Find(color.COLOR_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(color);
                    _entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        
    }
}
