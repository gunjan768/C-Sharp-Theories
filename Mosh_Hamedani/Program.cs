using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;

using System.IO;
using System.Collections;

// There are Five types of Access Modifiers: public, protected, private, internal, protected internal

namespace Mosh_Hamedani
{

    internal class Program
    {
        // A Field is a variable which is declared at the class level and is used to store the data of the class. List<> is an example of Field.
        // 'readonly' keyword is used to declare the field so that field can only be assigned once. In this case, field has to be initialized either
        // directly or in any of the constructors.
        readonly List<string> args = new List<string>();

        public static int Add(int[] a)
        {
            return a.Length;
        }

        public static int ParamasRef(params int[] a)
        {
            var sum = 0;

            foreach (var it in a) sum += it;

            return sum;
        }

        public static void RefModifier(ref int a)
        {
            a += 2;
        }
        public static void OutModifier()
        {
            try
            {
                // It will throw an error as "abc" can be parsed (changed) to integer
                var number = int.Parse("abc");
                Console.WriteLine("Parsed number is: {0}", number);
            }
            catch (Exception e)
            {
                Console.WriteLine("Conversion failed");
            } finally
            {
                // TryParse() returns bool type. Returns true if conversion is successful. Converted integer will be stored in the variable
                // passed as a second argument i.e. "num". It doesn't throw exception like int.Parse(), instead returns bool type.
                var isParsed = int.TryParse("1653", out int num);

                if (isParsed)
                {
                    Console.WriteLine("Conversion of {0} is {1} and the parsed number is {2}", "abc", isParsed, num);
                }
            }
        }

        public static void Modifiers()
        {
            // Signature of method includes name and parameters (number and type of parameters)

            // 1) ............... We can avoid multiple parameters of same type by using an array.
            // Everytime we have to create an array using new keyword.
            Console.WriteLine(Add(new int[] { 1, 2, 3, 4 }));

            // 2) Now it is not necessary to create an array. We can directly pass the numbers and array will be automatically generated in the
            // method definition (as we are using "params" keyword. This is called Params Modifier. We can use the old method (by creating an
            // array) also. 
            Console.WriteLine(ParamasRef(1, 2, 3, 4));

            // 3) ................ Ref Modifier. "ref" keyword catches the parameters by reference (similar to pass by reference). Any changes
            // made to 'a' reflects the original value.
            var a = 2;
            RefModifier(ref a);

            // 4) ................ Out Modifier.
            OutModifier();
        }

        public static void testDateTime()
        {
            Person person = new Person();
            person.SetBirthDate(new DateTime(2021, 12, 21));

            Console.WriteLine("Date and Time: {0}", person.GetBirthDate());
            Console.WriteLine("Name: {0}", person.Name);
        }

        public static void Indexer()
        {
            var person = new Person();
            person["name"] = "Gunjan";
            Console.WriteLine("Using Indexer: {0}", person["name"]);
        }

        public static void Composition()
        {
            var dbMigrator = new DbMigrator(new Logger());
            var installer = new Installer(new Logger());
            dbMigrator.Migrate();
            installer.Install();
        }

        public static void AccessModifiers()
        {
            var customer = new Customer();

            // You can't be able to access RateCalculator class here as RateCalculator is declared as "internal".
            //Amazon.RateCalculator     // Throws an error
        }

        public static void Casting()
        {
            Text text = new Text();
            
            // Upcasting
            Shape shape = text;
            Shape shape1 = new Text();

            // If you try to access shape.FontName or shape.FontSize... means any property or field of Text class, it will
            // throw an error. Though it is present but will onl be visible at runtime.

            // Downcasting. 
            Text anotherText = (Text)shape;

            text.Width = 200;
            shape.Width = 100;  // It will change the value of text.Width as Text and Shape are reference types.

            Console.WriteLine("Values are: {0}, {1}", text.Width, shape.Width);

            // Some more examples of Upcasting

            // Base class: Stream, Children: FileStream, MemoryStream etc. StreamReader ctor accepts any class derived from
            // the Stream class.
            StreamReader streamReader = new StreamReader(new MemoryStream());

            // Add(object obj) i.e. accepts object type. Remember that "object" class is a base class for all classes in
            // .Net framework.
            var list = new ArrayList();
            list.Add(1);
            list.Add("gunjan");
            list.Add(new Text());

            // If you try to downcast a shape object to another type which other than text, compiler will throw an error
            // or more specific InvalidCastException. To prevent that happening we can use 'as' keyword. Using 'as'
            // keyword, if object (here shape) is not converted to the target (here Text) type, it will instead return null.
            Text text1 = shape as Text;
             
            if (text1 != null)
            {
                Console.WriteLine("Shape object is successfully downcasted to Text object");
            }

            // Secondly we can check using 'is' keyword
            if (shape is Text)
            {
                Text text2 = (Text)shape;
            }
        }

        public static void BoxingAndUnboxing()
        {
            // Boxing: is the process of converting a value type instance to an object reference. Behind the scenes what happens is that, interger
            // variable "number" gets boxed by clr and stored in the heap instead of stack (as all primitive and struct types are stored in stack)
            // and a reference of "object" is stored in the stack wich will point to the value stored in the heap;
            int number = 10;
            object obj = number;
            object obj1 = 20;

            // Unboxing is the opposite of boxing
            object obj2 = 30;
            int number2 = (int)obj2;

            var list = new ArrayList();
            list.Add(12);               // boxing
            int a = (int)list[0];       // unboxing 
        }

        public static void Overriding()
        {
            var shapes = new List<Shape>();
            shapes.Add(new Circle());
            shapes.Add(new Rectangle());
            shapes.Add(new Triangle()); 

            // Press F9 to mark a breakpoint, F5 to run in a debug mode, F10 to continue execution, F11 to step into method (if currently the
            // execution is a method) 
            var canvas = new Canvas();
            canvas.DrawShapes(shapes);
        }

        public static void Interface_Extensibility()
        {
            var migrator = new Migrator(new ConsoleLogger());
            //migrator.Migrate();

            // Open Close Principle (OCP): states software entity should be open for extension but closed for modification.
            // Change in the behaviour by extending the application instead of changing the code. We didn't change any line of code
            // in the Migrator class to implement below part. Just created another class FileLogger which implements ILogger interface.
            // Migrator class is open for extension it has ILogger field which can catch any object which is a child of ILogger.
            var migrator1 = new Migrator(new FileLogger("D:\\log.txt"));
            migrator1.Migrate();
        }

        static void Main(string[] args)
        {
            Interface_Extensibility();
            Console.ReadLine();
        }
    }
}
