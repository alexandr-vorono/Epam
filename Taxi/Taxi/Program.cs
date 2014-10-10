﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Taxi
{
    public class Program
    {
        public static void Main()
        {
            Taxi list = new Taxi();
            Reader read = new Reader();
            read.ReaderFile(ref list, "data.xml");
            Console.WriteLine("Все автомобили.");
            Console.WriteLine(list);
            Console.WriteLine("Общая стоимость:");
            Console.WriteLine(list.TotalCoast() + "\n");
            Console.WriteLine("Транспорт подходящий условиям:");
            List<Car> temp = new List<Car>();
            temp = list.SearchCarByMaxSpeed(60, 100);
            foreach(var t in temp)
                Console.WriteLine(t+"\n") ;
            writer();
        }


        public static void writer()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<book>" + "</book>");
            //for (int i = 0; i < 5; i++)
            //{
            XmlElement elem = doc.CreateElement("taxi");
            elem.SetAttribute("type", Console.ReadLine());
            // XmlText text = doc.CreateTextNode(Console.ReadLine());
            XmlElement elem1 = doc.CreateElement("model");
            XmlText text1 = doc.CreateTextNode(Console.ReadLine());
            XmlElement elem2 = doc.CreateElement("speed");
            XmlText text2 = doc.CreateTextNode(Console.ReadLine());
            doc.DocumentElement.AppendChild(elem);
            doc.DocumentElement.AppendChild(elem);
            elem.AppendChild(elem1);
            elem.LastChild.AppendChild(text1);
            elem.AppendChild(elem2);
            elem.LastChild.AppendChild(text2);
            //}
            doc.Save("data.xml");
        }
    }
}
