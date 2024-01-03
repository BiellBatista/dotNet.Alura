using _04_XX_Conhecendo_Records.UsuarioLib;

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

//Stopwatch sw = new();

//sw.Start();

//for (int i = 0; i < 1000000000; i++)
//{
//    var coordenada = new Coordenada(123.456, -123.456);

//    _ = coordenada.Latitude;
//    _ = coordenada.Longitude;
//}

//sw.Stop();

//Console.WriteLine(sw.Elapsed.TotalMilliseconds);

//Console.WriteLine(sw.Elapsed.TotalMilliseconds);

//FormularioDto dto = new FormularioDto("Daniel", "11111111111", "Programador") { Idade = 99 };
//dto.Idade = 100;
//dto.Idade = 200;

//Console.WriteLine($" Valor do nome: {dto.Nome}");

//Console.WriteLine($" Valor do nome: {dto.Nome}");

//FormularioDto dto2 = new FormularioDto();
//dto2.Nome = "Daniel";
//dto2.Idade = 100;
//dto2.Cargo = "Programador";
//dto2.Cpf = "11111111112";

//Console.WriteLine(dto == dto2);

var dto1 = new UsuarioDto();
dto1.Nome = "Daniel";
dto1.Email = "daniel@email.com";
dto1.Telefones = new List<string>();

var dto2 = new UsuarioDto();
dto2.Nome = "Daniel2";
dto2.Email = "daniel@email.com";
dto2.Telefones = new List<string>();

Console.WriteLine(dto1 == dto2);