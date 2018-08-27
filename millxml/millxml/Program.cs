using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace millxml
{


    class Program
    {
        public static void Main(string[] args)
        {
            // Xml Serialization
            Computer obj = new Computer()
            {
                name = "Comp_AMS010004",
                memory = "504",
                product = "HP d530 SFF(DC578AV)"
            };
            XmlSerializer serObj = new XmlSerializer(typeof(Computer));
            StreamWriter write = new StreamWriter(@"/Users/macos/xmlproject/Computer.xml");
            serObj.Serialize(write, obj);
           //Console.WriteLine("Hello World!");
            write.Close();

            // Xml Deserialize
            StreamReader rdr = new StreamReader(@"/Users/macos/xmlproject/Computer.xml");
            Computer DeserializedObj = (Computer)serObj.Deserialize(rdr);

            Console.WriteLine(DeserializedObj.name);
            Console.WriteLine(DeserializedObj.memory);
            Console.WriteLine(DeserializedObj.product);
        }
    }


    public class Computer
    {
        public string name { get; set; }
        public string memory { get; set; }
        public string product { get; set; }
    }
}
