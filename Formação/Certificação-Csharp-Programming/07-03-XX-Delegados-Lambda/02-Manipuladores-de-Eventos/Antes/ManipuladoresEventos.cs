using System;

namespace _07_03_XX_Delegados_Lambda.Antes
{
    public class ManipuladoresEventos : IAulaItem
    {
        public void Executar()
        {
            Campainha campainha = new Campainha();
            campainha.OnCampainhaTocou += CampainhaTocou1;
            campainha.OnCampainhaTocou += CampainhaTocou2;

            Console.WriteLine("A campainha será tocada.");

            campainha.Tocar();

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
