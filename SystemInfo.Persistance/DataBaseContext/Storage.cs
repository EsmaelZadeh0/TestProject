using Microsoft.EntityFrameworkCore;
using SystemInfo.Application.Interfaces.Storages;
using SystemInfo.Domain.Entities;

namespace SystemInfo.Persistance.DataBaseContext;

public class Storage(DbContextOptions options) : DbContext(options), IStorage
{
    public DbSet<ClientSystemInfo> ClientSystemInfos { get; set; }

}

