using System;

namespace _05_04_XX_Implementando_IoC.Infraestrutura.IoC
{
    public interface IContainer
    {
        void Registrar(Type tipoOrigem, Type tipoDestino);
        object Recuperar(Type tipoOrigem);
    }
}
