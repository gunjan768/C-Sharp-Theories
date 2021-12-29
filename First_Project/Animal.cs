using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    internal class Animal
    {  
        public void Walk()
        {
            Console.WriteLine("Walking...");
        }

        public void Sound()
        {
            Console.WriteLine("Making sound...");
        }

        public virtual void Fight()
        {
            Console.WriteLine("Fighting...");
        }
    }
    internal class Dog: Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }

        // This is method hiding. To hide method of the parent class, use "new" keyword in the child method.
        public new void Sound()
        {
            Console.WriteLine("Bhaw bhaw...");
        }

        // To override a method, "virtual" keyword in the parent method and "override" keyword in the child method are required.
        public override void Fight()
        {
            Console.WriteLine("Dog fights...");
        }
    }
}
