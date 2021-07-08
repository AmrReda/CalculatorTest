using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CalculatorTest.Console.Helpers
{
    public static class ApiHelper
    {
        public static HttpClient InitializeClient()
        {
            var apiClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44344/api/values/")
            };
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return apiClient;
        }
    }
}