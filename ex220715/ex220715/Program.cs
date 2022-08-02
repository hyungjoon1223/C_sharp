using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex220715
{
    static class MyEnumerable
    {
        public static void Print<T>(this IEnumerable<T> ie)
        {
            foreach (var item in ie)
                Console.WriteLine("{0} ", item);
            Console.WriteLine("\n");
        }
    }
    struct Car
    {
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public Car(int id, string m, string c, string n)
        {
            CarID = id;
            Make = m;
            Color = c;
            Name = n;
        }
        public override string ToString()
        {
            return $"[CarID:{CarID}, Make:{Make}, Color:{Color}, Name:{Name}] ";
        }
    }
    struct Order
    {
        public int OrderID { get; set; }
        public int CarID { get; set; }
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }
        public Order(int oid, int cid, DateTime dt, int a)
        {
            OrderID = oid;
            CarID = cid;
            DateTime = dt;
            Amount = a;
        }
        public override string ToString()
        {
            return $"{OrderID} {CarID} {DateTime} {Amount}";
        }
    }
    struct SubCar
    {
        public Guid ID { get; set; }
        public int CarID { get; set; }
        public string Name { get; set; }
        public SubCar(int id, string n)
        {
            ID = Guid.NewGuid();
            CarID = id;
            Name = n;
        }
        public override string ToString()
        {
            return string.Format("{{{0}, {1}, {2}}} ", ID, CarID, Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Enumerable.Range(1, 50_000_000).ToArray();
            DateTime s1 = DateTime.Now;
            var sub1 = arr.Select((n) => n.ToString())
               .Select((s) => s.Length)
               .Where((n) => n % 2 == 0);
            Console.WriteLine(sub1.Count());
            DateTime e1 = DateTime.Now;

            DateTime s2 = DateTime.Now;
            var sub2 = arr.AsParallel().Select((n) => n.ToString())
               .Select((s) => s.Length)
               .Where((n) => n % 2 == 0);
            Console.WriteLine(sub2.Count());
            DateTime e2 = DateTime.Now;

            Console.WriteLine("sync count : {0}", e1 - s1);
            Console.WriteLine("parallel count : {0}", e2 - s2);

        }
    }
}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220715
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.WriteLine("{0} ", item);
//            Console.WriteLine("\n");
//        }
//    }
//    struct Car
//    {
//        public int CarID { get; set; }
//        public string Make { get; set; }
//        public string Color { get; set; }
//        public string Name { get; set; }
//        public Car(int id, string m, string c, string n)
//        {
//            CarID = id;
//            Make = m;
//            Color = c;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return $"[CarID:{CarID}, Make:{Make}, Color:{Color}, Name:{Name}] ";
//        }
//    }
//    struct Order
//    {
//        public int OrderID { get; set; }
//        public int CarID { get; set; }
//        public DateTime DateTime { get; set; }
//        public int Amount { get; set; }
//        public Order(int oid, int cid, DateTime dt, int a)
//        {
//            OrderID = oid;
//            CarID = cid;
//            DateTime = dt;
//            Amount = a;
//        }
//        public override string ToString()
//        {
//            return $"{OrderID} {CarID} {DateTime} {Amount}";
//        }
//    }
//    struct SubCar
//    {
//        public Guid ID { get; set; }
//        public int CarID { get; set; }
//        public string Name { get; set; }
//        public SubCar(int id, string n)
//        {
//            ID = Guid.NewGuid();
//            CarID = id;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return string.Format("{{{0}, {1}, {2}}} ", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = Enumerable.Range(1, 50_000_000).ToArray();
//            DateTime s1 = DateTime.Now;
//            var sub1 = arr.Select((n) => n.ToString())
//               .Select((s) => s.Length)
//               .Where((n) => n % 2 == 0);
//            Console.WriteLine(sub1.Count());
//            DateTime e1 = DateTime.Now;

//            DateTime s2 = DateTime.Now;
//            var sub2 = arr.AsParallel().Select((n) => n.ToString())
//               .Select((s) => s.Length)
//               .Where((n) => n % 2 == 0);
//            Console.WriteLine(sub2.Count());
//            DateTime e2 = DateTime.Now;

//            Console.WriteLine("sync count : {0}", e1 - s1);
//            Console.WriteLine("parallel count : {0}", e2 - s2);

