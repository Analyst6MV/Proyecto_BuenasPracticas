using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FuncionesAdicionales
{
    public class Fecha
    {


        public DateTimeOffset FechaActual() 
        {
            TimeZoneInfo ZonaHorariaColombia = TimeZoneInfo.FindSystemTimeZoneById("America/Bogota");

    
            DateTimeOffset FechaActual = DateTimeOffset.Now;


           FechaActual = TimeZoneInfo.ConvertTime(FechaActual, ZonaHorariaColombia);

            return FechaActual;



        }

    }
}
