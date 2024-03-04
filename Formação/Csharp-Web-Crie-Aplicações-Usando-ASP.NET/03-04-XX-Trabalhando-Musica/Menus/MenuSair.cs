using _03_04_XX_Trabalhando_Musica.Shared.Dados.Banco;
using _03_04_XX_Trabalhando_Musica.Shared.Modelos.Modelos;

namespace _03_04_XX_Trabalhando_Musica.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}