//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220715
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.WriteLine("{0} ", item);
//            Console.WriteLine("\n");
//        }
//    }
//    struct Car
//    {
//        public int CarID { get; set; }
//        public string Make { get; set; }
//        public string Color { get; set; }
//        public string Name { get; set; }
//        public Car(int id, string m, string c, string n)
//        {
//            CarID = id;
//            Make = m;
//            Color = c;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return $"[CarID:{CarID}, Make:{Make}, Color:{Color}, Name:{Name}] ";
//        }
//    }
//    struct Order
//    {
//        public int OrderID { get; set; }
//        public int CarID { get; set; }
//        public DateTime DateTime { get; set; }
//        public int Amount { get; set; }
//        public Order(int oid, int cid, DateTime dt, int a)
//        {
//            OrderID = oid;
//            CarID = cid;
//            DateTime = dt;
//            Amount = a;
//        }
//        public override string ToString()
//        {
//            return $"{OrderID} {CarID} {DateTime} {Amount}";
//        }
//    }
//    struct SubCar
//    {
//        public Guid ID { get; set; }
//        public int CarID { get; set; }
//        public string Name { get; set; }
//        public SubCar(int id, string n)
//        {
//            ID = Guid.NewGuid();
//            CarID = id;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return string.Format("{{{0}, {1}, {2}}} ", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = Enumerable.Range(1, 50_000_000).ToArray();
//            DateTime s1 = DateTime.Now;
//            var sub1 = arr.Select((n) => n.ToString())
//               .Select((s) => s.Length)
//               .Where((n) => n % 2 == 0);
//            Console.WriteLine(sub1.Count());
//            DateTime e1 = DateTime.Now;

//            DateTime s2 = DateTime.Now;
//            var sub2 = arr.AsParallel().Select((n) => n.ToString())
//               .Select((s) => s.Length)
//               .Where((n) => n % 2 == 0);
//            Console.WriteLine(sub2.Count());
//            DateTime e2 = DateTime.Now;

//            Console.WriteLine("sync count : {0}", e1 - s1);
//            Console.WriteLine("parallel count : {0}", e2 - s2);

//        }
//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220715
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.WriteLine("{0} ", item);
//            Console.WriteLine("\n");
//        }
//    }
//    struct Car
//    {
//        public int CarID { get; set; }
//        public string Make { get; set; }
//        public string Color { get; set; }
//        public string Name { get; set; }
//        public Car(int id, string m, string c, string n)
//        {
//            CarID = id;
//            Make = m;
//            Color = c;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return $"[CarID:{CarID}, Make:{Make}, Color:{Color}, Name:{Name}] ";
//        }
//    }
//    struct Order
//    {
//        public int OrderID { get; set; }
//        public int CarID { get; set; }
//        public DateTime DateTime { get; set; }
//        public int Amount { get; set; }
//        public Order(int oid, int cid, DateTime dt, int a)
//        {
//            OrderID = oid;
//            CarID = cid;
//            DateTime = dt;
//            Amount = a;
//        }
//        public override string ToString()
//        {
//            return $"{OrderID} {CarID} {DateTime} {Amount}";
//        }
//    }
//    struct SubCar
//    {
//        public Guid ID { get; set; }
//        public int CarID { get; set; }
//        public string Name { get; set; }
//        public SubCar(int id, string n)
//        {
//            ID = Guid.NewGuid();
//            CarID = id;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return string.Format("{{{0}, {1}, {2}}} ", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {//비어있는 컬렉션을 만들고자 할 때
//            var cars = Enumerable.Empty<Car>(); 
//            const WriteLine({0} = {1}, cars.GetType(), cars.Count());

//        }

//    }
//}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220715
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.WriteLine("{0} ", item);
//            Console.WriteLine("\n");
//        }
//    }
//    struct Car
//    {
//        public int CarID { get; set; }
//        public string Make { get; set; }
//        public string Color { get; set; }
//        public string Name { get; set; }
//        public Car(int id, string m, string c, string n)
//        {
//            CarID = id;
//            Make = m;
//            Color = c;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return $"[CarID:{CarID}, Make:{Make}, Color:{Color}, Name:{Name}] ";
//        }
//    }
//    struct Order
//    {
//        public int OrderID { get; set; }
//        public int CarID { get; set; }
//        public DateTime DateTime { get; set; }
//        public int Amount { get; set; }
//        public Order(int oid, int cid, DateTime dt, int a)
//        {
//            OrderID = oid;
//            CarID = cid;
//            DateTime = dt;
//            Amount = a;
//        }
//        public override string ToString()
//        {
//            return $"{OrderID} {CarID} {DateTime} {Amount}";
//        }
//    }
//    struct SubCar
//    {
//        public Guid ID { get; set; }
//        public int CarID { get; set; }
//        public string Name { get; set; }
//        public SubCar(int id, string n)
//        {
//            ID = Guid.NewGuid();
//            CarID = id;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return string.Format("{{{0}, {1}, {2}}} ", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {//내가 원하는 원소만 잡고싶을 때
//            object[] oarr = { 10, 20, "hello!", new Car(101, "현대","Black", "팰리쉐이드"),32 };
//            ArrayList ar = new ArrayList() { 10, 20, "hello!", new Car(101, "현대", "Black", "팰리쉐이드"), 32 };
//            var subInt = oarr.OfType<int>();
//            foreach(var n in subInt)
//                Console.Write("{0} ", n);
//            Console.WriteLine();

