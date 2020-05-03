using System.Windows.Controls;
using System.Windows.Media;

namespace _05_XX_ByteBank.Agencias
{
    public delegate bool ValidacaoEventHandler(string texto);

    public class ValidacaoTextBox : TextBox
    {
        /**
         * Devo criar um campo privado do tipo ValidacaoEventHandler, para que eu possa manipular as ações de adicionar e remover evento
         */
        private ValidacaoEventHandler _validacao;

        public event ValidacaoEventHandler Validacao
        {
            add
            {
                _validacao += value;
                OnValidacao();
            }
            remove
            {
                _validacao -= value;
            }
        }

        public ValidacaoTextBox()
        {
            TextChanged += ValidacaoTextBox_TextChanged;
        }

        private void ValidacaoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnValidacao();
        }

        private void OnValidacao()
        {
            if (_validacao != null)
            {
                // com este método, eu consigo acessar todos os delegates assinados (atributos) ao objeto (evento)
                var listaValidacao = _validacao.GetInvocationList();
                //var ehValido = _validacao(Text);
                var ehValido = true;

                foreach (ValidacaoEventHandler validacao in listaValidacao)
                {
                    if(!validacao(Text))
                    {
                        ehValido = false;
                        break;
                    }
                }

                Background = ehValido
                ? new SolidColorBrush(Colors.White)
                : new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }
}

/**
 * O último valor (evento) que fica amarzenado no evento da tela é o do último delegate, porque os que foram executados anteriormente, são descatados
 * isso é o principio da máquina de estado
 */
