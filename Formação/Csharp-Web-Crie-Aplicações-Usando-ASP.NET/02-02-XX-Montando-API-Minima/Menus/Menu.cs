using _02_02_XX_Montando_API_Minima.Shared.Dados.Banco;
using _02_02_XX_Montando_API_Minima.Shared.Modelos.Modelos;

namespace _02_02_XX_Montando_API_Minima.Menus;

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