using DataAccessLayer.Implementation.EntityFramework;
using DataAccessLayer.Interface;
using MedApp.Services.Implementation;
using MedApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<MedAppDbContext>(x => x.UseLazyLoadingProxies().UseSqlServer(connection));
builder.Services.AddDbContext<MedAppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericEfRepository<>));
builder.Services.AddScoped<IAnalysisService, AnalysisService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
