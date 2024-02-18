namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos
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