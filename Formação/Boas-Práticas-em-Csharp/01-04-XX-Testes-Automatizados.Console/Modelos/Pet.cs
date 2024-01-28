namespace _01_04_XX_Testes_Automatizados.Console.Modelos;

public class Pet
{
    public Guid Id { get; set; }

    public string? Nome { get; set; }

    public TipoPet Tipo { get; set; }

    public Pet(Guid id, string? nome, TipoPet tipo)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
    }

    public override string ToString()
    {
        return $"{Id} - {Nome} - {Tipo}";
    }
}