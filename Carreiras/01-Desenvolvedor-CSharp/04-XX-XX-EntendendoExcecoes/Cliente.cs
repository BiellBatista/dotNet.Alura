using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_XX_XX_EntendendoExcecoes
{
    public class Cliente
    {
        public string Nome { get; set; }
        private string _cpf; // o _ serve para mostrar que o atributo é privado
        public string CPF
        {
            get
            {
                return _cpf;
            }
            set
            {
                // Escrevo minha lógica de validação de CPF
                _cpf = value;
            }
        }
        public string Profissao { get; set; }

        public override bool Equals(object obj)
        {
            Cliente outroCliente = (Cliente)obj; //converte (expkicitamente) o objeto para Cliente
            outroCliente = obj as Cliente; //converte o objeto para Cliente, caso seja Cliente. Caso contrário, será null

            if (outroCliente == null)
                return false;

            return Nome == outroCliente.Nome && CPF == outroCliente.CPF && Profissao == outroCliente.Profissao;

             //Ele irá verificar se os objetos são iguais (pelo atributo) e sobreescreve o método Equals da classe Object
        }
    }
}
