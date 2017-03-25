using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Util
{
    public enum TipoIndividuo
    {
        PersonaNatural = 1,
        PersonaJuridica = 2

    }

    public enum TipoRolIndividuo
    {
        Cliente = 1,
        Proveedor = 2,
        Empleado=3

    }

    public enum TipoProducto
    {
        Servicio = 1,
        Produccion = 2
       

    }

    public enum LavadoPorLibras
    {
        LavadoPorLibras=172 
    }

    public enum TipoLavado
    {
        LavadoSeco=1,
        LavadoPorLibras=2,
        Tintoreria=3,
        ArregloPrendas=4
    }

    public enum EtapaProceso
    {
        EntregaClienteHaciaFranquicia=1,
        EntregaFranquiciaHaciaTransporte=2,
        EntregaTranporteHaciaMatriz=3,
        ProcesoProduccionEtapa1=4,
        ProcesoProduccionEtapa2=5,
        EntregaMatrizHaciaTransporte=6,
        EntregaTransporteHaciaFranquicia=7,
        EntregaFranquiciaHaciaCliente=8,
        AnulacionOrdenTrabajo=9
    }

    public enum EstadoPago
    {
        Cancelado=2,
        Pendiente=1,
        Abonado=3
    }

    public enum FormaPago
    {
       Efectivo=1
    }

    public enum Sucursal
    {
        Quito=1
    }
}