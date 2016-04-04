using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ensalamento.BO;

namespace Ensalamento.Test
{
    [TestClass]
    public class SalaTest
    {
        [TestMethod]
        public void DeveAdicionarCapacidadeMaiorQueZero()
        {
            var sala = new SalaBo();
            var result = sala.IsValidaCapacidade(-2);
            Assert.AreEqual(true, result);
        }
    }
}
