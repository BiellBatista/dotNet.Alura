namespace _04_XX_Conhecendo_Records.UsuarioLib;

public record FormularioDto(string Nome, string Cpf, string Cargo)
{
    public int Idade { get; set; }
}