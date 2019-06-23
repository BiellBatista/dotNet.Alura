namespace Alura.Filmes.App.Negocio
{
    public enum ClassificacaoIndicativa
    {
        Livre,              //G
        MaioresQue10,       //PG
        MaioresQue13,       //PG-13
        MaioresQue14,       //R
        MaioresQue18        //NC-17
    }

    /**
     * O Entity Framework (EF) converter colunas enumerados para tipo inteiro no banco de dados, porque o enum pode ser convertido em inteiro (no C#)
     * 
     */
}
