using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DTO;

namespace BackEnd.Models
{
    public class ExchangeRate
    {
        private  double Rate { get; set; }
        private  string FromCurrency { get; set; }
        private  string ToCurrency { get; set; }
        // public ExchangeRate( double rate ,string fromCurrency, string toCurrency)
        // {
              
        //       Rate = rate;
        //       FromCurrency= fromCurrency;
        //       ToCurrency = toCurrency;
        // }
        // public void ChangeRate(double newRate){
        //     Rate =newRate;
        // }
        // public ExchangeRateDTO GetRate()
        // {
        //    return new ExchangeRateDTO(rate: Rate ,fromCurrency :FromCurrency, toCurrency:ToCurrency);
        // }
    }
}