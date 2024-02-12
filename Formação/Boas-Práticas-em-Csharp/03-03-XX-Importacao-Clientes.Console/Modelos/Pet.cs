namespace _03_03_XX_Importacao_Clientes.Console.Modelos
{
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
}