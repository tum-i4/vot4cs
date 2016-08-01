using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCalculator;

namespace ConsoleCalculator
{
    class RangomGenerator
    {
        public static Random Rand = new Random();
    }
    

    interface ICarEvent
    {
        String eventHandler(string eventName);
        String ToString();
    }

    internal class Piston
    {
        private static int COUNTER = 1;

        public static string TYPE = "PISTON";

        public static int GetCounter() => COUNTER;

        private int order;
        private double size;
        private string id;

        public Piston(int order, double size, string id)
        {
            this.order = order;
            this.size = size;
            this.id = id;
        }

        public string GetId() => id;

        public double GetSize() => size;

        public int GetOrder() => order;

        public override String ToString()
        {
            string result = "";

            result = "#" + order + "_" + size + "_" + id;

            return result;
        }
    }


    internal class Engine
    {
        private static int COUNTER = 1;

        public static string TYPE = "ENGINE";

        public static int GetCounter() => COUNTER;  

        private List<Piston> pistons;
        private int size;
        private bool turbinePresent;
        private bool compressorPresent;

        private string serialNumber;

        public Engine(int pistons, int size, string serialNumber)
        {
            this.pistons = new List<Piston>();
            for (int i = 0; i < pistons; i++)
            {
                Piston p = new Piston(i + 1, ((double)size)/pistons, RangomGenerator.Rand.Next() + "");
                this.pistons.Add(p);
            }
            this.size = size;
            this.serialNumber = serialNumber;
        }

        public bool TurbineStatus { get; set; }
        public bool CompressorStatus { get; set; }

        public string SerialNumber 
        {
            get
            {
                return serialNumber;
            }
        }

        public List<Piston> GetPistons() => pistons;

        public Piston GetPiston(int order)
        {
            if (order <= 0)
                return null;
            if (order > pistons.Count)
                return null;
            return pistons[order];
        }

        public int GetEngineSize() => size;

    public override string ToString()
    {
        string result = "";
        string pistonsString = this.pistons.Aggregate("", (current, p) => current + (p.ToString() + " / "));
        result += "#" + serialNumber + "_" + size + "_pistons: " + pistonsString;
        return result;
    }
}

    internal class Car
    {

        public static Engine EngineType;

        private static int COUNTER = 1;

        public static string TYPE = "CAR";

        public static int GetCounter() => COUNTER;

        private List<ICarEvent> _events;
        private int _doors;

        public int Doors
        {
            get { return this._doors; }

            set { this._doors = value; }
        }

        private string _id;

        public string Id
        {
            get { return this._id; }
        }

        private Engine engine;

        public Car(string id, int doors)
        {            
            this._id = id;
            this._doors = doors;
            this._events = new List<ICarEvent>();
            this.engine = new Engine(RangomGenerator.Rand.Next(2,12), RangomGenerator.Rand.Next(), "" + RangomGenerator.Rand.Next());
            COUNTER++;
        }

        public Engine Engine2 { get; set; }

        public Engine Engine => engine;

        public Engine GetEngine()
        {
            return engine;
        }

        public override string ToString()
        {
            return string.Format("[{0}: doors {1}; engine {2}]", Id, Doors, engine);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Car car = null;
            try
            {
                car = (Car) obj;
            }
            catch (InvalidCastException ex)
            {
                return false;
            }

            bool idOk = this.Id.Equals(car.Id);
            bool doorsOk = this.Doors.Equals(car.Doors);
            return idOk && doorsOk;
        }

        public void registerEvent(ICarEvent eventName)
        {
            _events.Add(eventName);
        }

        public void displayEvents()
        {
            Console.WriteLine(this + " events");
            foreach (ICarEvent ev in _events)
            {
                Console.WriteLine(ev);
            }
        }

    }


}