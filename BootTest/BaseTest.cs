using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootstrapMvc.Base.Core;
using BootstrapMvc.Base.Utils;
using System.Collections.Generic;

namespace BootTest
{
    class TestElement : Element
    {
        private string p;

        public TestElement(string p)
            : base(p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public void ChangeElement()
        {
            base.ChangeWrapperType("newTest");
        }
    }

    [TestClass]
    public class BaseTest
    {
        [TestMethod]
        public void Test_ElementRender()
        {
            Element t = new Element("Test");
            Assert.AreEqual(t.Render(), "<Test></Test>");
        }

        [TestMethod]
        public void Test_ElementRender_With_Changed_Wrapper()
        {
            TestElement t = new TestElement("Test");
            t.ChangeElement();
            Assert.AreEqual(t.Render(), "<newTest></newTest>");
        }

        [TestMethod]
        public void Test_GenericElement_With_Id_Render()
        {
            GenericElement<Element> t = new GenericElement<Element>("Test");

            t.Id("myId");
            Assert.AreEqual("<Test id=\"myId\"></Test>", t.Render(), "Id is not the same");
        }

        [TestMethod]
        public void Test_GenericElement_Render_With_Css()
        {
            GenericElement<Element> t = new GenericElement<Element>("Test");

            t.AddCss("myClass");
            Assert.AreEqual("<Test class=\"myClass\"></Test>", t.Render(),
                "Class is not the same");
        }

        [TestMethod]
        public void Test_GenericElement_Render_With_Id_And_Css()
        {
            GenericElement<Element> t = new GenericElement<Element>("Test");

            t.Id("myId");
            t.AddCss("myClass");
            Assert.AreEqual("<Test class=\"myClass\" id=\"myId\"></Test>", t.Render(),
                "Class is not the same");
        }

        [TestMethod]
        public void Test_GenericElement_Render_With_HtmlAttributes()
        {
            GenericElement<Element> t = new GenericElement<Element>("Test");

            t.Attributes(new { data_test = true, data_test2 = "true" });
            Assert.AreEqual("<Test data-test=\"True\" data-test2=\"true\"></Test>", t.Render(), 
                "Attributes is not the same");
        }

        [TestMethod]
        public void Test_GenericElement_And_Element_Clear()
        {
            GenericElement<Element> t = new GenericElement<Element>("Test");

            t.Id("myId");
            t.Attributes(new { data_test = true, data_test2 = "true" });
            
            // Render again to register options above
            t.Render();
            t.Clear();

            Assert.AreEqual("<Test></Test>", t.Render(), "Options not removed");
        }

        [TestMethod]
        public void Test_DivElement_Render()
        {
            Div t = new Div();

            t.Id("myDiv");
            t.IsRowFluid(true);
            t.Size(GridUtils.FormatGrid(extraSmallSize: 12, largeSize: 12));
            t.AddCss("testClass");

            string render = t.Render();

            Assert.IsTrue(render.Contains("id=\"myDiv\""), "Dv not contains id declaration");
            Assert.IsTrue(render.Contains("class") && 
                render.Contains("row"), "Div not contains class=\"row ...\" declaration");
            Assert.IsTrue(render.Contains("class") && render.Contains("col-xs-12 col-lg-12"),
                "Div doesn't have grid responsive values");
            Assert.IsTrue(render.Contains("class") &&
                render.Contains("testClass"), "Div not contains class=\"testClass ...\" declaration");
            Assert.AreEqual("<div class=\"testClass row col-xs-12 col-lg-12\" id=\"myDiv\"></div>", render, 
                "Div don't have same values from test");
        }

        [TestMethod]
        public void Test_DivElement_Render_With_SubElement()
        {
            Div t = new Div();

            t.AddElement(new Element("test"));

            Assert.AreEqual("<div><test></test></div>", t.Render(), "There's no test tag inside div");
        }

        [TestMethod]
        public void Test_GridSystem_FormatGrid_Method()
        {
            Assert.AreEqual("col-md-8 col-lg-4",
                GridUtils.FormatGrid(largeSize: 4, mediumSize: 8).ToString(),
                    "Generated values ");
        }

    }
}
