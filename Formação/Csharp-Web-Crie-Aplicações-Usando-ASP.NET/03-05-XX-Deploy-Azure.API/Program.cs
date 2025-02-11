using _03_04_XX_Trabalhando_Musica.API.Endpoints;
using _03_05_XX_Deploy_Azure.Shared.Dados.Banco;
using _03_05_XX_Deploy_Azure.Shared.Modelos.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration(config =>
{
    var settings = config.Build();
    config.AddAzureAppConfiguration("Endpoint=https://screensound-configuration.azconfig.io;Id=3HVQ;Secret=wF97RuK+avtFwg6iHERM8yeIDBJ2joABSih75njg7N4=");
});

builder.Services.AddDbContext<ScreenSoundContext>((options) =>
{
    options
            .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"])
            .UseLazyLoadingProxies();
});
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();
builder.Services.AddTransient<DAL<Genero>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseStaticFiles();

app.AddEndPointsArtistas();
app.AddEndPointsMusicas();
app.AddEndPointGeneros();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();