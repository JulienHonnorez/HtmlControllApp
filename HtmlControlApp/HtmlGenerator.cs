using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace HtmlControlApp
{
    public class HtmlGenerator : HtmlContainerControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HtmlGenerator()
        {
        }

        /// <summary>
        /// Generate a single tag containing innerText content or not.
        /// </summary>
        /// <param name="tag">The tag to generate</param>
        /// <param name="id">The tag's id to add as tag's attribute</param>
        /// <param name="name">The tag's name to add as tag's attribute</param>
        /// <param name="innexText">The content to put inside the tag</param>
        /// <returns></returns>
        public string GenerateTag(string tag, string id, string name, string innexText = null)
        {
            StringBuilder sbControlHtml = new StringBuilder();
            using (StringWriter stringWriter = new StringWriter())
            {
                using (HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter))
                {
                    //Generate Tag
                    HtmlGenericControl divControl = new HtmlGenericControl(tag);
                    divControl.Attributes.Add("id", id);
                    divControl.Attributes.Add("name", name);
                    if (innexText != null)
                    {
                        divControl.InnerText = innexText;
                    }

                    //Generate HTML string and dispose object
                    divControl.RenderControl(htmlWriter);
                    sbControlHtml.Append(stringWriter.ToString());
                    divControl.Dispose();
                }

                return sbControlHtml.ToString();
            }
        }

        /// <summary>
        /// Allow to generate a 4 level tree example using HtmlGenericControl class
        /// </summary>
        /// <returns></returns>
        public string GenerateTreeExample()
        {
            StringBuilder sbControlHtml = new StringBuilder();
            using (StringWriter stringWriter = new StringWriter())
            {
                using (HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter))
                {
                    // Generate container body control
                    HtmlGenericControl bodyControl = new HtmlGenericControl("body");
                    bodyControl.Attributes.Add("id", "body1");
                    bodyControl.Attributes.Add("runat", "server");

                    // Generate container div control
                    HtmlGenericControl divControl = new HtmlGenericControl("div");
                    divControl.Attributes.Add("id", "div1");
                    divControl.Attributes.Add("runat", "server");

                    // Generate container div control
                    HtmlGenericControl ulControl = new HtmlGenericControl("ul");
                    ulControl.Attributes.Add("id", "ul1");
                    ulControl.Attributes.Add("runat", "server");

                    // Generate container div control
                    HtmlGenericControl liControl = new HtmlGenericControl("li");
                    liControl.Attributes.Add("id", "li1");
                    liControl.Attributes.Add("runat", "server");

                    // Create Tree
                    bodyControl.Controls.Add(divControl);
                    divControl.Controls.Add(ulControl);
                    ulControl.Controls.Add(liControl);

                    // Generate HTML string and dispose object
                    bodyControl.RenderControl(htmlWriter);
                    sbControlHtml.Append(stringWriter.ToString());
                    bodyControl.Dispose();
                }

                return sbControlHtml.ToString();
            }
        }

        /// <summary>
        /// Allow to find a specific control inside Html page based on its ID.
        /// </summary>
        /// <param name="page">The html page</param>
        /// <param name="controlId">The control's id to search</param>
        /// <returns></returns>
        public HtmlGenericControl FindControlElement(Page page, string controlId)
        {
            return (HtmlGenericControl)page.FindControl(controlId);
        }

        //public string XElementMethod()
        //{
        //    return new XElement("body",
        //                new XAttribute("id", "body1"),
        //            new XElement("div",
        //                new XAttribute("id", "div1"))).ToString();
        //}
    }
}
