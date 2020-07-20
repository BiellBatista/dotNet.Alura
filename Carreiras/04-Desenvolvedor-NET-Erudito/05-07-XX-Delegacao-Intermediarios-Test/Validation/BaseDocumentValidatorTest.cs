using _05_07_XX_Delegacao_Intermediarios.Validation.Error;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_07_XX_Delegacao_Intermediarios_Test.Validation.Test
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
