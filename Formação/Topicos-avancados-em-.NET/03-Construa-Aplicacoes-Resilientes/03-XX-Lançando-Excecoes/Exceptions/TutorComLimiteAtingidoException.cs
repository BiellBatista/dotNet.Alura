namespace _03_XX_Lançando_Excecoes.Exceptions;

public class TutorComLimiteAtingidoException : Exception
{
    public TutorComLimiteAtingidoException(string? mensagem) :
        base(mensagem)
    { }
}