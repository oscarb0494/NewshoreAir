using AutoMapper;
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
        private readonly IMap<Transport, FlightResponse> _map;

        public FlightResponse_Journey(IMap<Transport, FlightResponse> map)
        {
            _map = map;
        }

        P IMap<P, T>.Map(T origin)
        {
            var flightResponse = new List<Flight>();
            
            List<FlightResponse> flights = (List<FlightResponse>)Convert.ChangeType(origin, typeof(List<FlightResponse>));
            foreach (var flight in flights)
            {
                var flightAux = new Flight();
                flightAux.Origin = flight.DepartureStation;
                flightAux.Destination = flight.ArrivalStation;
                flightAux.Price = flight.Price;
                flightAux.Transport = _map.Map(flight);
                flightResponse.Add(flightAux);

            }
            
            return (P)(object)flightResponse; ;
        }
    }
}
