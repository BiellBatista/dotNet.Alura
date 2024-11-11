namespace _05_XX_Boas_Praticas.Exceptions;

public class PetEmProcessoDeAdocaoException : AdocaoException
{
    public PetEmProcessoDeAdocaoException(string? mensagem) : base(mensagem)
    {
    }
}