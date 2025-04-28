using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BackEnd.DTO;
using BackEnd.Services.Interface;
using Newtonsoft.Json;

namespace BackEnd.Services.Implementation
{
    public class VeloremitService : IVeloremitService
    {
         private readonly HttpClient _httpClient;

        public VeloremitService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<ExchangeRateDTO> GetExchangeRateAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("X-Partner-Key", "lijSBHJ@8obu3h832hshbnxj3782");
            var httpResponse = await _httpClient.GetAsync("https://k4ys4w9a3h.execute-api.eu-west-1.amazonaws.com/api/Partners/get-exchange-rate?FromCurrency=GBP&ToCurrency=NGN");
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var rateResponse = JsonConvert.DeserializeObject<GetVeloRemitRateDTO>(responseString);
                if (rateResponse.status) 
                {
                    return new ExchangeRateDTO
                    {
                        rate = rateResponse.data.exchangeRate, 
                        fromCurrency = rateResponse.data.fromCurrency,
                        toCurrency = rateResponse.data.toCurrency
                    };
                }
            }
            return null;
        }

        public Task<string> SetRate(ExchangeRateDTO exchangeRateDTO)
        { 
            if( exchangeRateDTO.fromCurrency.ToLower() != "gbp") {
                return Task.FromResult("From currency not supported,only GBP is supported");
            }
            if( exchangeRateDTO.toCurrency.ToLower() != "ngn") {
                return Task.FromResult("To currency not supported, we only support NGN."); 
            }
            return Task.FromResult("Rate changed successfully!");
        }
    } 
}