//            var subInt2 = ar.OfType<int>();
//            subInt2.Print();

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220715
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.WriteLine("{0} ", item);
//            Console.WriteLine("\n");
//        }
//    }
//    struct Car
//    {
//        public int CarID { get; set; }
//        public string Make { get; set; }
//        public string Color { get; set; }
//        public string Name { get; set; }
//        public Car(int id, string m, string c, string n)
//        {
//            CarID = id;
//            Make = m;
//            Color = c;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return $"[CarID:{CarID}, Make:{Make}, Color:{Color}, Name:{Name}] ";
//        }
//    }
//    struct Order
//    {
//        public int OrderID { get; set; }
//        public int CarID { get; set; }
//        public DateTime DateTime { get; set; }
//        public int Amount { get; set; }
//        public Order(int oid, int cid, DateTime dt, int a)
//        {
//            OrderID = oid;
//            CarID = cid;
//            DateTime = dt;
//            Amount = a;
//        }
//        public override string ToString()
//        {
//            return $"{OrderID} {CarID} {DateTime} {Amount}";
//        }
//    }
//    struct SubCar
//    {
//        public Guid ID { get; set; }
//        public int CarID { get; set; }
//        public string Name { get; set; }
//        public SubCar(int id, string n)
//        {
//            ID = Guid.NewGuid();
//            CarID = id;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return string.Format("{{{0}, {1}, {2}}} ", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr1 = { 1, 1024, 5, 51, 39, 6000, 82, 102, 75, 80, 100 };
//            Car[] cars =
//            {
//                new Car(101,"현대","Red","아반테"),
//                new Car(102,"기아","Red","K7"),
//                new Car(103,"쌍용","Blue","코란도"),
//                new Car(104,"대우","Green","윈스톰"),
//                new Car(105,"BMW","Yellow","e250"),
//                new Car(106,"현대","Pink","그랜져"),
//                new Car(107,"기아","Black","아이오닉"),
//                new Car(108,"대우","White","오피러스")
//            };
//            var subGroup = cars.GroupBy((car) => car.Make, (key, group) => new { key, group });
//            foreach(var g in subGroup)
//            {
//                Console.WriteLine("Group : {0}", g.key);
//                foreach(var car in g.group)
//                    Console.Write("{0} ", car);
//                Console.WriteLine();
//            }    
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220715
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.WriteLine("{0} ", item);
//            Console.WriteLine("\n");
//        }
//    }
//    struct Car
//    {
//        public int CarID { get; set; }
//        public string Make { get; set; }
//        public string Color { get; set; }
//        public string Name { get; set; }
//        public Car(int id, string m, string c, string n)
//        {
//            CarID = id;
//            Make = m;
//            Color = c;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return $"[CarID:{CarID}, Make:{Make}, Color:{Color}, Name:{Name}] ";
//        }
//    }
//    struct Order
//    {
//        public int OrderID { get; set; }
//        public int CarID { get; set; }
//        public DateTime DateTime { get; set; }
//        public int Amount { get; set; }
//        public Order(int oid, int cid, DateTime dt, int a)
//        {
//            OrderID = oid;
//            CarID = cid;
//            DateTime = dt;
//            Amount = a;
//        }
//        public override string ToString()
//        {
//            return $"{OrderID} {CarID} {DateTime} {Amount}";
//        }
//    }
//    struct SubCar
//    {
//        public Guid ID { get; set; }
//        public int CarID { get; set; }
//        public string Name { get; set; }
//        public SubCar(int id, string n)
//        {
//            ID = Guid.NewGuid();
//            CarID = id;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return string.Format("{{{0}, {1}, {2}}} ", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr1 = { 1, 1024, 5, 51, 39, 6000, 82, 102, 75, 80, 100 };
//            Car[] cars =
//            {
//                new Car(101,"현대","Red","아반테"),
//                new Car(102,"기아","Red","K7"),
//                new Car(103,"쌍용","Blue","코란도"),
//                new Car(104,"대우","Green","윈스톰"),
//                new Car(105,"BMW","Yellow","e250")
//            };
//            var subGroup = arr1.GroupBy((n) => n % 10, (key, group) =>
//            {
//                return new { Key = key, Group = group };
//            }).OrderBy((g) => g.Key);
//            foreach (var g in subGroup)
//            {
//                Console.WriteLine("group key : {0}", g.Key);
//                foreach (var item in g.Group)
//                    Console.WriteLine("{0} ", item);
//                Console.WriteLine();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220715
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.WriteLine("{0} ", item);
//            Console.WriteLine("\n");
//        }
//    }
//    struct Car
//    {
//        public int CarID { get; set; }
//        public string Make { get; set; }
//        public string Color { get; set; }
//        public string Name { get; set; }
//        public Car(int id, string m, string c, string n)
//        {
//            CarID = id;
//            Make = m;
//            Color = c;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return $"[CarID:{CarID}, Make:{Make}, Color:{Color}, Name:{Name}] ";
//        }
//    }
//    struct Order
//    {
//        public int OrderID { get; set; }
//        public int CarID { get; set; }
//        public DateTime DateTime { get; set; }
//        public int Amount { get; set; }
//        public Order(int oid, int cid, DateTime dt, int a)
//        {
//            OrderID = oid;
//            CarID = cid;
//            DateTime = dt;
//            Amount = a;
//        }
//        public override string ToString()
//        {
//            return $"{OrderID} {CarID} {DateTime} {Amount}";
//        }
//    }
//    struct SubCar
//    {
//        public Guid ID { get; set; }
//        public int CarID { get; set; }
//        public string Name { get; set; }
//        public SubCar(int id, string n)
//        {
//            ID = Guid.NewGuid();
//            CarID = id;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return string.Format("{{{0}, {1}, {2}}} ", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr1 = { 1, 1024, 5, 51, 39, 6000, 82, 102, 75, 80, 100 };
//            Car[] cars =
//            {
//                new Car(101,"현대","Red","아반테"),
//                new Car(102,"기아","Red","K7"),
//                new Car(103,"쌍용","Blue","코란도"),
//                new Car(104,"대우","Green","윈스톰"),
//                new Car(105,"BMW","Yellow","e250")
//            };
//            var subGroup = arr1.GroupBy((n) => n % 10, (key, group) =>
//            {
//                return new { Key = key, Group = group };
//            });
//            foreach (var g in subGroup)
//            {
//                Console.WriteLine("group key : {0}", g.Key);
//                foreach( var item in g.Group)
//                    Console.WriteLine("{0} ", item);
//                Console.WriteLine();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220715
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.WriteLine("{0} ", item);
//            Console.WriteLine("\n");
//        }
//    }
//    struct Car
//    {
//        public int CarID { get; set; }
//        public string Make { get; set; }
//        public string Color { get; set; }
//        public string Name { get; set; }
//        public Car(int id, string m, string c, string n)
//        {
//            CarID = id;
//            Make = m;
//            Color = c;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return $"[CarID:{CarID}, Make:{Make}, Color:{Color}, Name:{Name}] ";
//        }
//    }
//    struct Order
//    {
//        public int OrderID { get; set; }
//        public int CarID { get; set; }
//        public DateTime DateTime { get; set; }
//        public int Amount { get; set; }
//        public Order(int oid, int cid, DateTime dt, int a)
//        {
//            OrderID = oid;
//            CarID = cid;
//            DateTime = dt;
//            Amount = a;
//        }
//        public override string ToString()
//        {
//            return $"{OrderID} {CarID} {DateTime} {Amount}";
//        }
//    }
//    struct SubCar
//    {
//        public Guid ID { get; set; }
//        public int CarID { get; set; }
//        public string Name { get; set; }
//        public SubCar(int id, string n)
//        {
//            ID = Guid.NewGuid();
//            CarID = id;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return string.Format("{{{0}, {1}, {2}}} ", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr1 = { 1, 1024, 5, 51, 39, 6000, 82, 102, 75, 80, 100 };
//            Car[] cars =
//            {
//                new Car(101,"현대","Red","아반테"),
//                new Car(102,"기아","Red","K7"),
//                new Car(103,"쌍용","Blue","코란도"),
//                new Car(104,"대우","Green","윈스톰"),
//                new Car(105,"BMW","Yellow","e250")
//            };
//            var subGroup = arr1.GroupBy((n) => n % 10, (key, group) =>
//            {
//                return new { Key = key, Group = group };
//            });
//            foreach(var g in subGroup)
//                Console.WriteLine("{0} : {1}", g.Key, g.Group);
//        }
//    }
//}
