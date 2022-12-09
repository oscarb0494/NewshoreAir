﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public  interface IDisponibilityBusiness
    {
        IEnumerable<Flight> GetDisponibility(Request disponibilityRequest);
    }
}
