using _05_05_XX_Movendo_Metodo_Campo.Validation.Error;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_05_XX_Movendo_Metodo_Campo_Test.Validation.Test
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
