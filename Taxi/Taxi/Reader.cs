using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace Taxi
{
    public class Reader
    {
        public void ReaderFile(ref Taxi taxi, string fileName = "data.xml")
        {
            var xml = XDocument.Load(fileName);
            var qwe = new List<Car>();
            var cars = xml.Root.Descendants("taxi").Select(x => x);
            foreach (var el in cars)
            {
                var name1 = el.Attribute("type").Value;
                switch (name1)
                {
                    case "Truck":
                        var tempCarT = new Truck();
                        tempCarT.name = name1;
                        tempCarT.model = Convert.ToString(el.Element("model").Value);
                        tempCarT.speed = Convert.ToInt32(el.Element("speed").Value);
                        tempCarT.load = Convert.ToInt32(el.Element("load").Value);
                        qwe.Add(tempCarT);
                        break;
                    case "Bus":
                        var tempCarB = new Bus();
                        tempCarB.name = name1;
                        tempCarB.model = Convert.ToString(el.Element("model").Value);
                        tempCarB.speed = Convert.ToInt32(el.Element("speed").Value);
                        tempCarB.count = Convert.ToInt32(el.Element("count").Value);
                        qwe.Add(tempCarB);
                        break;
                    case "PassengerCar":
                        var tempCarP = new PassengerCar();
                        tempCarP.name = name1;
                        tempCarP.model = Convert.ToString(el.Element("model").Value);
                        tempCarP.speed = Convert.ToInt32(el.Element("speed").Value);
                        tempCarP.obem = Convert.ToInt32(el.Element("obem").Value);
                        qwe.Add(tempCarP);
                        break;
                    default: break;
                }
            }

            var taxi1 = new Taxi() { CarsList = qwe.ToList() };
            taxi = taxi1;
            //    foreach (string name in query)
            //    {
            //      //  taxi.CarsList.Add(name);
            //        Console.WriteLine("Cars: {0}", name);
            //    }
        }

    }
}
