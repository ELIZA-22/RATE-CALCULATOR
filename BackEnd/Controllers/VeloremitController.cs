using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using BackEnd.DTO;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Services.Interface;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeloremitController : ControllerBase
    {
        private readonly IVeloremitService _veloremitService;

        public VeloremitController (IVeloremitService veloremitService)
        {
           _veloremitService = veloremitService; 
        }

        [HttpGet("get-rate")]
        public async Task<IActionResult> GetRate()
        { 
            var response = await _veloremitService.GetExchangeRateAsync();
            return Ok(response);
        }
        
        [HttpPost("set-rate")]
        public async Task<IActionResult> SetRate([FromBody] ExchangeRateDTO exchangeRateDTO)
        { 
            var response = await _veloremitService.SetRate(exchangeRateDTO);
            return Ok(response);
        }
    }

} 