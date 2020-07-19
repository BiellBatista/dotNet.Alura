using _05_04_XX_Substituindo_Metodo.Validation.Error;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_04_XX_Substituindo_Metodo_Test.Validation.Test
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
