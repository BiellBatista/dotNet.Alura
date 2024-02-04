using _03_01_XX_Importando_Json.Console.Modelos;

namespace _03_01_XX_Importando_Json.Console.Servicos.Abstracoes;

public interface IApiService
{
    Task CreateAsync(Pet pet);

    Task<IEnumerable<Pet>?> ListAsync();
}