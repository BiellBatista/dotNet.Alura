namespace Alura.Loja.Testes.ConsoleApp
{
    public class PromocaoProduto
    {
        /*
         * Tabela de join (N:M) não possui chave primária, porque ela só serve para realizar um join e as duas foreign key já são chave
         */
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int PromocaoId { get; set; }
        public Promocao Promocao { get; set; }
    }
}
