using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using BackEnd.DTO;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private static ExchangeRate exchangeRate =new ExchangeRate( 2200, "GBP", "NGN");
        public RateController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
       
        [HttpGet("get-rate")]
        public async Task<IActionResult> GetRate()
        { 
            
            { 
            var response = await _httpclient.GetVeloremitRate(RateDTO);
            return Ok(response);
          
        }
        [HttpPost("set-rate")]
        public IActionResult SetRate([FromBody] ExchangeRateDTO exchangeRateDTO)
        { 
            if( exchangeRateDTO.fromCurrency.ToLower() != "gbp") {
                return BadRequest("From currency not supported,only GBP is supported");
            }
            if( exchangeRateDTO.toCurrency.ToLower() != "ngn") {
                return BadRequest("To currency not supported, we only support NGN."); 
            }
            exchangeRate.ChangeRate(exchangeRateDTO.rate);
            return Ok(new {
                Message = "Rate changed successfully!"
            });
        }
    }

         
} 