using _04_01_XX_Autenticacao_Autorizacao_API.Shared.Dados.Banco;
using _04_01_XX_Autenticacao_Autorizacao_API.Shared.Modelos.Modelos;

namespace _04_01_XX_Autenticacao_Autorizacao_API.Menus;

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