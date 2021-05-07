using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IskurNortwindApi.Contexts;
using IskurNortwindApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IskurNortwindApi.Infrastructure
{
    [Route("[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        
    }
}
