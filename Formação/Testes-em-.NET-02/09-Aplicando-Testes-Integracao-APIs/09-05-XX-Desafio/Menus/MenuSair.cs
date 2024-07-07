using _09_05_XX_Desafio.Dados.Banco;
using _09_05_XX_Desafio.Dominio.Modelos;

namespace _09_05_XX_Desafio.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}