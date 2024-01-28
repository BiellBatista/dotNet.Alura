using _02_04_XX_Isolando_Exibicao.API.Dados.Context;
using _02_04_XX_Isolando_Exibicao.API.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);// Criando uma aplica��o Web.

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
//ConfigureLogRequestSerilogExtension.AddSerialogAPI(builder);

//DI
builder.Services.AddControllers().AddNewtonsoftJson(options =>
   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddScoped<IEventoService, EventoService>()
                .AddDbContext<DataBaseContext>(opt =>
                {
                    opt.UseInMemoryDatabase("AdopetDB");
                    opt.UseLoggerFactory(LoggerFactory.Create(builder =>
                    {
                        builder.AddSerilog();
                    }));
                });

//Habilitando o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
//{
//    builder.Services.AddHttpLogging(opt =>
//    {
//        opt.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders|
//                            HttpLoggingFields.ResponsePropertiesAndHeaders|
//                            HttpLoggingFields.ResponseBody|
//                            HttpLoggingFields.ResponseBody;
//    });

//}

//Adicionando servi�os.
var serviceProvider = builder.Services.BuildServiceProvider();
var eventoService = serviceProvider.GetService<IEventoService>();

var app = builder.Build();
eventoService.GenerateFakeDate();

// Ativando o Swagger
app.UseSwagger();

// Ativando a interface Swagger
app.UseSwaggerUI(
    c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI V1");
        c.RoutePrefix = string.Empty;
    }
);

app.MapControllers();
// Roda a aplica��o
app.Run();