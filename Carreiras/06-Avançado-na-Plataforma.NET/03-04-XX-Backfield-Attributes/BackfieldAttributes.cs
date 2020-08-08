using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _03_04_XX_Backfield_Attributes
{
    [Serializable]
    public class FormularioCadastro
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        //a palavra field avisa para o compilador aplicar o NonSerialized no campo da prop Senha
        [field: NonSerialized]
        public string Senha { get; set; }
    }

    class BackfieldAttributes
    {
        public static void Testa()
        {
            var novoCadastro = new FormularioCadastro()
            {
                Nome = "Gabriel",
                Email = "gabriel@alura.com.br",
                Senha = "123"
            };

            using (var arquivo = File.Create("cadastro.bin"))
            {
                var formatador = new BinaryFormatter();
                formatador.Serialize(arquivo, novoCadastro);
            }
        }
    }
}
