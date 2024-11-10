namespace _05_XX_Arquitetura_Plugins.Common
{
    public interface IRelatorio<T>
    {
        void Processar(List<T> boletos);
    }
}