namespace _05_XX_Boas_Praticas.Exceptions;

public class TutorComLimiteAtingidoException : AdocaoException
{
    public TutorComLimiteAtingidoException(string? mensagem) :
        base(mensagem)
    { }
}