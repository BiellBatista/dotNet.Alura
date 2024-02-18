using _01_01_XX_Uso_Banco_Dados.Modelos;

namespace _01_01_XX_Uso_Banco_Dados.Menus;

internal class MenuMostrarArtistas : Menu
{
    public override void Executar(Dictionary<string, Artista> musicasRegistradas)
    {
        base.Executar(musicasRegistradas);
        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        foreach (string artista in musicasRegistradas.Keys)
        {
            Console.WriteLine($"Artista: {artista}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}