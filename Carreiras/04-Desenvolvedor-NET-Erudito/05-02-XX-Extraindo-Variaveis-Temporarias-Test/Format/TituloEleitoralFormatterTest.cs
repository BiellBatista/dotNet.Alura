﻿using _05_02_XX_Extraindo_Variaveis_Temporarias.Format;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias_Test.Test.Format
{
    [TestClass]
    public class TituloEleitoralFormatterTest : IBaseFormatterTest
    {
        private IFormatter formatter;

        [TestInitialize]
        public void TestInitialize()
        {
            formatter = new TituloEleitoralFormatter();
        }

        [TestMethod]
        public void TestFormat()
        {
            String unfotmatedValue = "133968200302";
            String formatedValue = formatter.Format(unfotmatedValue);
            Assert.AreEqual(formatedValue, "1339682003/02");
        }

        [TestMethod]
        public void TestUnformat()
        {
            String formatedValue = "1339682003/02";
            String unformatedValue = formatter.Unformat(formatedValue);
            Assert.AreEqual(unformatedValue, "133968200302");
        }

        [TestMethod]
        public void ShouldDetectIfAValueIsFormattedOrNot()
        {
            Assert.IsTrue(formatter.IsFormatted("1339682003/02"));
            Assert.IsFalse(formatter.IsFormatted("133968200302"));
            Assert.IsFalse(formatter.IsFormatted("1339682003/0x"));
        }

        [TestMethod]
        public void ShouldDetectIfAValueCanBeFormattedOrNot()
        {
            Assert.IsFalse(formatter.CanBeFormatted("1339682003/02"));
            Assert.IsTrue(formatter.CanBeFormatted("133968200302"));
            Assert.IsFalse(formatter.CanBeFormatted("1339682003/0x"));
        }
    }
}
