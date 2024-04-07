using _04_03_XX_Estado_Autenticacao.Shared.Dados.Banco;
using _04_03_XX_Estado_Autenticacao.Shared.Modelos.Modelos;

namespace _04_03_XX_Estado_Autenticacao.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}