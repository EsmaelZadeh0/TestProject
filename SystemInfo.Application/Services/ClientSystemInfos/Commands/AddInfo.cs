using MediatR;
using SystemInfo.Application.Interfaces.Storages;
using SystemInfo.Domain.Entities;

namespace SystemInfo.Application.Services.ClientSystemInfos.Commands;

public struct AddInfo
{
    public class Command : IRequest<Response>
    {
        public double CpuProcess { get; set; }
        public double RamProcess { get; set; }
        public IEnumerable<int> Numbers { get; set; }
    }

    public readonly struct Handler(IStorage storage) : IRequestHandler<Command, Response>
    {
        private readonly IStorage _storage = storage;

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            int numbersSum = 0;
            if (request == null)
            {
                return new Response(false);
            }
            numbersSum = request.Numbers.Where(p => p < 1000).Sum();
            var response = new ClientSystemInfo(request.CpuProcess, request.RamProcess, numbersSum);
            _storage.ClientSystemInfos.Add(response);
            await _storage.SaveChangesAsync(cancellationToken);

            return new Response(true);
        }
    }

    public record struct Response(bool IsSuccess);

}


