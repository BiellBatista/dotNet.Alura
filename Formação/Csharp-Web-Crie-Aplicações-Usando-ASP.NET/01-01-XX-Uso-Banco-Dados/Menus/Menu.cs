using _01_01_XX_Uso_Banco_Dados.Modelos;

namespace _01_01_XX_Uso_Banco_Dados.Menus;

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

    public virtual void Executar(Dictionary<string, Artista> nusicasRegistradas)
    {
        Console.Clear();
    }
}