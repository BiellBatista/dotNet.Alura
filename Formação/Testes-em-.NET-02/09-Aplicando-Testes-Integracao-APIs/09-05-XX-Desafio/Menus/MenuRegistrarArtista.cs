using _09_05_XX_Desafio.Dados.Banco;
using _09_05_XX_Desafio.Dominio.Modelos;

namespace _09_05_XX_Desafio.Menus;

internal class MenuRegistrarArtista : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Registro dos Artistas");
        Console.Write("Digite o nome do artista que deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        Console.Write("Digite a bio do artista que deseja registrar: ");
        string bioDoArtista = Console.ReadLine()!;
        Artista artista = new Artista(nomeDoArtista, bioDoArtista);
        artistaDAL.Adicionar(artista);
        Console.WriteLine($"O artista {nomeDoArtista} foi registrado com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}