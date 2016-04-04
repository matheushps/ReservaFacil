using Ensalamento.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensalamento.Test
{
    [TestClass]
    public class AuditorioTest
    {
        [TestMethod]
        public void DeveAdicionarCapacidadeMaiorQueZero()
        {
            var auditorio = new AuditorioBo();
            var result = auditorio.IsValidaCapacidade(5);
            Assert.AreEqual(true, result);
        }

         [TestMethod]
        public void DeveDeleterAuditorioExistente ()
        {
            var id = new AuditorioBo();
            var result = id.IsValidaId(2);
            Assert.AreEqual(true, result);
        }

    }
}
