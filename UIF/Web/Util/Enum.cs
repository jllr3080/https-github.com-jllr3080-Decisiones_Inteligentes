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

    public enum TipoLavado
    {
        LavadoSeco=1,
        LavadoPorLibras=2,
        Tintoreria=3,
        ArregloPrendas=4
    }

}