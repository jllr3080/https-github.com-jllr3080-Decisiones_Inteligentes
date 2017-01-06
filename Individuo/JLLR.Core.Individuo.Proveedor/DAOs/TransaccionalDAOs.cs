#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Individuo.Proveedor.DTOs;

#endregion
namespace JLLR.Core.Individuo.Proveedor.DAOs
{

    /// <summary>
    /// Metodos  generales de  la capa de  negocio de  Individuos
    /// </summary>
    public  class TransaccionalDAOs:BaseDAOs
    {
        #region DECLARACIONES E INSTANCIAS
        private Decisiones_Inteligentes entidad = new Decisiones_Inteligentes();
        private readonly  ClienteDAOs _clienteDaOs= new ClienteDAOs();
        private readonly  IndividuoDAOs _individuoDaOs= new IndividuoDAOs();
        private readonly  DireccionDAOs _direccionDaOs= new DireccionDAOs();
        private readonly  TelefonoDAOs _telefonoDaOs= new TelefonoDAOs();
        private readonly  IndividuoRolDAOs _individuoRolDaOs= new IndividuoRolDAOs();
        private readonly  CorreoElectronicoDAOs _correoElectronicoDaOs= new CorreoElectronicoDAOs();
        #endregion
        #region CLIENTE

        /// <summary>
        /// Obtiene   la informacion del cliente
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        public ClienteDTOs ObtenerDatosClientePorNumeroIdentificacion(string numeroIdentificacion)
        {
            try
            {
                var clientes = from individuo in entidad.INDIVIDUO
                    join cliente in entidad.CLIENTE on individuo.INDIVIDUO_ID equals cliente.INDIVIDUO_ID
                    join direccion in entidad.DIRECCION on individuo.INDIVIDUO_ID equals direccion.INDIVIDUO_ID
                    join telefono in entidad.TELEFONO on individuo.INDIVIDUO_ID equals telefono.INDIVIDUO_ID
                    where individuo.NUMERO_IDENTIFICACION == numeroIdentificacion
                    select
                        new ClienteDTOs
                        {
                            ClienteId = cliente.CLIENTE_ID,
                            IndividuoId = individuo.INDIVIDUO_ID,
                            DireccionCliente = direccion.DESCRIPCION_DIRECCION,
                            TelefonoCliente = telefono.NUMERO_TELEFONO,
                            NombreCompleto =
                                individuo.PRIMER_CAMPO + " " + individuo.SEGUNDO_CAMPO + " " + individuo.TERCER_CAMPO +
                                " " + individuo.CUARTO_CAMPO
                        };

              
                    return clientes.FirstOrDefault();
               

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Grabar cliente
        /// </summary>
        /// <param name="clienteGeneralDtOs"></param>
        /// <returns></returns>
        public CLIENTE GrabarCliente(ClienteGeneralDTOs clienteGeneralDtOs)
        {

            using (System.Transactions.TransactionScope transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    //Graba el  individuo
                    INDIVIDUO individuo = _individuoDaOs.GrabarIndividuo(clienteGeneralDtOs.Individuo);

                    //Graba el cliente
                    clienteGeneralDtOs.Cliente.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    CLIENTE cliente = _clienteDaOs.GrabarCliente(clienteGeneralDtOs.Cliente);

                    //Graba la direccion
                    clienteGeneralDtOs.Direccion.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _direccionDaOs.GrabarDireccion(clienteGeneralDtOs.Direccion);

                    //Graba el telefono
                    clienteGeneralDtOs.Telefono.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _telefonoDaOs.GrabarTelefono(clienteGeneralDtOs.Telefono);


                    //Graba el correo electronico
                    clienteGeneralDtOs.CorreoElectronico.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _correoElectronicoDaOs.GrabarCorreoElectronico(clienteGeneralDtOs.CorreoElectronico);

                    //Graba el correo electronico
                    clienteGeneralDtOs.IndividuoRol.INDIVIDUO_ID = individuo.INDIVIDUO_ID;
                    _individuoRolDaOs.GrabarIndividuoRol(clienteGeneralDtOs.IndividuoRol);

                    transaction.Complete();
                    return cliente;


                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        #endregion
    }
}
