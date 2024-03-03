using _03_03_XX_Upload_Imagens.Shared.Dados.Banco;
using _03_03_XX_Upload_Imagens.Shared.Modelos.Modelos;

namespace _03_03_XX_Upload_Imagens.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}