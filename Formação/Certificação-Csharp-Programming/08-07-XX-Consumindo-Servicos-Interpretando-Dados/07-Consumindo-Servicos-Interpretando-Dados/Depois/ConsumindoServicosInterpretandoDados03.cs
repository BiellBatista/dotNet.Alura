using System;

namespace _08_07_XX_Consumindo_Servicos_Interpretando_Dados.Depois
{
    public class ConsumindoServicosInterpretandoDados03 : IAulaItem //Web Service
    {
        public void Executar()
        {
            //TAREFA:
            //1. ADICIONAR UMA REFERÊNCIA A UM SERVIÇO
            //      WCF (WINDOWS COMMUNICATION FOUNDATION)
            //2. CONSUMIR O SERVIÇO E EXIBIR OS CURSOS DE NÚMERO 1 A 15

            //var cliente = new CursoServiceClient();

            //for (int i = 1; i <= 15; i++)
            //{
            //    var nomeCurso = cliente.GetValorAsync(i).Wait();
            //    Console.WriteLine(nomeCurso);
            //}

            Console.ReadKey();
        }
    }
}