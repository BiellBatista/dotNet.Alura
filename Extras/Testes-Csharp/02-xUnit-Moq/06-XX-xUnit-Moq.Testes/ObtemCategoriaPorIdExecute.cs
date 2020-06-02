using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using _06_XX_xUnit_Moq.Core.Commands;
using _06_XX_xUnit_Moq.Services.Handlers;
using _06_XX_xUnit_Moq.Infrastructure;

namespace _06_XX_xUnit_Moq.Testes
{
    public class ObtemCategoriaPorIdExecute
    {
        [Fact]
        public void QuandoIdForExistenteDeveChamarObtemCategoriaPorIdUmaUnicaVez()
        {
            //arrange
            var idCategoria = 20;
            var comando = new ObtemCategoriaPorId(idCategoria);

            var mock = new Mock<IRepositorioTarefas>();
            var repo = mock.Object;

            var handler = new ObtemCategoriaPorIdHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            mock.Verify(r => r.ObtemCategoriaPorId(idCategoria), Times.Once());
        }
    }
}
