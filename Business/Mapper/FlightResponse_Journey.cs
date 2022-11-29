using Domain.Contracts;
using Domain.Models;
using Domain.Models.Third;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class FlightResponse_Journey<P,T> : IMap<P,T>
    {


        P IMap<P, T>.Map(T origin)
        {
            var journey = new Journey();
            
            List<FlightResponse> flights = (List<FlightResponse>)Convert.ChangeType(origin, typeof(List<FlightResponse>));
            foreach (var flight in flights)
            {
                journey.Origin = flight.DepartureStation;
                journey.Destination = flight.ArrivalStation;
                journey.Price = flight.Price;
                
            }
            
            return (P)(object)journey; ;
        }
    }
}
