using _01_02_XX_Bibliotecas_ORM.Banco;

namespace _01_02_XX_Bibliotecas_ORM.Menus;

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

    public virtual void Executar(ArtistaDAL artistaDAL)
    {
        Console.Clear();
    }
}