using System;

namespace _05_05_XX_Ajustes_Finos_Conclusao.Infraestrutura.IoC
{
    public interface IContainer
    {
        void Registrar(Type tipoOrigem, Type tipoDestino);
        object Recuperar(Type tipoOrigem);
    }
}
