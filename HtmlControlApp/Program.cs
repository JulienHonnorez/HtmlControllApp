using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace HtmlControlApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlGenerator htmlGenerator = new HtmlGenerator();

            //Console.WriteLine(htmlGenerator.GenerateTag("div", "1", "div1", "Coucou"));
            Console.WriteLine(htmlGenerator.GenerateTreeExample());

            Console.ReadLine();
        }
    }
}
