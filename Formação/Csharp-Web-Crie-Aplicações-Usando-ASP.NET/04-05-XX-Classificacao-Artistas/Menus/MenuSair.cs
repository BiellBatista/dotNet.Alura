using _04_05_XX_Classificacao_Artistas.Shared.Dados.Banco;
using _04_05_XX_Classificacao_Artistas.Shared.Modelos.Modelos;

namespace _04_05_XX_Classificacao_Artistas.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}