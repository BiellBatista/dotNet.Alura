using _02_04_XX_Relacionando_Genero.Shared.Dados.Banco;
using _02_04_XX_Relacionando_Genero.Shared.Modelos.Modelos;

namespace _02_04_XX_Relacionando_Genero.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}