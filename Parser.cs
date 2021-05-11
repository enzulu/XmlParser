using System;
using System.IO;
using System.Xml;

namespace XmlParser
{
    public class Parser
    {
        public Parser()
        {

        }

        /// <summary>
        /// Fetch and Process an XML file.
        /// For now, the process is basic printing of the XML Nodes.
        /// </summary>
        /// <param name="xmlPath">File path of the XML File.</param>
        public void ParseXmlDocument(string xmlPath)
        {
            var doc = new XmlDocument();

            try 
            { 
                doc.Load(xmlPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encountered in XML Path input, please try again.");
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("Parsing the Nodes of " + Path.GetFileName(xmlPath));
            Console.WriteLine("");
            IterateThroughAllNodes(doc);
        }

        /// <summary>
        /// Gets the string input of the user to be used as the XML File Path.
        /// </summary>
        /// <returns></returns>
        public string PromptInput()
        {
            Console.WriteLine("Enter file path of XML File: ");
            string xmlPath = Console.ReadLine();

            return xmlPath;
        }

        private void IterateThroughAllNodes(XmlNode node)
        {
            // main Action done per XmlNode, for now it's basic printing
            // Indents are added for children nodes
            Console.WriteLine(CreateIndent(node) + node.Name);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                IterateThroughAllNodes(childNode);
            }
        }

        private string CreateIndent(XmlNode node)
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
