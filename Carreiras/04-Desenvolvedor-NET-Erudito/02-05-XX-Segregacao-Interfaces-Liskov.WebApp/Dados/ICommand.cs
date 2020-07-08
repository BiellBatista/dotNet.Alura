namespace _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Dados
{
    public interface ICommand<T>
    {
        void Incluir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
    }
}
