using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootstrapMvc.Base.Core;

namespace BootTest
{
    [TestClass]
    public class BaseTest
    {
        [TestMethod]
        public void TestElementRender()
        {
            Element<Div> t = new Element<Div>("Test");
            Assert.AreEqual(t.Render(), "<Test></Test>");
        }
    }
}
