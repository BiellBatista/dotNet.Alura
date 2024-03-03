using _03_03_XX_Upload_Imagens.Shared.Dados.Banco;
using _03_03_XX_Upload_Imagens.Shared.Modelos.Modelos;

namespace _03_03_XX_Upload_Imagens.Menus;

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