using _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Http;
using _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Http.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros_Test.Test.Http
{
    //[TestClass]
    public class CEPTest
    {
        [TestMethod]
        public void ZipCodeShouldBeNull()
        {
            CEP cep = new CEP();
            Assert.IsTrue(cep.IsNull);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidZipCodeFormat))]
        public void EmptyZipCodeShouldBeInvalid()
        {
            CEP cep = "";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidZipCodeFormat))]
        public void ShorterZipCodeShouldBeInvalid()
        {
            CEP cep = "123456";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidZipCodeFormat))]
        public void LongerZipCodeShouldBeInvalid()
        {
            CEP cep = "123456789";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidZipCodeFormat))]
        public void AlphaNumericShouldBeInvalid()
        {
            CEP cep = "12a4b6c8";
        }

        [TestMethod]
        public void ShouldBeComparable()
        {
            CEP cepA = "04101-300";
            var cepB = cepA;

            Assert.AreEqual(cepA.CompareTo(cepB), 0);
        }

        [TestMethod]
        public void ShouldBeEqual()
        {
            CEP cepA = "04101-300";
            var cepB = cepA;

            Assert.AreEqual(cepA, cepB);

            CEP cepC = "04101-300";
            Assert.AreEqual(cepA, cepC);
        }
    }
}
