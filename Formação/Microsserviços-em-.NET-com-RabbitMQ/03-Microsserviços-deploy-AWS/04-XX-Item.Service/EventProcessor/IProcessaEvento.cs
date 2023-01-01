namespace _04_XX_Item.Service.EventProcessor;

public interface IProcessaEvento
{
    void Processa(string mensagem);
}