using Microsoft.EntityFrameworkCore;
using SystemInfo.Domain.Entities;

namespace SystemInfo.Application.Interfaces.Storages;

public interface IStorage
{
    DbSet<ClientSystemInfo> ClientSystemInfos { get; set; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}
