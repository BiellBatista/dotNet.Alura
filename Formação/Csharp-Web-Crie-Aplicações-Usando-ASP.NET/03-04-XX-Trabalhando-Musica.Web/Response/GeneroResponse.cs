namespace _03_04_XX_Trabalhando_Musica.Web.Response;
public record GeneroResponse(int Id, string Nome, string Descricao)
{
    public override string ToString()
    {
        return $"{Nome}";
    }
}