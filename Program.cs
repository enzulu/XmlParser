using System;

namespace XmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();

            string xmlPath = (args.Length == 0) ? parser.PromptInput() : args[0];

            parser.ParseXmlDocument(xmlPath);
        }


    }
}
