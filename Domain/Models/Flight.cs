using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Flight
    {
        public string Origin {get;set;}
        public string Destination { get;set;}
        public double Price { get; set; }
        public Transport Transport { get; set; }

    }
}
