using _03_XX_Conhecendo_Structs.UsuarioLib;
using System.Diagnostics;

//Usuario usuario =
//    new Usuario(
//        "Daniel",
//        "daniel@email.com",
//        new List<string>() { "12345678" });

//Usuario usuario2 =
//    new Usuario(
//        "Luis",
//        "luis@email.com",
//        new List<string>() { "87654321" });

////12345678
//usuario.ExibeTelefones();

////efetuar a padronização
//usuario.PadronizaTelefones();

////912345678
//usuario.ExibeTelefones();

Stopwatch sw = new();

sw.Start();

for (int i = 0; i < 1000000000; i++)
{
    var coordenada = new Coordenada(123.456, -123.456);

    _ = coordenada.Latitude;
    _ = coordenada.Longitude;
}

sw.Stop();

Console.WriteLine(sw.Elapsed.TotalMilliseconds);