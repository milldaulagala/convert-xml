using System.Xml.XPath;
using System.Xml.Linq;
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace Computer
{
    public class HTMLGenerator: IHTMLGenerator 
    {
        public string LoadXml(string path)
        {
            XElement xElement = XElement.Load(path);
           
            return xElement.ToString();

        }
        // TransformXmlToHtml method transforms the xml to html using the xslt.

        public string TransformXmlToHtml(string xmlStream, string xsltStream)
        {
            XslCompiledTransform transform = new XslCompiledTransform();
            using (XmlReader reader = XmlReader.Create(new StringReader(xsltStream)))
            {
                transform.Load(reader);

            }

            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlStream)))
            {
                transform.Transform(reader, null, results);
            }

            return results.ToString();

        }

        // GenerateHtml method creates the html file.

        public void GenerateHtml(string path, string fileName, string htmlContent)
        {
            var fullPath = string.Format("{0}/{1}", path, fileName);

           File.WriteAllText(fullPath, htmlContent);
        }

    }
}