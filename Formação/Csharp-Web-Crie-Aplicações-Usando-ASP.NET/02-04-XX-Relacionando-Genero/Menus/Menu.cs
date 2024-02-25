using _02_04_XX_Relacionando_Genero.Shared.Dados.Banco;
using _02_04_XX_Relacionando_Genero.Shared.Modelos.Modelos;

namespace _02_04_XX_Relacionando_Genero.Menus;

internal class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    public virtual void Executar(DAL<Artista> artistaDal)
    {
        Console.Clear();
    }
}