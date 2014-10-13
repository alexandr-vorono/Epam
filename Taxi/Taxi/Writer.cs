using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Taxi
{
    /// <summary>
    /// Класс для сохрание в xml  файл
    /// </summary>
    class Writer
    {
        /// <summary>
        /// Сохранение в xml файл
        /// </summary>
        /// <param name="taxiStation">Объект таксопарка</param>
        public void WriteFile(ref TaxiStation taxiStation)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Taxi>" + "</Taxi>");
            foreach (var t in taxiStation.CarsList)
            {
                XmlElement element = doc.CreateElement("taxi");
                if (t is Truck)
                {
                    var temp = t as Truck;
                    element.SetAttribute("type", "Truck");
                    XmlElement elementLoad = doc.CreateElement("load");
                    XmlText textLoad = doc.CreateTextNode(Convert.ToString(temp.Load));
                    doc.DocumentElement.AppendChild(element);
                    element.AppendChild(elementLoad);
                    element.LastChild.AppendChild(textLoad);
                }
                else if (t is Bus)
                {
                    var temp = t as Bus;
                    element.SetAttribute("type", "Bus");
                    XmlElement elementCount = doc.CreateElement("count");
                    XmlText textCount = doc.CreateTextNode(Convert.ToString(temp.Count));
                    doc.DocumentElement.AppendChild(element);
                    element.AppendChild(elementCount);
                    element.LastChild.AppendChild(textCount);
                }
                else 
                {
                    var temp = t as PassengerCar;
                    element.SetAttribute("type", "PassengerCar");
                    XmlElement elementObem = doc.CreateElement("engineVolume");
                    XmlText textObem = doc.CreateTextNode(Convert.ToString(temp.EngineVolume));
                    doc.DocumentElement.AppendChild(element);
                    element.AppendChild(elementObem);
                    element.LastChild.AppendChild(textObem);
                }
                XmlElement elementMake = doc.CreateElement("make");
                XmlText textMake = doc.CreateTextNode(t.Make);
                XmlElement elementModel = doc.CreateElement("model");
                XmlText textModel = doc.CreateTextNode(t.Model);
                XmlElement elementSpeed = doc.CreateElement("speed");
                XmlText textSspeed = doc.CreateTextNode(Convert.ToString(t.Speed));
                XmlElement elementPrice = doc.CreateElement("price");
                XmlText textPrice = doc.CreateTextNode(Convert.ToString(t.Price));
                element.AppendChild(elementMake);
                element.LastChild.AppendChild(textMake);
                element.AppendChild(elementModel);
                element.LastChild.AppendChild(textModel);
                element.AppendChild(elementSpeed);
                element.LastChild.AppendChild(textSspeed);
                element.AppendChild(elementPrice);
                element.LastChild.AppendChild(textPrice);
            }
            doc.Save("data.xml");
        }
    }
}
