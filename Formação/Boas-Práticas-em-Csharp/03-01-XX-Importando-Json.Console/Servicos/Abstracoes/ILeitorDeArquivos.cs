using _03_01_XX_Importando_Json.Console.Modelos;

namespace _03_01_XX_Importando_Json.Console.Servicos.Abstracoes;

public interface ILeitorDeArquivos
{
    IEnumerable<Pet> RealizaLeitura();
}