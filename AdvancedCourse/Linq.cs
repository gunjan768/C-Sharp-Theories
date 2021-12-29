// Linq stands for Language(L) Integrated(In) Query(Q). It gives the ability to query objects.
using System.Collections;
using System.Collections.Generic;

namespace AdvancedCourse
{
    public class Copy
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class CopyRepo
    {
       public IEnumerable<Copy> GetCopies()
       {
            return new List<Copy>
            {
                new Copy() {Title = "Gunjan", Price = 5},
                new Copy() {Title = "Gunjan", Price = 15},
                new Copy() {Title = "Shiwani", Price = 65},
                new Copy() {Title = "Prabhat", Price = 8},
                new Copy() {Title = "Nani", Price = 54},
                new Copy() {Title = "Nana", Price = 896},
                new Copy() {Title = "Mama", Price = 1463},
            };
       }
    }
}
