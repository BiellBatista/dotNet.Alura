namespace _02_XX_Conhecendo_Identity.Data.Dtos.Gerente
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        //deixo o tipo de Cinemas como object para que  AutoMapper possa realizar as alterações
        public object Cinemas { get; set; }
    }
}