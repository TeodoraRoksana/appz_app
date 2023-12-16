using AutoMapper;
using DataAccessLayer.Implementation.EntityFramework;
using DataAccessLayer.Interface;
using MedApp.Services.Implementation;
using MedApp.Services.Interfaces;
using MedApp.Services.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<MedAppDbContext>(x => x.UseLazyLoadingProxies().UseSqlServer(connection));
builder.Services.AddDbContext<MedAppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServerConnection")));

/*
 * DEPENDENCY INJECTION
 */
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericEfRepository<>));
builder.Services.AddScoped<IAnalysisService, AnalysisService>();
builder.Services.AddScoped<IUserService, UserService>();

/*
 * MAPPER INJECTION
 */
builder.Services.AddScoped(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperProfile());
    cfg.AllowNullCollections = true;
}).CreateMapper());

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
