using Client.Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.Services;

public class SendRequestToServer(IHttpClientFactory httpClientFactory)
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task MakeRequest(double cpuProcess, double ramProcess, IEnumerable<int> numbers)
    {
        var data = new ClientInfoModel(cpuProcess, ramProcess, numbers);


        var httpClient = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("https://localhost:7169/Add", content);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
    }

}
