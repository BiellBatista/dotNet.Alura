using _05_02_XX_Extraindo_Variaveis_Temporarias.Validation.Error;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias_Test.Validation.Test
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
