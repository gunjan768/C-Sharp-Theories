using System;
using System.Collections.Generic;

namespace Mosh_Hamedani
{
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public virtual void Draw()
        {

        }
    }

    public class Text: Shape
    {
        public int FontSize { get; set; }
        public string FontName { get; set; }

    }

    // ********************************************************* Overriding *******************************************************
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a rectangle");
        }

    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a circle");
        }

    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a traingle");
        }

    }
    public class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach(var shape in shapes)
            {
                // At runtime, shape variable can be any child of Shape class, hence calls the respective Draw() method.
                shape.Draw();
            }
        }
    }

    // ************************************************* Abstract *****************************************************
    public abstract class Animal
    {
        public abstract void Run();
    }

    public class Dog : Animal
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }
    }

    // ******************************************* Sealed Modifier *****************************************************
    // Sealed Modifier prevents derivation of classes or overriding of methods. It is similar to "final" keyword in Java.
    public sealed class Gunjan {  }

    // You can't derive Gunjan as it is decalred as "sealed". Uncommenting below line will throw an error.
    // public class A: Gunjan

    public class A
    {
        public virtual void Run()
        {

        }
    }

    public class B : A
    {
        // Note that sealed modifier can only be applied to the methods that are overriding a virtual method of base
        // class.
        public sealed override void Run()
        {
            base.Run();
        }
    }

    // ******************************************* Interfaces *****************************************************

    public interface IShipping
    {
        float Cal(double c);
    }

    public class Shipping : IShipping
    {
        public float Cal(double c)
        {
            throw new NotImplementedException();
        }
    }

    public class Order
    {
        private readonly IShipping _shipping;

        public Order(IShipping shipping)
        {
            _shipping = shipping;
        }

        public int Process(int form)
        {
            if (form == 0)
            {
                throw new InvalidOperationException("Wrong...");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Order successful");
            return form;
        }
    }
}
