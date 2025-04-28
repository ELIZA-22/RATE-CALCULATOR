using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DTO;

namespace BackEnd.Services.Interface
{
    public interface IVeloremitService
    {
        Task<ExchangeRateDTO> GetExchangeRateAsync();
        Task<string> SetRate(ExchangeRateDTO exchangeRateDTO);
    }
}