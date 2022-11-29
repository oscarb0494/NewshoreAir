using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using Domain.Models.Third;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        private readonly IMap<Journey,List<FlightResponse>> _map;
        public DisponibilityBusiness(
            IWebService service,
            IConfiguration configuration,
            IMapper mapper,
            IMap<Journey,List<FlightResponse>> map
            ) {
            _webService = service;
            _configuration = configuration;
            _mapper = mapper;
            _map = map;
        
        }
        public Journey GetDisponibility(Request disponibilityRequest)
        {
            Journey journey = new Journey();
            string result = _webService.GetHTTPService(_configuration.GetSection("AppSettings").GetSection("URLExternalServices").Value);
            var flightsResponse = JsonConvert.DeserializeObject<List<FlightResponse>>(result);
            journey = _map.Map(flightsResponse);
            return journey;
        }
    }
}
