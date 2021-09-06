using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    internal class ParametrosOpcionais : IAulaItem
    {
        public void Executar()
        {
            ClienteEspecial clienteEspecial = new ClienteEspecial("Lucas Skywalker");
            clienteEspecial.FazerPedido(1, "Residencial", 1);

            ClienteEspecial clienteEspecial2 = new ClienteEspecial();
            clienteEspecial2.FazerPedido(2, "Comercial");

            clienteEspecial2.FazerPedido(3);

            //posso usar parametros nomeados
            clienteEspecial2.FazerPedido(4, quantidade: 5);
        }
    }

    internal class ClienteEspecial
    {
        private readonly string nome;

        public ClienteEspecial(string nome = "Anônimo")
        {
            this.nome = nome;
        }

        //devo deixar os parametros opcionais por ultimo
        public void FazerPedido(int produtoId, string endereco = "Residencial", int quantidade = 10)
        {
            Console.WriteLine("cliente {0}: produtoId: {1}, endereço: {2}, quantidade: {3}.", nome, produtoId, endereco, quantidade);
        }
    }
}