using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdvancedCourse
{
    public class Vector
    {
        public void Add(int value)
        {

        }

        public int this[int index]
        {
            get { return index; }
        }
    }

    internal class Program
    {
        private static void GenericsClass()
        {
            GenericDictionary<string, int> dictionary = new GenericDictionary<string, int>();
            dictionary.Add("abc", 12);
            dictionary["cde"] = 21;
            Console.WriteLine("Value of keys 'abc' and 'cde': {0} {1}", dictionary["abc"], dictionary["cde"]);
        }

        public static void GenericsMethod()
        {
            MathOperations mathOperations = new MathOperations();
            Console.WriteLine($"Addition of {12} and {8}: {mathOperations.Add<int>(2, 3)}");
            Console.WriteLine("Bigger: " + mathOperations.Max(222.897, 222.343));

            var number = new Nullable<int>(5);
            Console.WriteLine("Has value? " + number.HasValue);
            Console.WriteLine("Value: {0}", number.GetValueOrDefault());

            Utilities<int> utilities = new Utilities<int>();
            Console.WriteLine("Bigger: " + utilities.Max(23, 45));
            utilities.Instantiate();
        }

        public static void Delegate()
        {
            // Same we can achieve using Interface also instead of Delegate

            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();

            // Base class of delegate is MultiCastDelegate. Delegate allows to have single function pointer where as MultiCastDelegate
            // allows to have multiple functions pointer.
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;

            processor.ProcessDelegate("photo.jpg", filterHandler);

            // Using inbuilt delegates
            Action<Photo> filterHandler1 = filters.ApplyBrightness;
            filterHandler1 += filters.ApplyContrast;

            processor.ProcessBuiltDelegate("photo.jpg", filterHandler1);

        }

        public static void Lambda()
        {
            // Lambda is nothing but an anonymous method. Anonymous method is a method that has no access modifier, no name
            // and no return type. Syntax: args => expression. Just assign Lambda to a delegate.

            // Func<Type of argument1, Type of argument2, ......, Type of return>
            Func<int, int> func = number => number * number;
            Func<int, double, double> func1 = (val1, val2) => val1 * val2;
            Console.WriteLine(func(12));
            Console.WriteLine(func1(2, 2.51));

            // Predicate<> is a delegate which points to a function and returns a boolean value specifying a given condition
            // was satisfied.
            var books = new List<Book>
            {
                new Book { Id = 1},
                new Book { Id = 2},
                new Book { Id = 3},
                new Book { Id = 4}
            };

            // FindAll() accepts a Predicate<>
            var result = books.FindAll(book => book.Id <= 2);

            foreach (var book in result)
            {
                Console.WriteLine("Filtered books: {0}", book.Id);
            }
        }

        private static void ExtensionMethod()
        {
            string post = "This is supposed to be very very long blog post";

            // Even though we are applying ShortenTheString() extension method on an instance "post", it is a static method.
            // If we follow the convention: static class -> static method -> first argument of static method is
            // "this type_of_argument variable_name", then compiler will allow us to use the static method on an
            // instance. For extension method, we follow the above convention.
            Console.WriteLine("Shorten post: " + post.ShortenTheString(5));

            IEnumerable<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var max = numbers.Max();
            Console.WriteLine("Max using extension method Max(): {0}", max);
        }

        private static void LINQ()
        {
            var copies = new CopyRepo().GetCopies();

            // We can chain Linq extension methods. Select() will convert the output into List of passed field. Here Select()
            // will convert the list of copies into list of string (Title) as Title is string.
            var cheapCopies = copies.Where(copy => copy.Price > 5)
                .OrderBy(copy => copy.Price)
                .Select(copy => copy.Title);

            // Writing the same above code using LINQ Query Operator. LINQ Query Operator always starts with the 'from'
            // ans ends with the 'select';
            var cheapCopies1 = from copy in copies
                               where copy.Price < 5
                               orderby copy.Price
                               select copy.Title;

            // Single() throws an error if no matching is found or more than one match is found.
            //Console.WriteLine(copies.Single(copy => copy.Title == "Gunjan"));

            // Default value (null) will be passed if nothing matches. Throws an error if more than one match is found.
            Console.WriteLine(copies.SingleOrDefault(copy => copy.Title == "Gunjan1") == null);
            Console.WriteLine(copies.First(copy => copy.Title == "Gunjan").Price);
            Console.WriteLine(copies.FirstOrDefault(copy => copy.Title == "Gunjan").Price);
            Console.WriteLine(copies.LastOrDefault(copy => copy.Title == "Gunjan").Price);

            // Skip 2 objects and get next 3. Skip() and Take() are used for pagination.
            Console.WriteLine(copies.Skip(2).Take(2));

            // Max() will find the max of the field which is retured in the Lambda
            Console.WriteLine(copies.Max(copy => copy.Price));

            // Similary we have Count(), Sum(), Min()
        }

        public static void NullableType()
        {
            // Value types cannot be null so we needed Nullable type. DateTime is value type and hence cannot be null.
            //DateTime dateTime = null;     // Error
            Nullable<DateTime> dateTime = null;

            // We can also define Nullable type using question mark (shortcut). Both above and below are same.
            DateTime? dateTime1 = null;

            // All these prperties and methods are of Nullable type.
            Console.WriteLine(dateTime1.HasValue);
            Console.WriteLine(dateTime1.GetValueOrDefault());
            Console.WriteLine(dateTime1.Value);

            DateTime dateTime2 = dateTime1.GetValueOrDefault();

            // ?? is Null Coalescing Operator. It can only be applied to Nullable Types and not value types.
            DateTime dateTime3 = dateTime1 ?? DateTime.Today;
        }

        public static void DynamicType()
        {
            // .Net 4 added the dynamic capability to improve interoperability with
            // -> COM (eg writing office applications)          -> Dynamic Languages (IronPython)

            // .Net framework take your compiled code which is in Intermediate Language (IL), then converts or compiles
            //  that into machine code at runtime. In .Net framework version 4, they added new component called Dynamic
            // Language Runtime (DLR). DLR sits over CLR and gives dynamic language capability.

            dynamic name = "Gunjan";
            name = 10;      // Dynamically typed (similar to Javascript or python)

            // Most of cases, no need to type cast from and to objects. From converting dynamic to static type, if the rumtime
            // of the dynamic object is implicitly convertable to target type, we don't need to type cast it explicitly.
            int i = 5;
            dynamic d = i;
            long l = d;     // At runtime d will be dynamic and we can easily put int in long without explicit type casting.

        }

        public static void ExceptionHandling()
        {
            // We need 'finally' block because to run codes irrespective of error thrown. In .Net, there are classes that
            // access on manage resources. Manage resources are the resources that are not managed by CLR so there is no
            // garabage collection applied to them. Examples are File handling, Database connections, network connections etc.
            // In this sitatuin, we have to manually do the cleaning work.

            // StreamReader is used to read any streams of data (files, network, etc).
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"c:\file.zip");
                var content = streamReader.ReadToEnd();

            } catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            } finally
            {
                // Any class that access on manage resources is expected to implement an interface called IDisposable.

                if (streamReader != null)
                streamReader.Dispose();
            }

            // We can write the above code using "using keyword" which is more clean. We can avoid the finally block.
            try
            {
                // Under the hood, compiler will create the finally block which will call Dispose() method of
                // StreamReader.
                using (var streamReader1 = new StreamReader(@"c:\file.zip"))
                {
                    var content = streamReader1.ReadToEnd();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
                throw new YoutubeException("It's user defined exception class", ex);
            }
        }

        public static void EventsAndDelegates()
        {
            var video = new Video() { Title = "Prince of Persia: The Warrior Within" };
            var videoEncoder = new VideoEncoder();      // publisher
            var mailService = new MailService();        // subscriber

            // When created this new MessageService subscriber, we din't make any change in the VideoEncoder.
            // We can add any number of subscribers to a publisher without changing anyline of code in the publisher.
            var messageService = new MessageService();        // subscriber

            // Doing subscription
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);
        }

        static void Main(string[] args)
        {
            EventsAndDelegates();
            Console.ReadLine();
        }
    }
}
