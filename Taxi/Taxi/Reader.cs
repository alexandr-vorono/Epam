using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Taxi.Cars;


namespace Taxi
{
    /// <summary>
    /// Класс чтения из  xml файла.
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// Чтение из  xml файла.
        /// </summary>
        /// <param name="taxi">Объект таксопарка.</param>
        /// <param name="fileName">Название файла.</param>
        public void ReaderFile(ref TaxiStation taxi, string fileName)
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
                        tempCarT.Make = Convert.ToString(el.Element("make").Value);
                        tempCarT.Model = Convert.ToString(el.Element("model").Value);
                        tempCarT.Speed = Convert.ToInt32(el.Element("speed").Value);
                        tempCarT.Price = Convert.ToInt32(el.Element("price").Value);
                        tempCarT.Load = Convert.ToInt32(el.Element("load").Value);
                        qwe.Add(tempCarT);
                        break;
                    case "Bus":
                        var tempCarB = new Bus();
                        tempCarB.Make = Convert.ToString(el.Element("make").Value);
                        tempCarB.Model = Convert.ToString(el.Element("model").Value);
                        tempCarB.Speed = Convert.ToInt32(el.Element("speed").Value);
                        tempCarB.Price = Convert.ToInt32(el.Element("price").Value);
                        tempCarB.Count = Convert.ToInt32(el.Element("count").Value);
                        qwe.Add(tempCarB);
                        break;
                    case "PassengerCar":
                        var tempCarP = new PassengerCar();
                        tempCarP.Make = Convert.ToString(el.Element("make").Value);
                        tempCarP.Model = Convert.ToString(el.Element("model").Value);
                        tempCarP.Speed = Convert.ToInt32(el.Element("speed").Value);
                        tempCarP.Price = Convert.ToInt32(el.Element("price").Value);
                        tempCarP.EngineVolume = Convert.ToDouble(el.Element("engineVolume").Value);
                        qwe.Add(tempCarP);
                        break;
                    default: break;
                }
            }
            var taxi1 = new TaxiStation() { CarsList = qwe.ToList() };
            taxi = taxi1;
        }
    }
}
