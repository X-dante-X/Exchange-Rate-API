# Exchange-Rate-API
make API for currencies in USD
To use this ExchangeRateController as a user, you would need to make an HTTP GET request to the /api/exchangerate/{currency} route, where {currency} is the currency code for which you want to get the exchange rate.

For example, if you want to get the exchange rate for the British Pound (GBP), you could make a request to the /api/exchangerate/GBP route.

There are several ways you could make this request, including using a web browser, a command-line tool like curl, or a programming language like C# or Python.
And here's an example of how you could make the request using C#:

```
using System.Net.Http;

var client = new HttpClient();
var response = await client.GetAsync("http://api/exchangerate/GBP");
if (response.IsSuccessStatusCode)
{
    var exchangeRateJson = await response.Content.ReadAsStringAsync();
    var exchangeRate = JsonConvert.DeserializeObject<ExchangeRateing>(exchangeRateJson);
    // Use the exchange rate here...
}
```
If the request is successful, the response will contain a JSON string with the Currency and ExchangeRate properties of the ExchangeRateing class. You can then use these values as needed in your application.
