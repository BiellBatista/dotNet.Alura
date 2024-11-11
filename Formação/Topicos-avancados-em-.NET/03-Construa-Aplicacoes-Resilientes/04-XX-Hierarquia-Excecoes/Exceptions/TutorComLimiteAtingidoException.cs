namespace _04_XX_Hierarquia_Excecoes.Exceptions;

public class TutorComLimiteAtingidoException : AdocaoException
{
    public TutorComLimiteAtingidoException(string? mensagem) :
        base(mensagem)
    { }
}