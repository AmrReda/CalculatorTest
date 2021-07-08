using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorTest.Console.Helpers
{
    public class CalculatorWebVersion
    {
        private readonly HttpClient _apiClient;

        public CalculatorWebVersion(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<int> Add(int start, int amount)
        {
            int result = 0;
            var request = new HttpRequestMessage(HttpMethod.Get, $"add/{start}/{amount}");
            var response = await _apiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            result = int.Parse(resultString);
            return result;
        }

        public async Task<int> Divide(int start, int by)
        {
            int result = 0;
            var request = new HttpRequestMessage(HttpMethod.Get, $"divide/{start}/{by}");
            var response = await _apiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            result = int.Parse(resultString);
            return result;
        }

        public async Task<int> Multiply(int start, int by)
        {
            int result = 0;
            var request = new HttpRequestMessage(HttpMethod.Get, $"multiply/{start}/{by}");
            var response = await _apiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            result = int.Parse(resultString);
            return result;
        }

        public async Task<int> Subtract(int start, int amount)
        {
            int result = 0;
            var request = new HttpRequestMessage(HttpMethod.Get, $"subtract/{start}/{amount}");
            var response = await _apiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            result = int.Parse(resultString);
            return result;
        }
    }
}
