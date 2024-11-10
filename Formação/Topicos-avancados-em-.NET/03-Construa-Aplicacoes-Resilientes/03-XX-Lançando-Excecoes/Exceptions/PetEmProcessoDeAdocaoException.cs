namespace _03_XX_Lançando_Excecoes.Exceptions;

public class PetEmProcessoDeAdocaoException : Exception
{
    public PetEmProcessoDeAdocaoException(string? mensagem) : base(mensagem)
    {
    }
}