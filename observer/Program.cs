using System.Collections;

namespace observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Motor m1 = new Motor("M1");
            Motor m2 = new Motor("M2");
            Sensor sensor = new Sensor();
          // int reading= sensor.getReading();
          sensor.addObserver(m1);
            sensor.addObserver(m2);
             
        }
    }

    public interface Observer
    {
        void getNotified();
    }

    public interface Observed
    {
        void notifyObservers();
    }
    class Motor:Observer
    {
        private string name;
        public Motor(string Name)
        {
            name= Name;
        }

        public void getNotified()
        {
            stop(); 
        }

        public void move()
        {
            Console.WriteLine(name+" is moving");
        }

        public void stop()
        {
            Console.WriteLine(" name is stopped");
        }
    }

    public class Sensor:Observed
    {
        List<Observer>observer;

        public Sensor()
        {
            observer = new List<Observer>();
        }
        public int getReading()
        {
            Console.WriteLine("sensor reading");
            return 20;
        }

        public void addObserver(Observer o)
        {
            observer.Add(o);
        }
        public void notifyObservers()
        {
           foreach(var o in observer)
            {
                o.getNotified();
            }  
        }
    }
}