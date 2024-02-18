using _01_01_XX_Uso_Banco_Dados.Modelos;

namespace _01_01_XX_Uso_Banco_Dados.Menus;

internal class MenuSair : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}