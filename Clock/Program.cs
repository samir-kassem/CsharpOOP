using System;

namespace Clock
{

    public class ClockHand
    {
        public int value { get; set; }
        public int limit { get; set; }

        public ClockHand(int limit)
        {
            this.limit = limit;
            this.value = 0;
        }

        public void Advance()
        {
            this.value++;
            if (this.value >= this.limit)
                this.value = 0;
        }

        public override string ToString()
        {
            if (this.value < 10)
                return "0" + this.value;

            return "" + this.value;
        }
    }

    public class Clock
    {
        private ClockHand minutes;
        private ClockHand seconds;
        private ClockHand hours;

        public Clock()
        {
            this.hours = new ClockHand(24);
            this.minutes = new ClockHand(60);
            this.seconds = new ClockHand(60);
        }

        public void Advance()
        {
            this.seconds.Advance();

            if (this.seconds.value == 0)
            {
                this.minutes.Advance();
                if (this.minutes.value == 0)
                    this.hours.Advance();
            }
        }

        public override string ToString()
        {
            return hours + ":" + minutes + ":" + seconds;
        }
    }

    public class Timer
    {
        ClockHand seconds;
        ClockHand hundredths;

        public Timer()
        {
            seconds = new ClockHand(60);
            hundredths = new ClockHand(100);
        }

        public void Advance()
        {
            this.hundredths.Advance();
            if (this.hundredths.value == 0)
                this.seconds.Advance();
        }

        public override string ToString() => $"{this.seconds}:{this.hundredths}";

        public void run()
        {
            while (true)
            {
                Console.WriteLine(this);
                this.Advance();
                try
                {
                    System.Threading.Thread.Sleep(10);
                } catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
    }

    public class Person
    {
        private string name;
        private int age;
        private double weight;
        private double height;

        /* Constructor Overloading */
        public Person(string name) : this(name, 0)
        {

        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.weight = 0;
            this.height = 0;
        }


        public Person(string name, int age, double weight, double height)
        {
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.height = height;
        }

        public double BMI() => this.weight / Math.Pow(this.height, 2);
        public double MHR() => 206.3 - (0.711 * this.age);
        public void GrowOlder()
        {
            if (this.age < 100)
                this.age++;
        }

        public override string ToString() => $"{this.name}:\n\tBMI: {this.BMI()}\n\tMHR: {this.MHR()}";



    }

    public class Cube
    {
        private int edge_length;
        public Cube(int length)
        {
            this.edge_length = length;
        }

        public int Volume() => (int)Math.Pow(this.edge_length, 3);

        public override string ToString()
        {
            return $"Length of the edge: {this.edge_length}\nVolume: {this.Volume()}";
        }
    }

    public class Fitbyte
    {
        private int age, resting_heart_rate;
        public Fitbyte(int age, int resting_heart_rate)
        {
            this.age = age;
            this.resting_heart_rate = resting_heart_rate;
        }

        public double TargetHeartRate(double percentage)
        {
            double max_rate = 206.3 - (0.711 * this.age);
            return (max_rate - this.resting_heart_rate) * percentage + this.resting_heart_rate;
        }
    }

    public class Product
    {
        private string name, location;
        private double weight;
        public Product(string name) : this(name,"shelf")
        {
            this.name = name;
        }

        public Product(string name, string location)
        {
            this.location = location;
            this.weight = 1;
        }

        public Product(string name, int weight)
        {
            this.name = name;
            this.location = "warehouse";
            this.weight = weight;
        }

        public override string ToString()
        {
            return $"{this.name} | {this.location} | {this.weight}";
        }


    }

    public class Counter
    {
        public int value { get; set; }

        public Counter()
        {
            this.value = 0;
        }

        public Counter(int value)
        {
            this.value = value;
        }

        public void Increase() => this.value++;
        public void Descrease() => this.value--;
        public void IncreaseBy(int val)
        {
            if (val > 0)
                this.value += val;
        }

        public void DecreaseBy(int val)
        {
            if (val > 0)
                this.value -= val;
        }
    }





    internal class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();

            //while (true)
            //{
            //    Console.WriteLine(clock);
            //    clock.Advance();
            //    System.Threading.Thread.Sleep(1000);

            //}

            //Person P = new Person("jack", 22, 75, 173.4);
            //Console.Write(P);

            //Timer timer = new Timer();
            //timer.run();


            //Cube C = new Cube(10);
            ////Console.WriteLine(C);


            //Fitbyte assistant = new Fitbyte(30, 60);
            //double percentage = 0.5;

            //while(percentage < 1.0)
            //{
            //    double target = assistant.TargetHeartRate(percentage);
            //    Console.WriteLine("Target: " + (percentage * 100) + "% of maximum: " + target);
            //    percentage += 0.1;

            //}



        }
    }
}
