using _02_01_XX_Arquitetura_Minima_Shared_Dados.Banco;
using _02_01_XX_Arquitetura_Minima_Shared_Modelos.Modelos;

namespace _02_01_XX_Arquitetura_Minima.Menus;

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