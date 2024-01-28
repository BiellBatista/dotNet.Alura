using _02_XX_Boas_Praticas_Testes.Console.Modelos;

namespace _02_XX_Boas_Praticas_Testes.Console.Util
{
    public class LeitorDeArquivo
    {
        private string caminhoDoArquivoASerLido;

        public LeitorDeArquivo(string caminhoDoArquivoASerLido)
        {
            this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
        }

        public virtual List<Pet> RealizaLeitura()
        {
            if (string.IsNullOrEmpty(caminhoDoArquivoASerLido))
            {
                return null;
            }
            List<Pet> listaDePet = new List<Pet>();
            using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
            {
                System.Console.WriteLine("----- Dados a serem importados -----");
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[]? propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
                    );
                    listaDePet.Add(pet);
                }
            }

            return listaDePet;
        }
    }
}