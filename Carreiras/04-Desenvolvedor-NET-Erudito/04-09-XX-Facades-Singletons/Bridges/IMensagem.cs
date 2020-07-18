namespace _04_09_XX_Facades_Singletons.Bridges
{
    public interface IMensagem
    {
        IEnviador Enviador { get; set; }

        void Envia();

        string Formata();
    }
}
