using _02_01_XX_Arquitetura_Minima.Shared.Dados.Banco;
using _02_01_XX_Arquitetura_Minima.Shared.Modelos.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.MapGet("/", () =>
{
    var dal = new DAL<Artista>(new ScreenSoundContext());
    return dal.Listar();
});

app.Run();