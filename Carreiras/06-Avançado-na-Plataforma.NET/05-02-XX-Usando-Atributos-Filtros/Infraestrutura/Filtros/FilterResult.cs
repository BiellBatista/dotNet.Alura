namespace _05_02_XX_Usando_Atributos_Filtros.Infraestrutura.Filtros
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
