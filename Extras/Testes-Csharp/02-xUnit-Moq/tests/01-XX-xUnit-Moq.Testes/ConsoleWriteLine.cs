using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using _01_XX_xUnit_Moq.Core.Models;

namespace _01_XX_xUnit_Moq.Testes
{
    public class ConsoleWriteLine
    {
        [Fact]
        public void AoExecutarDeveChamarToStringNoObjetoMockado()
        {
            //arrange
            var mock = new Mock<Tarefa>();
            var tarefa = mock.Object;

            //act
            Console.WriteLine(tarefa);

            //assert
            mock.Verify(t => t.ToString(), Times.Once());
        }
    }
}
