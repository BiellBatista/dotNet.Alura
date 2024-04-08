using _04_05_XX_Classificacao_Artistas.Shared.Dados.Banco;
using _04_05_XX_Classificacao_Artistas.Shared.Modelos.Modelos;

namespace _04_05_XX_Classificacao_Artistas.Menus;

internal class MenuMostrarArtistas : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibindo todos os artistas registradas na nossa aplicação");

        foreach (var artista in artistaDAL.Listar())
        {
            Console.WriteLine($"Artista: {artista}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}