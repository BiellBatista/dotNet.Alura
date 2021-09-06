using System;
using System.Collections.Generic;

namespace _07_04_XX_Func_Action_Predicate.Depois
{
    public class ManipuladoresEventos : IAulaItem
    {
        public void Executar()
        {
            try
            {
                Campainha2 campainha = new Campainha2();
                campainha.OnCampainhaTocou += CampainhaTocou1;
                campainha.OnCampainhaTocou += CampainhaTocou2;
                Console.WriteLine("A campainha será tocada.");
                campainha.Tocar("101");

                campainha.OnCampainhaTocou -= CampainhaTocou1;
                Console.WriteLine("A campainha será tocada.");
                campainha.Tocar("202");
            }
            catch (AggregateException e)
            {
                foreach (var exc in e.InnerExceptions)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        public void CampainhaTocou1(object sender, CampainhaEventArgs args)
        {
            Console.WriteLine("A campainha tocou no apartamento " + args.Apartamento + " .(1)");

            throw new Exception("Ocorreu um erro em CampainhaTocou1");
        }

        public void CampainhaTocou2(object sender, CampainhaEventArgs args)
        {
            Console.WriteLine("A campainha tocou no apartamento " + args.Apartamento + " .(2)");

            throw new Exception("Ocorreu um erro em CampainhaTocou2");
        }
    }

    public class Campainha2
    {
        public event EventHandler<CampainhaEventArgs> OnCampainhaTocou;

        public void Tocar(string apartamento)
        {
            List<Exception> erros = new List<Exception>();

            foreach (var manipulador in OnCampainhaTocou.GetInvocationList())
            {
                try
                {
                    manipulador.DynamicInvoke(this, new CampainhaEventArgs(apartamento));
                }
                catch (Exception e)
                {
                    erros.Add(e.InnerException);
                }
            }

            throw new AggregateException(erros);
        }
    }

    public class CampainhaEventArgs : EventArgs
    {
        public CampainhaEventArgs(string apartamento)
        {
            Apartamento = apartamento;
        }

        public string Apartamento { get; }
    }
}

/// <image url="$(ProjectDir)/img2.png"/>