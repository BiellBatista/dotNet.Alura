namespace _04_XX_Hierarquia_Excecoes.Exceptions;

public class PetEmProcessoDeAdocaoException : AdocaoException
{
    public PetEmProcessoDeAdocaoException(string? mensagem) : base(mensagem)
    {
    }
}