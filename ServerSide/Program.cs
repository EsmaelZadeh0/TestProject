using Microsoft.EntityFrameworkCore;
using SystemInfo.Application.Interfaces.Storages;
using SystemInfo.Application.Services.ClientSystemInfos.Commands;
using SystemInfo.Persistance.DataBaseContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStorage, Storage>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
                                 typeof(AddInfo).Assembly));

string connString = "Data Source =.;Initial Catalog=DbClientInfo; uid=sa;pwd=123456; Integrated Security=false;MultipleActiveResultSets=true;;TrustServerCertificate=True";

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<Storage>(p => p.UseSqlServer(connString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
