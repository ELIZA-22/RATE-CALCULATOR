using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
    public  record ExchangeRateDTO (

    [Required] double rate ,
    [Required] string fromCurrency,
    [Required] string toCurrency
    );

    public class GetVeloRemitRateDTO 
    {
          public bool status { get; set; }
          public string message { get; set; }

          public RateDTO data { get; set; }
    }
    
    public class RateDTO
    {
          public int exchangeRate { get; set; }
          public string fromCurrency { get; set; }
          public string toCurrency { get; set; }
    }
}