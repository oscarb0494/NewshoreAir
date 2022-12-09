using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using Domain.Models.Third;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NLog;
using Services.IWebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DisponibilityBusiness
{
    public class DisponibilityBusiness : IDisponibilityBusiness
    {
        private readonly IWebService _webService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IMap<List<Flight>,List<FlightResponse>> _map;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DisponibilityBusiness(
            IWebService service,
            IConfiguration configuration,
            IMapper mapper,
            IMap<List<Flight>,List<FlightResponse>> map
            ) {
            _webService = service;
            _configuration = configuration;
            _mapper = mapper;
            _map = map;
        
        }
        public IEnumerable<Flight> GetDisponibility(Request disponibilityRequest)
        {
            IEnumerable<Flight> flights = new List<Flight>();
            try
            {
                string result = _webService.GetHTTPService(_configuration.GetSection("AppSettings").GetSection("URLExternalServices").Value);
                var flightsResponse = JsonConvert.DeserializeObject<List<FlightResponse>>(result);
                if(!(flightsResponse is null) && flightsResponse.Count() > (int)default)
                {
                    flights = _map.Map(flightsResponse);
                    flights = flights.Where(x=> x.Origin.ToUpper().Equals(disponibilityRequest?.Origin) && x.Destination.ToUpper().Equals(disponibilityRequest?.Destination));
                    return flights?.ToList();
                }
                
            }
            catch(Exception ex)
            {
                logger.Info($"Error while trying send Request with Server API ::Exception {JsonConvert.SerializeObject(ex)} ::URL {JsonConvert.SerializeObject(disponibilityRequest)}");

            }
            return flights;
        }
    }
}
