namespace _01_XX_Melhorando_consultas.Modelos;

public class Cliente
{
    public Cliente()
    {
    }

    public Cliente(Guid id, string nome, string cpf, string email, string telefone, ICollection<Projeto> projetos)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        Projetos = projetos;
    }

    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public ICollection<Projeto> Projetos { get; set; }
}