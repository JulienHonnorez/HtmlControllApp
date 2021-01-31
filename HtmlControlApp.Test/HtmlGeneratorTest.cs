using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HtmlControlApp.Test
{
    [TestClass]
    public class HtmlGeneratorTest
    {
        /// <summary>
        /// Allow to test the single tag generation with innerHtml content.
        /// </summary>
        [TestMethod]
        public void GenerateTag_WithInnerText()
        {
            // Arrange
            HtmlGenerator htmlGenerator = new HtmlGenerator();
            string tag = "div";
            string id = "divId";
            string name = "divName";
            string innerHtml = "Content";
            string expected = "<div id=\"" + id + "\" name=\"" + name + "\">" + innerHtml + "</div>";

            // Act
            string actual = htmlGenerator.GenerateTag(tag, id, name, innerHtml);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Allow to test the single tag generation without innerHtml content.
        /// </summary>
        [TestMethod]
        public void GenerateTag_WithoutInnerText()
        {
            // Arrange
            HtmlGenerator htmlGenerator = new HtmlGenerator();
            string tag = "div";
            string id = "divId";
            string name = "divName";
            string expected = "<div id=\"" + id + "\" name=\"" + name + "\"></div>";

            // Act
            string actual = htmlGenerator.GenerateTag(tag, id, name);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Allow to test the tree generation method using HtmlGenericControl class
        /// </summary>
        [TestMethod]
        public void GenerateTreeExample_Test()
        {
            // Arrange
            HtmlGenerator htmlGenerator = new HtmlGenerator();
            string expected = "<body id=\"body1\" runat=\"server\"><div id=\"div1\" runat=\"server\"><ul id=\"ul1\" runat=\"server\"><li id=\"li1\" runat=\"server\"></li></ul></div></body>";

            // Act
            string actual = htmlGenerator.GenerateTreeExample();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
