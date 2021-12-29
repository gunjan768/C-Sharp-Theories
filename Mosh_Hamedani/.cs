using System;

// There are Five types of Access Modifiers: public, protected, private, internal, protected internal
// 3) Protected: is accessible only from the class and it's derived class.
// 4) Internal: accessible only from the same assembly.
// 5) Protected Internal: accessible only from the same assembly or any derived classes.

// Inheritance -> Cons: Code re-use, sometimes easier to understand (like Dog is an animal rather than Dog has an animal).
// Cons: Tightly coupled, fragile, can be abused

// A composition is a kind of realtionship b/w two classes that allows one to contain the other. It has a "Has-a/an" relationship.
// Example: Car has an engine. Benefits are: Code re-use, flexibility, a means of loose coupling (using an interface).

// Problems with Inheritance: Large hierarchies, Fragility, Tight Coupling. If there will be any change in the base class, all the child classes
// will be affected. For example: Animal as base class with Eat() and Sleep() methods. Dog, Cat and Fish is derived from it. Lets say we added
// Walk() method to the base class. Then it will affect the Fish as it can't walk. Hierarchy is abused by amateur designers / developers and it
// results in large hierarchies which are Fragile because of Tight Coupling b/w classes.

// We can resolve the above problem using Composition. Don't go by English language that Dog is an animal. Here in compostion we will say Dog has
// an animal. We need to design our classes such that changes in a class are isolated and has minimal impact on other classes or system. We will
// make a different class Walkable which contains Walk() method. Dog and Cat have Walkable class as a composition. But Fish doesn't has Walkable. 

namespace Mosh_Hamedani
{
    public class Human
    {
        public string Name { get; set; }
        private string Address { get; set; }
        protected int Id { get; set; }
    }

    public class GoldCustomer: Human
    { 
        public void Offer()
        {
            this.Name = "Gunjan";
            this.Id = 12;

            // We can't access private members i.e. accessing "Address" will throw an error"
            // this.Address
        }
    }

    public class DbMigrator
    {
        private readonly Logger logger;

        public DbMigrator(Logger logger)
        {
            this.logger = logger;
        }

        public void Migrate()
        {
            // Can only name "a" i.e. the same name we used in the former parameters (in the function definition).
            Rating(a: true);
            logger.Log("We are migrating.......");
        }

        private void Rating(bool a)
        {

        }
    }

    public class Installer
    {
        private readonly Logger logger;

        public Installer(Logger logger)
        {
            this.logger = logger;
        }

        public void Install()
        {
            logger.Log("We are installing.......");
        }
    }

    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
