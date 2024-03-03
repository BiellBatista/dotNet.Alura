using _03_01_XX_Web_App_Blazor.Shared.Dados.Banco;
using _03_01_XX_Web_App_Blazor.Shared.Modelos.Modelos;

namespace _03_01_XX_Web_App_Blazor.Menus;

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