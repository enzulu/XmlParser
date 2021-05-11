using System;
using System.Xml;

namespace XmlParser
{
    class Program
    {
        static void Main(string[] args)
        {

            var doc = new XmlDocument();
            doc.Load(args[0]);

            IterateThroughAllNodes(doc);
        }

        static private void IterateThroughAllNodes(XmlNode node)
        {
            Console.WriteLine(CreateIndent(node) + node.Name);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                IterateThroughAllNodes(childNode);
            }
        }

        static private string CreateIndent(XmlNode node)
        {
            var outputIndent = String.Empty;

            while (node.ParentNode != null)
            {
                outputIndent += "-";
                node = node.ParentNode;
            }

            return outputIndent;
        }
    }
}
