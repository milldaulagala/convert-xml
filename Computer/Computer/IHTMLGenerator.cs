using System;


namespace Computer
{
    public interface IHTMLGenerator
    {
       string LoadXml(string path);
       string TransformXmlToHtml(string xmlStream, string xsltStream);
       void GenerateHtml(string path,string fileName, string htmlResult);

    }
}
