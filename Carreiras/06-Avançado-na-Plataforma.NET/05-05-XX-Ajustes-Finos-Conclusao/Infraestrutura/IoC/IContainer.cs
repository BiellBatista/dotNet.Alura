using System;

namespace _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura.IoC
{
    public interface IContainer
    {
        void Registrar(Type tipoOrigem, Type tipoDestino);
        void Registrar<TOrigem, TDestino>() where TDestino : TOrigem;
        object Recuperar(Type tipoOrigem);
    }
}
