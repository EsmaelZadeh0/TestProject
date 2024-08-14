using Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder()
.ConfigureServices((hostContext, services) =>
{
    services.AddHttpClient();
    services.AddTransient<SendRequestToServer>();
}).UseConsoleLifetime();

var host = builder.Build();

using (var serviceScope = host.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    try
    {
        var myService = services.GetRequiredService<SendRequestToServer>();
        Random random = new();

        for (int i = 0; i < 10; i++)
        {
            IEnumerable<int> randomNumbers = GenerateRandomNumbers(5, 1, 3000);
            var cpuProcess = 1 + (random.NextDouble() * (100 - 1));
            var ramProcess = 1 + (random.NextDouble() * (100 - 1));
            Console.WriteLine();
            await myService.MakeRequest(cpuProcess, ramProcess, randomNumbers);
            Console.WriteLine($" Client Of  = {i} : NUmbers = {string.Join(", ", randomNumbers)}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error Occured : {ex.Message} ");
    }
}

static List<int> GenerateRandomNumbers(int count, int minValue, int maxValue)
{
    Random random = new();
    List<int> numbers = [];

    for (int i = 0; i < count; i++)
    {
        numbers.Add(random.Next(minValue, maxValue));
    }
    return numbers;
}