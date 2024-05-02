using System;
using System.Xml;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace appReadXML_From_URL
{
    class Program
    {
        static void Main(string[] args)
        {
 
            string URL = "https://www.w3schools.com/xml/cd_catalog.xml";

            using (XmlTextReader reader = new XmlTextReader(URL))
            {
                List<string> columnNames = new List<string>();

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            string name = reader.Name;
                            Console.Write("<" + reader.Name);

                            while (reader.MoveToNextAttribute())
                                Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                            Console.WriteLine(">");

                            if (!columnNames.Contains(name))
                            {
                                columnNames.Add(name);
                            }
                            break;
                        case XmlNodeType.Text: // El nodo contiene texto
                            Console.WriteLine(reader.Value);
                            break;
                        case XmlNodeType.EndElement: // El nodo es el fin de un elemento
                            Console.WriteLine("</" + reader.Name + ">");
                            break;
                    }
                }

                // Mostrar los nombres de las columnas
                Console.WriteLine("Columnas:");
                foreach (string columnName in columnNames)
                {
                    Console.WriteLine(columnName);
                }
            }

            Console.ReadLine();
        }
    }
}
