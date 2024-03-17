using _04_01_XX_Autenticacao_Autorizacao_API.Shared.Dados.Banco;
using _04_01_XX_Autenticacao_Autorizacao_API.Shared.Modelos.Modelos;

namespace _04_01_XX_Autenticacao_Autorizacao_API.Menus;

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