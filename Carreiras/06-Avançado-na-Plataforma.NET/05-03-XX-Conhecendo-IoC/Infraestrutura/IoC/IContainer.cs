using System;

namespace _05_03_XX_Conhecendo_IoC.Infraestrutura.IoC
{
    public interface IContainer
    {
        void Registrar(Type tipoOrigem, Type tipoDestino);
        object Recuperar(Type tipoOrigem);
    }
}
