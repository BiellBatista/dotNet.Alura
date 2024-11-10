namespace _04_XX_Investigando_Assemblies.Common
{
    public interface IRelatorio<T>
    {
        void Processar(List<T> boletos);
    }
}