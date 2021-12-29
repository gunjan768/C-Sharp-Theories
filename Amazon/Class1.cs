using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    internal class RateCalculator
    {
        public int Calculate(Customer customer)
        {
            return 0;
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        private string Address { get; set; }
        protected int Id { get; set; }

        public void Promote()
        {
            var calculator = new RateCalculator();
            var rating = calculator.Calculate(this);

            Console.WriteLine("Rating {0}", rating);
        }
    }

    public class Vehicle
    {
        private readonly string registNo;

        public Vehicle()
        {
            
        }

        public Vehicle(string registNo)
        {
            this.registNo = registNo;
        }
    }

    public class Car: Vehicle
    {
        // base() will call the base class constructor. If you will remove the default constructor from the Vehicle class
        // and also base(registNo) from here, compiler will throw an error. Because, before calling the constructor of Car
        // class, compiler will try to call the default constructor of the Vehicle class (as we have remove the base(arg))
        // So we can do: 1) If we are adding any parametrized constructor in the Vehicle class and not calling it's ctor
        // from the Car class, then also add default constructor (as compiler will not able to add by it's own). Or if
        // calling any of it's parametrized constructor, then there is no need to add the default one in Vehicle class. 
        public Car(string registNo): base(registNo)
        {
            
        }
    }
}
