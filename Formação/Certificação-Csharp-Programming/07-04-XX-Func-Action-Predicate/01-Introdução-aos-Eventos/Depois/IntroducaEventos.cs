using System;

namespace _07_04_XX_Func_Action_Predicate.Depois
{
    /// <image url="$(ProjectDir)/img1.png"/>
    public class IntroducaEventos : IAulaItem
    {
        public void Executar()
        {
            Campainha campainha = new Campainha();
            campainha.OnCampainhaTocou += CampainhaTocou1;
            campainha.OnCampainhaTocou += CampainhaTocou2;

            Console.WriteLine("A campainha será tocada.");

            campainha.Tocar(); //este método irá acionar todos os métodos associados a esta action (neste caso, irá executar o método CampainhaTocou1 e CampainhaTocou2)

            campainha.OnCampainhaTocou -= CampainhaTocou1;

            Console.WriteLine("A campainha será tocada.");

            campainha.Tocar();

            Console.ReadKey();
        }

        public void CampainhaTocou1()
        {
            Console.WriteLine("A campainha tocou.(1)");
        }

        public void CampainhaTocou2()
        {
            Console.WriteLine("A campainha tocou.(2)");
        }
    }

    public class Campainha
    {
        public Action OnCampainhaTocou { get; set; }

        public void Tocar()
        {
            OnCampainhaTocou?.Invoke();
        }
    }
}
