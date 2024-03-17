using _04_01_XX_Autenticacao_Autorizacao_API.Shared.Dados.Banco;
using _04_01_XX_Autenticacao_Autorizacao_API.Shared.Modelos.Modelos;

namespace _04_01_XX_Autenticacao_Autorizacao_API.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}