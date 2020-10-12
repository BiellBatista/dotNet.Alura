using System;

namespace _07_06_XX_Projecao_Dados.Antes
{
    public class ConsultaXML : IAulaItem
    {
        public void Executar()
        {
            string xml =
            "<Filmes>" +
                "<Filme>" +
                    "<Diretor>Quentin Tarantino</Diretor>" +
                    "<Titulo>Pulp Fiction</Titulo>" +
                    "<Minutos>154</Minutos>" +
                "</Filme>" +
                "<Filme>" +
                    "<Diretor>James Cameron</Diretor>" +
                    "<Titulo>Avatar</Titulo>" +
                    "<Minutos>162</Minutos>" +
                "</Filme>" +
            "</Filmes>";

            Console.ReadKey();
        }
    }
}
