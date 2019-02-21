namespace Alura.Loja.Testes.ConsoleApp
{
    public class Endereco
    {
        public int Numero { get; internal set; }
        public string Logradouro { get; internal set; }
        public string Complemento { get; internal set; }
        public string Bairro { get; internal set; }
        public string Cidade { get; internal set; }
        public Cliente Cliente { get; set; }
    }
}

/*
 * Muitas vezes, em um relacionamento 1:1, a classe depedente, neste caso a de endereço, não possui um ID própria, porque ela "copia" o id da classe principal, neste caso cliente. Ou seja, o mesmo ID do Endereço será o de Cliente
 */