using _03_02_XX_CRUD_Artista.Shared.Dados.Banco;
using _03_02_XX_CRUD_Artista.Shared.Modelos.Modelos;

namespace _03_02_XX_CRUD_Artista.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}