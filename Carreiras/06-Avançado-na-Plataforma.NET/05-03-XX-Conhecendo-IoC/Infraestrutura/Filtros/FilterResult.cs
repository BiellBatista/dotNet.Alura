namespace _05_03_XX_Conhecendo_IoC.Infraestrutura.Filtros
{
    public class FilterResult
    {
        public bool PodeContinuar { get; private set; }

        public FilterResult(bool podeContinuar)
        {
            PodeContinuar = podeContinuar;
        }
    }
}
