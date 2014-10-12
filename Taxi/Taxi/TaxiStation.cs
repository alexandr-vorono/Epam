using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class TaxiStation
    {

        private List<Car> carList = new List<Car>();

        public List<Car> CarsList
        {
            get { return carList; }
            set { carList = value; }
        }

        public int TotalCoast()
        {
            int summ = 0;
            foreach (var t in carList)
            {
                summ += t.Price;
            }
            return summ;
        }
        public List<Car> searchCarByMaxSpeed(int MinSpeed, int MaxSpeed)
        {
            List<Car> temp = new List<Car>();
            foreach(var t in carList)
            {
                if (t.Speed > MinSpeed && t.Speed < MaxSpeed)
                temp.Add(t);
            }
            return temp;
        }
        public override String ToString()
        {
            string s = "";
            foreach (var t in carList)
                s += t + "\n";
            return s;
        }
        public List<Car> addToFile()
        {
            
            List<Car> temp = new List<Car>();
            temp = CarsList;
            int countList = temp.Count();
            Console.WriteLine("Введите тип транспорта(Truck/Bus/PassengerCar):");
            string type = Console.ReadLine();
            Console.WriteLine("Введите марку:");
            string make = Console.ReadLine();
            Console.WriteLine("Введите модель:");
            string model = Console.ReadLine();
            Console.WriteLine("Введите максимальную  скорость:");
            int speed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите цену:");
            int price = Convert.ToInt32(Console.ReadLine());
            if (type == "Truck")
            {
                var tempAddList = new Truck();
                Console.WriteLine("Введите грузоподъемность:");
                tempAddList.Load = Convert.ToInt32(Console.ReadLine());
                temp.Add(tempAddList);
            }
            else if (type == "Bus")
            {
                var tempAddList = new Bus();
                Console.WriteLine("Введите количество  мест:"); 
                tempAddList.Count = Convert.ToInt32(Console.ReadLine());
                temp.Add(tempAddList);
            }
            else
            {
                var tempAddList = new PassengerCar();
                Console.WriteLine("Введите объем двигателя:");
                tempAddList.EngineVolume = Convert.ToInt32(Console.ReadLine());
                temp.Add(tempAddList);
            }
            temp[countList].Make = make;
            temp[countList].Model = model;
            temp[countList].Speed = speed;
            temp[countList].Price = price;
            return CarsList = temp;
        }
    }
}
