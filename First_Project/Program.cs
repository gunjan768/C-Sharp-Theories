using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    internal class Program
    {
        static void operString()
        {
            string name = "Gunjan is a good boy";
            int age = 10;

            Console.WriteLine(name + " " + name.Length + "\nAge: " + age);
            Console.WriteLine("Upper Case: " + name.ToUpper());
            Console.WriteLine("Contains Good: " + name.Contains("Good"));
            Console.WriteLine("'good' starting index: " + name.IndexOf("good"));
            Console.WriteLine("'Good' not present: " + name.IndexOf("Good"));
            Console.WriteLine("Substring: " + name.Substring(8));
            Console.WriteLine("Substring: " + name.Substring(2, 4));

            Console.Write("Enter your name: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Hello: " + Name);

            Console.WriteLine("***************************************************************");
        }

        static void operNum()
        {
            int num = Convert.ToInt32("45");
            int num1 = Convert.ToInt32(Console.ReadLine());
            double d1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(Math.Abs(-7) + " " + Math.Pow(2, 3) + " " + Math.Sqrt(38) + " " + (int)Math.Sqrt(38));
        }

        static void operArray()
        {
            int[] arr = { 4, 2, 54, (int)2.99 };
            int[] arr1 = new int[] { 12, 2, 43, 2323, -9232 };
            string[] arr2 = new string[] { "gun", "hey" };
            string[] arr3 = new string[10];
            arr3[0] = "Bro";

            Console.WriteLine("Array: " + arr.Length + " " + arr[arr.Length - 1]);
        }
        static void operIfElse()
        {
            bool isMale = true;
            bool isTall = true;

            if(isMale && isTall)
            {
                Console.WriteLine("Both");
            }
            else if(isMale)
            {
                Console.WriteLine("Only Male");
            }
            else if (isTall)
            {
                Console.WriteLine("Only Tall");
            }
            else
            Console.WriteLine("None");
        }

        static void operSwitch()
        {
            int ch = 1;

            switch(ch)
            {
                case 0:
                    Console.WriteLine("0 case");
                    break;
                case 1:
                    Console.WriteLine("1 case");
                    break;
                case 2:
                    Console.WriteLine("2 case");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        static void operInterations()
        {
            int i = 0;

            while (i <= 5) ++i;

            for(int j = 0; j<5; ++j)
            {
                Console.WriteLine("i: " + i);
            }
        }

        static void oper2DArrays()
        {
            int [,] arr = { { 1, 2, 3 }, { 4, 5, 6 }, { 6, 7, 8 } };
            int[,] arr1 = new int[,] { { 1, 2, }, { 4, 5, } };
            int[,] arr2 = new int[2, 3];

            Console.WriteLine(arr[1, 2]);
        }

        static void exceptionHandling()
        {
            try
            {
                int num1 = Convert.ToInt32(Console.ReadLine());
                double num2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(num1 / num2);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format Error: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                Console.WriteLine("Final block always run");
            }
        }

        static void operClass()
        {
            Book book = new Book("Prabhat", "About love", 12);
            Console.WriteLine(book.Title);
            book.Title = "Gunjan";
            Console.WriteLine(book.Title);
            book.Title = "Shiwani";
            Console.WriteLine(book.Title);
        }

        static void testStaticMember()
        {
            Console.WriteLine("count: " + Book.Count);
            Console.WriteLine("count1: " + Book.count1);
            Console.WriteLine("total: " + Book.TotalGS);

            Book book = new Book();
            Console.WriteLine("count: " + book.Total);
            Console.WriteLine("total: " + book.getTotal());
            Console.WriteLine("count: " + Book.Count);

            Book book1 = new Book();
            Console.WriteLine("total using instance method: " + book1.getTotal());
            Console.WriteLine("total using static method: " + Book.getTotalUsingStaticMethod());
            Console.WriteLine("total using instance getter and setter: " + book1.Total);
            Console.WriteLine("total using static getter and setter: " + Book.TotalGS);

            Book.Count = 12;
            Book.count1 = 21;
            Console.WriteLine("count: " + Book.Count);
            Console.WriteLine("count1: " + Book.count1);

            Book book2 = new Book();
            Console.WriteLine("pages: " + book2.Pages);
            book2.Pages = 178;
            Console.WriteLine("pages: " + book2.Pages);
        }

        static void inheritance()
        {
            Dog dog = new Dog();
            dog.Eat();
            dog.Sound();
            dog.Walk();
            dog.Fight();
        }

        static void ObjectInitializer()
        {
            // There is no need for Constructor (or to avoid multiple constructors). This is object initializer.
            Person person = new Person()
            {
                Name = "Gunjan",
                Age = 12,
                Id = 1,
                MobileNo = 9988
            };

            Console.WriteLine(person.Name);
        }

        static void Main(string[] args)
        {
            ObjectInitializer();
            Console.ReadLine();
        }
    }
}
