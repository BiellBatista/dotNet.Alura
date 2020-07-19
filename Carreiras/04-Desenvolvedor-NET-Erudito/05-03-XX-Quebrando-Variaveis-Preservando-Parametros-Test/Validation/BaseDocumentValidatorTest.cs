using _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Validation.Error;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros_Test.Validation.Test
{
    public class BaseDocumentValidatorTest
    {
        protected void AssertMessage(InvalidStateException invalidStateException
            , String expected)
        {
            Assert.IsTrue(invalidStateException
                .GetErrors().Contains(expected));
        }
    }
}
