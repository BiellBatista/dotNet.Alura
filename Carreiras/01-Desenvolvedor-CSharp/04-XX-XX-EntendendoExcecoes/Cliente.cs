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
    }
}
