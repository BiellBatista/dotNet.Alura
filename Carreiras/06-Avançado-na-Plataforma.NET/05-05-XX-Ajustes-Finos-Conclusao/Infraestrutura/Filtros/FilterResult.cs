namespace _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura.Filtros
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
