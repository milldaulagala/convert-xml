
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System;

namespace Computer
{
    public class Program
    {
        private static string style = "/Users/macos/xmlproject/ProgrammerTest/Resources/Computer.xslt";
        private static string inputDataPath = "/Users/macos/xmlproject/ProgrammerTest/Data/Computers";
        private static string outputResultPath = "/Users/macos/xmlproject/ProgrammerTest/Data/Output";


        public static void Main(string[] args)
        {          
            List<string> allXmlFiles = new List<string>();

           foreach (var xmlInputFile in Directory.EnumerateFiles(inputDataPath))
           {
             allXmlFiles.Add(xmlInputFile);
           }

            Parallel.ForEach(allXmlFiles, (currentFile) =>
            {   
                HTMLGenerator htmlGenerator = new HTMLGenerator();
               
                var xmlFile = htmlGenerator.LoadXml(currentFile);

                var xsltFile = htmlGenerator.LoadXml(style);

                var htmlResults = htmlGenerator.TransformXmlToHtml(xmlFile, xsltFile);

                var outputFileName = string.Format("Ouptput_{0}.html", Guid.NewGuid());

                Console.WriteLine("Html file generated -"+ outputFileName);

                htmlGenerator.GenerateHtml(outputResultPath, outputFileName, htmlResults);
            });

        
        }

    }

}
