namespace _03_XX_Filmes.API.Data.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public ReadEnderecoDto Endereco { get; set; }
}