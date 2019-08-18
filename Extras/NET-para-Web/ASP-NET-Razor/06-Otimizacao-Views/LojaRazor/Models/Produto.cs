namespace LojaRazor.Models
{
    public class Produto
    {

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public Produto(string nome, string descricao, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }
    }
}