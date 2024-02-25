using _01_03_XX_Generics.Banco;
using _01_03_XX_Generics.Modelos;

namespace _01_03_XX_Generics.Menus;

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

    public virtual void Executar(DAL<Artista> artistaDAL)
    {
        Console.Clear();
    }
}