using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Taxi
{
    public class Program
    {
        public static void Main()
        {
            var taxiStation = new TaxiStation();
            var reader = new Reader();
            reader.ReaderFile(ref taxiStation, "data.xml");
            Console.WriteLine("Все автомобили:");
            Console.WriteLine(taxiStation);
            Console.WriteLine("Общая стоимость:");
            Console.WriteLine(taxiStation.TotalCoast() + "\n");
            Console.WriteLine("Транспорт подходящий условиям:");
            List<Car> temp = taxiStation.SearchCarByMaxSpeed(60, 100);
            foreach(var t in temp)
                Console.WriteLine(t+"\n") ;
           
            Console.WriteLine("Добавить(y/n)?");
            if (Console.ReadLine() == "y")
            {
                taxiStation.AddToFile();
                var writer = new Writer();
                writer.WriteFile(ref taxiStation);
            }
            Console.ReadLine();
        }
    }
}
