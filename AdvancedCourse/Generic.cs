using System.Collections.Generic;
using System;

// where T: interface (example IComparable), Product, struct, class, new()
namespace AdvancedCourse
{
    public class GenericList<T>
    {
        private List<T> list = new List<T>();

        public GenericList()
        {

        }

        public void Add(T value)
        {
            list.Add(value);
        }

        public T this[int index]
        {
            get { return list[index]; }
        }
    }

    // Generic class
    public class GenericDictionary<TKey, TValue>
    {
        Dictionary<TKey,TValue> dict = new Dictionary<TKey,TValue>();
        public GenericDictionary()
        {

        }

        public void Add(TKey key, TValue value)
        {
            dict[key] = value;
        }

        public TValue this[TKey key]
        {
            set { dict[key] = value; }
            get { return dict[key]; }
        }
    }

    public class MathOperations
    {
        // Created a generic method but not generic class and this is perfectly fine.
        public T Max<T>(T a, T b) where T : IComparable
        {
            // Compare() is a method of IComparer interface.
            return a.CompareTo(b) > 0 ? a : b;
        }

        // https://stackoverflow.com/questions/8122611/c-sharp-adding-two-generic-values
        public T Add<T>(T a, T b) where T: struct
        {
            // The dynamic keyword is used to declare dynamic types. The dynamic types tell the compiler that the object is
            // defined as dynamic and skip type-checking at compiler time; delay type-checking until runtime.
            return (dynamic)a + b;
        }
    }

    public class Utilities<T> where T: IComparable, new()
    {
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void Instantiate()
        {
            try
            {
                var obj = new T();
                Console.WriteLine("Instantiation is successful");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    // ************************************************* T is Product ****************************************************

    public class Product
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class DisCal<TProduct> where TProduct: Product
    {
        public float Cal(TProduct product)
        {
            return product.Price;
        }
    }

    // ***************************************** T is struct (value type) ***********************************************
    public class Nullable<T> where T: struct
    {
        private readonly object value;

        public Nullable()
        {
           
            
        }
        public Nullable(T value)
        {
            this.value = value;
        }

        public bool HasValue { get { return value != null; } }

        public T GetValueOrDefault()
        {
            if (HasValue) { return (T)value; }
            
            // default(T) will find the default value of type T.
            return default(T);
        }
    }
}
