using _09_05_XX_Desafio.API.Endpoints;
using _09_05_XX_Desafio.Dados.Banco;
using _09_05_XX_Desafio.Dominio.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndPointsArtistas();
app.AddEndPointsMusicas();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

public partial class Program;