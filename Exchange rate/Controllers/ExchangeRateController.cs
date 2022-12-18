using System;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Exchange
{
    public class ExchangeRateing
    {
        public ExchangeRateing(string currency, string exchangeRate)
        {
            Currency = currency;
            ExchangeRate = exchangeRate;
        }

        public string Currency { get; set; }
        public string ExchangeRate { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        [HttpGet("{currency}")]
        public ActionResult<string> GetExchangeRate(string currency)
        {
            var exchangeRate = new ExchangeRateing(currency, GetExchangeRateFromWeb(currency));
            return Ok(exchangeRate.ToJson());
        }

        private string GetExchangeRateFromWeb(string currency)
        {
            var client = new WebClient();
            var html = client.DownloadString($"https://www.google.com/search?q={currency} to dollar");
            var regex = new Regex(@"\d+\.\d+");
            var match = regex.Match(html);
            if (match.Success)
            {
                var value = match.Value;
                return value;
            }
            else
            {
                return "NULL";
            }
        }
    }
}
