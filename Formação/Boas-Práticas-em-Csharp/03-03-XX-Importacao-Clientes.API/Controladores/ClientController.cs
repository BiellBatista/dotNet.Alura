using _03_03_XX_Importacao_Clientes.API.Dados.Context;
using _03_03_XX_Importacao_Clientes.API.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace _03_03_XX_Importacao_Clientes.API.Controladores
{
    [ApiController]
    [Route("/cliente/")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [Route("list")]
        public async Task<IResult> ListaDeClientes()
        {
            //
            //var _logger = new LoggerConfiguration()
            //     .WriteTo.Console()
            //     .WriteTo.File("AdoPetAPI-Actions-logs.txt", rollingInterval: RollingInterval.Day)
            //     .CreateLogger();

            var options = new DbContextOptionsBuilder<DataBaseContext>()
            .UseInMemoryDatabase("AdopetDB")
            .Options;
            try
            {
                DataBaseContext _context = new(options);
                var listaDeClientes = await _context.Clientes.ToListAsync();
                //_logger.Information("Listagem gerada com sucesso!");
                return Results.Ok(listaDeClientes);
            }
            catch (Exception ex)
            {
                //_logger.Error(ex, "Ocorreu uma Execeção:", ex.Message);
            }
            return Results.Ok();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IResult> CadatrarClientes([FromBody] Cliente cliente)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            //string _data = DateTime.Now.ToString("yyyy-MM-dd_HH");
            //string? path = configuration["LoggerBasePath"];
            //string? template = configuration["LoggerFileTemplate"];
            //string filename = $@"{path}\{_data}.adopet.log";

            //Log.Logger = new LoggerConfiguration()
            //              .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
            //              .Enrich.FromLogContext()
            //              .WriteTo.Console()
            //              .WriteTo.File(filename, outputTemplate: template)
            //              .CreateLogger();

            var options = new DbContextOptionsBuilder<DataBaseContext>()
            .UseInMemoryDatabase("AdopetDB")
            .Options;

            try
            {
                DataBaseContext _context = new(options);
                await _context.Clientes.AddAsync(cliente);
                _context.SaveChanges();
                Log.Information("Cliente cadastrado com sucesso!");

                return Results.Ok("Cliente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "Ocorreu uma Execeção:", ex.Message);
            }
            finally
            {
                //Log.CloseAndFlush();
            }

            return Results.Ok();
        }
    }
}