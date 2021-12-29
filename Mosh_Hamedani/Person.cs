using System;
using System.Collections.Generic;

// There are Five types of Access Modifiers: public, protected, private, internal, protected internal.
// Go to current_directory -> bin -> Debug -> then type "ildasm Mosh_Hamedani.exe".... ildasm stands for Intermediate Language Disambler.


namespace Mosh_Hamedani
{
    // A property is a class member that encapsulates a getter/setter for accessing a field. We need a property to create a getter/setter with less
    // code.
    public class Person
    {
        // Type "prop" (shortcut) to generate a Property.
        private DateTime birthDate;
        private string name = "Gunjan";
        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - BirthDate;
                var years = timeSpan.Days / 365;
                
                return years;
            }
            // By making "set" private, we can change the value of the "Age" property. We can set the value of the property (not Field) "Age" once
            // in the constructor if we want.
            private set
            {
            }
        }

        // Getter and Setter with more line of codes. This looks tediouis
        public void SetBirthDate(DateTime birthDate)
        {
            this.birthDate = birthDate;
        }

        public DateTime GetBirthDate()
        {
            return this.birthDate;
        }

        // Getter and Setter with lesser line of code.
        public DateTime BirthDate { set { birthDate = value; } get { return this.birthDate; } }

        // We can even combine Field declaration and Getter and Setter into one using Auto-Implemented properties. C# complier will create a private
        // field with name of the field "Name".
        public string Name { get; set; }
 
        private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        // Indexers are a way to acess elements in a class that represents a list of values. Example: a[0] where 'a' is an array. More examples are:
        // a) cookie["name"] = "Gunjan". If not used indexer, we had to write cookie.SetItem("name", "Gunjan");
        // b) var name = cookie["name"]. If not used indexer, we had to write cookie.GetItem("name");

        // How to declare indexer? It is a Property, so we can declare it in the same only but instead of name of the Property, we write 'this'
        // keyword and after that indexer notation ([]).

        // By creating this indexer, we don't need to create SetItem() and GetItem() method to set the item of the dictionary and to get the item
        // from the dictionary respectively. So any class having collection or dictionary, we can improve our code by declaring indexer.
        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }
    }
}
