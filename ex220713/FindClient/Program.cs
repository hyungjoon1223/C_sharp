using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindLibrary;

namespace FindClient
{
    struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public Person(string n, int a, string p)
        {
            Name = n;
            Age = a;
            Phone = p;
        }
        public override string ToString()
        {
            return $"Name:{Name},Age:{Age},Phone:{Phone}";
        }
    }

    class Program
    {

        static bool cmp(Person key)
        {
            return key.Name == "장길산";
        }


        static void Main(string[] args)
        {
            Person[] parr = { new Person("홍길동", 20, "010-1234-1234"),
                                new Person("임꺽정", 25, "010-2222-5678"),
                                 new Person("장길산", 30, "010-5522-9988")};

            int idx = Algorithm.Find(parr, cmp); //FindLibrary.
            if (idx != -1)
                Console.WriteLine("{0} : {1}", idx, parr[idx]);

        }
    }
}
