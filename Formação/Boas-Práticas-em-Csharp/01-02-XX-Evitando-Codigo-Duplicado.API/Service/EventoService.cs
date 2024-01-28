using _01_02_XX_Evitando_Codigo_Duplicado.API.Dados.Context;
using _01_02_XX_Evitando_Codigo_Duplicado.API.Dominio;

namespace _01_02_XX_Evitando_Codigo_Duplicado.API.Service;

internal class EventoService : IEventoService
{
    private DataBaseContext _context;

    public EventoService(DataBaseContext context)
    {
        _context = context;
    }

    public void GenerateFakeDate()
    {
        var proprietario = new Cliente()
        {
            CPF = "111.111.111-22",
            Nome = "André",
            Email = "andre@email.com"
        };

        _context.Add(proprietario);

        var pet = new Pet()
        {
            Nome = "Sábio",
            Tipo = TipoPet.Gato,
            Proprietario = proprietario,
        };

        _context.Add(pet);
        _context.SaveChanges();
    }
}