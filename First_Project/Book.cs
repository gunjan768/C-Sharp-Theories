using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    internal class Book
    {
        private string title;
        private string description;
        private int pages = 88;
        private static int count = 0;
        public static int count1 = 56;
        private static int total = 100;

        // type ctor for constructor and press Tab twice
        public Book()
        {
            ++count;
            ++total;
        }

        public Book(string title, string description) : this()
        {
            this.title = title;
            this.description = description;
        }

        public Book(string title, string description, int pages): this(title, description)
        {
            this.pages = pages;
        }

        public string Title { 
            get
            {
                return title;
            } 
            set
            {
                if(value == "Gunjan")
                {
                    title = value;
                } else
                {
                    title = "Anonymous";
                }
            }
        }
        public string Description { get; set; }
        public static int Count { get { return count; } set { count = value; } }
        public int Total { get { return total; } set { total = value; } }
        public static int TotalGS { get { return total; } set { total = value; } }
        public int Pages { get { return pages; } set { pages = value; } }

        public int getTotal()
        {
            return total;
        }

        public static int getTotalUsingStaticMethod()
        {
            return total;
        }
    }
}
