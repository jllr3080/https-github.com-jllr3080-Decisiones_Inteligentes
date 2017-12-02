#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Individuo.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  de  telefono
    /// </summary>
    public class TelefonoDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Grabar  direccion
        /// </summary>
        /// <param name="telefono"></param>
        public void GrabarTelefono(TELEFONO telefono)
        {
            try
            {
                _entidad.TELEFONO.Add(telefono);
                _entidad.SaveChanges();


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza el telefono
        /// </summary>
        /// <param name="telefono"></param>
        public void ActualizaTelefono(TELEFONO telefono)
        {
            try
            {
                var original = _entidad.TELEFONO.Find(telefono.TELEFONO_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(telefono);
                    _entidad.SaveChanges();
                }
                else
                {
                    _entidad.TELEFONO.Add(telefono);
                    _entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Obtiene los numeros de  telefono 
        /// </summary>
        /// <param name="individuoId"></param>
        /// <returns></returns>
        public IQueryable<TELEFONO> ObtenerTelefonosPorIndividuoId(int individuoId)
        {
            try
            {
                var telefonos = from telefono in _entidad.TELEFONO
                    where telefono.INDIVIDUO_ID == individuoId
                    select telefono;

                return telefonos;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }



        /// <summary>
        /// Eliminar  los  telefonos
        /// </summary>
        /// <param name="telefono"></param>
        public void EliminaTelefono(TELEFONO telefono)
        {
            try
            {

                _entidad.Entry(telefono).State = System.Data.Entity.EntityState.Deleted;
                _entidad.SaveChanges();


                

            }
            catch (Exception ex)
            {
                    
                throw;
            }
        }
    }
}
