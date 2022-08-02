using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex220714
{
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
            return $"CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}";
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
            return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
        }
    }
    static class MyEnumerable
    {
        public static void Print<T>(this IEnumerable<T> ie)
        {
            foreach (var t in ie)
            {
                Console.Write(" {0} ", t);
            }
            Console.WriteLine();
        }
        public static U Aggregate<T, U>(this IEnumerable<T> sorce, U acc, Func<U, T, U> f)
        {
            U val = acc;
            foreach (var t in sorce)
            {
                val = f(val, t);
            }
            return val;
        }
    }
    class Program
    {
        static void PrintEunmerable<T>(IEnumerable<T> ie)
        {
            foreach (T t in ie)
            {
                Console.Write(" {0} ", t);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] arr = { 51, 39, 82, 75, 49, 66, 12, 25, 100 };
            Car[] cars =
                {
                    new Car(101,"현대","Red","아반테"),
                    new Car(102,"기아","Red","K7"),
                    new Car(103,"쌍용","Blue","코란도"),
                    new Car(104,"대우","Green","윈스톰"),
                    new Car(105,"BMW","Yellow","e250"),
                };

            var sum = cars.Aggregate("", (acc, car) => acc + car.CarID + " " + car.Name + " ");
            Console.WriteLine("sum : {0}", sum.Substring(0)); 

        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//        struct SubCar
//        {
//            public Guid ID { get; set; }
//            public int CarID { get; set; }
//            public string Name { get; set; }
//            public SubCar(int id, string n)
//            {
//                ID = Guid.NewGuid();
//                CarID = id;
//                Name = n;
//            }
//            public override string ToString()
//            {
//                return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
//            }
//        }
//        class Program
//        {
//            static void Main(string[] args)
//            {
//                int[] arr1 = { 51, 39, 82, 75, 49, 66, 12, 75, 25, 100 };
//                Car[] cars =
//                    {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//                Console.WriteLine(arr1.First());  //싱글과의 차이점이 있음
//                Console.WriteLine(arr1.Single((n)=>n == 12));
//                Console.WriteLine(arr1.SingleOrDefault((n)=>n == 77));
//            }
//        }
//    }
//}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//        struct SubCar
//        {
//            public Guid ID { get; set; }
//            public int CarID { get; set; }
//            public string Name { get; set; }
//            public SubCar(int id, string n)
//            {
//                ID = Guid.NewGuid();
//                CarID = id;
//                Name = n;
//            }
//            public override string ToString()
//            {
//                return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
//            }
//        }
//        class Program
//        {
//            static void Main(string[] args)
//            {
//                int[] arr1 = { 51, 39, 82, 75, 49, 66, 12, 25, 100 };
//                int[] arr2 = { 51, 39, 82, 100, 200, 66, 12, 300, 100 };
//                Car[] cars =
//                    {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//                Order[] orders =
//                {
//                    new Order(1, 102, DateTime.Now, 1),
//                    new Order(2, 102, DateTime.Now, 2),
//                    //new Order(3, 104, DateTime.Now, 1),
//                    new Order(4, 105, DateTime.Now, 3)
//                };
//                var subJoin = cars.Join(orders, (c) => c.CarID, (o) => o.CarID, (car, order) =>
//                {
//                    return new { order.OrderID, order.CarID, order.DateTime, order.Amount, car.Make, car.Color, car.Name };
//                });
//                subJoin.Print();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//        struct SubCar
//        {
//            public Guid ID { get; set; }
//            public int CarID { get; set; }
//            public string Name { get; set; }
//            public SubCar(int id, string n)
//            {
//                ID = Guid.NewGuid();
//                CarID = id;
//                Name = n;
//            }
//            public override string ToString()
//            {
//                return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
//            }
//        }
//        class Program
//        {
//            static void Main(string[] args)
//            {
//                int[] arr1 = { 51, 39, 82, 75, 49, 66, 12, 25, 100 };
//                int[] arr2 = { 51, 39, 82, 100, 200, 66, 12, 300, 100 };
//                Car[] cars =
//                    {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//                Order[] orders =
//                {
//                    new Order(1, 102, DateTime.Now, 1),
//                    new Order(2, 102, DateTime.Now, 2),
//                    //new Order(3, 104, DateTime.Now, 1),
//                    new Order(4, 105, DateTime.Now, 3)
//                };
//                var subJoin = cars.Join(orders, (c) => c.CarID, (o) => o.CarID, (car, order) =>
//                {
//                    return new { order.OrderID, order.CarID, order.DateTime, order.Amount, car.Make, car.Color, car.Name };
//                });
//                subJoin.Print();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//        struct SubCar
//        {
//            public Guid ID { get; set; }
//            public int CarID { get; set; }
//            public string Name { get; set; }
//            public SubCar(int id, string n)
//            {
//                ID = Guid.NewGuid();
//                CarID = id;
//                Name = n;
//            }
//            public override string ToString()
//            {
//                return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
//            }
//        }
//        class Program
//        {
//            static void Main(string[] args)
//            {
//                int[] arr1 = { 51, 39, 82, 75, 49, 66, 12, 25, 100 };
//                int[] arr2 = { 51, 39, 82, 100, 200, 66, 12, 300, 100 };
//                Car[] cars =
//                    {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//                Order[] orders =
//                {
//                    new Order(1, 102, DateTime.Now, 1),
//                    new Order(2, 102, DateTime.Now, 2),
//                    new Order(3, 104, DateTime.Now, 1),
//                    new Order(4, 105, DateTime.Now, 3)
//                };
//                var subJoin = cars.Join(orders, (c) => c.CarID, (o) => o.CarID, (car, order) =>
//                {
//                    return new { order.OrderID, car.CarID, car.Name, order.DateTime };
//                });
//                subJoin.Print();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//            return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr1 = { 51, 39, 82, 75, 49, 66, 12, 25, 100 };
//            int[] arr2 = { 51, 39, 82, 100, 200, 66, 12, 300, 100 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            //var set = arr1.Union(arr2);       //합집합
//            //var set = arr1.Intersect(arr2);   //교집합
//            //var set = arr1.Except(arr2);     //차집합
//            var set = arr1.Concat(arr2);     //붙이는 연산
//            set.Print();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//            return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr1 = { 51, 39, 82, 75, 49, 66, 12, 25, 100 };
//            int[] arr2 = { 51, 39, 82, 100, 200, 66, 12, 300, 100 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            //var set = arr1.Union(arr2);       //합집합
//            //var set = arr1.Intersect(arr2);   //교집합
//            var set = arr1.Except(arr2);     //차집합
//            set.Print();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//            return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 12, 25, 100 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            //var sum = arr.Aggregate("", (acc, item) => acc + item+" ");
//            //Console.WriteLine("sum: {0}", sum);
//            var sum = cars.Aggregate("", (str, car) => str + car.CarID+" "+car.Name +", ");
//            Console.WriteLine("sum: {0}", sum);

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//            return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 12, 25, 100 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            //var sum = arr.Aggregate("", (acc, item) => acc + item+" ");
//            //Console.WriteLine("sum: {0}", sum);
//            var sum = arr.Aggregate("", (acc, item) => acc +", "+ item);
//            Console.WriteLine("sum: {0}", sum.Substring(1));

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//            return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 12, 25, 100 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            var sum = arr.Aggregate(0, (acc, item) => acc + item);
//            Console.WriteLine("sum: {0}", sum);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//            return string.Format("{{{0},{1}, {2}}}", ID, CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 10, 25 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            var subArray = arr.Where((n) => n % 2 == 0).OrderBy((n) => n).Select((n) => "int:" + n);
//            var subCars = cars.Where((car) => car.Color == "Red").Select((car) => new SubCar(car.CarID, car.Name)).OrderBy((sc) => sc.ID);

//            subArray.Print();
//            subCars.Print();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
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
//            return string.Format("{{{0},{1}, {2}}}", ID,CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 10, 25 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            var subArray = arr.Where((n) => n % 2 == 0).OrderBy((n) => n).Select((n) => "int:" + n);
//            var subCars = cars.Where((car) => car.Color == "Red").Select((car) => new SubCar(car.CarID, car.Name)).OrderBy((sc) => sc.ID);

//            subArray.Print();
//            subCars.Print();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
//        }
//    }
//    struct SubCar
//    {
//        public int CarID { get; set; }
//        public string Name { get; set; }
//        public SubCar(int id, string n)
//        {
//            CarID = id;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return string.Format("{{{0},{1}}}", CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 10, 25 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            var subArray = arr.Where((n) => n % 2 == 0).OrderBy((n)=>n).Select((n) => "int:" + n);
//            var subCars = cars.Where((car) => car.Color == "Red").OrderBy((car)=>car.Name).Select((car) => new SubCar(car.CarID, car.Name));

//            subArray.Print();
//            subCars.Print();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
//        }
//    }
//    struct SubCar
//    {
//        public int CarID { get; set; }
//        public string Name { get; set; }
//        public SubCar (int id, string n)
//        {
//            CarID = id;
//            Name = n;
//        }
//        public override string ToString()
//        {
//            return string.Format("{{{0},{1}}}", CarID, Name);
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 10, 25 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            var subArray = arr.Where((n) => n % 2 == 0).Select((n) => "int:" + n);
//            var subCars = cars.Where((car) => car.Color == "Red").Select((car) => new SubCar(car.CarID, car.Name));

//            subArray.Print();
//            subCars.Print();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 10, 25 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                }; 
//            var subArray = arr.Where((n) => n % 2 == 0).Select((n) => "int:"+n);
//            var subCars = cars.Where((car) => car.Color == "Red").Select((car)=>new { car.CarID, car.Name });

//            subArray.Print();
//            subCars.Print();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void Print<T>(this IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 10, 25 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            var subArray = arr.Where((n) => n % 2 == 0);
//            var subCars = cars.Where((car) => car.Color == "Red");

//            subArray.Print();
//            subCars.Print();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
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
//            return $"[CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}]";
//        }
//    }
//    class Program
//    {
//        static void PrintEnumerable<T>(IEnumerable<T> ie)
//        {
//            foreach (var item in ie)
//                Console.Write("{0} ", item);
//            Console.WriteLine("\n");
//        }
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 10, 25 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            var subArray = arr.Where((n) => n % 2 == 0);
//            var subCars = cars.Where((car) => car.Color == "Red");

//            PrintEnumerable(subArray);
//            PrintEnumerable(subCars);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
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
//            return $"CarID:{CarID},Make:{Make},Color:{Color},Name:{Name}";
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 10, 25 };
//            Car[] cars =
//                {
//                    new Car(101,"현대","Red","아반테"),
//                    new Car(102,"기아","Red","K7"),
//                    new Car(103,"쌍용","Blue","코란도"),
//                    new Car(104,"대우","Green","윈스톰"),
//                    new Car(105,"BMW","Yellow","e250"),
//                };
//            var sub = arr.Select((n) => new { Value = n, Name = "Data" }); //select는 타입을 다른타입으로 변환할수 있다.
//            foreach (var item in sub)
//                Console.WriteLine(item);

//            var subCars = cars.Select((car) => car.Name);
//            foreach (var item in subCars)
//                Console.WriteLine(item);
//            var subCars2 = cars.Select((car) => new { car.CarID, car.Name });
//            foreach (var item in subCars2)
//                Console.WriteLine(item);
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = { 51, 39, 82, 75, 49, 66, 10, 25 };

//            var sub = arr.Select((n) => new { Value = n, Name = "Data" });

//            foreach (var item in sub)
//                Console.WriteLine(item);
//        }
//    }
//}

//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//        int[] arr = { 51, 39, 82, 75, 49, 66, 10, 25 };

//        var sub = arr.Select((n) => new Tuple<int, string>(n, "Data"));
//        foreach(var item in sub)
//            Console.WriteLine(item);
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void PrintCount<T>(this IEnumerable<T> arr, Action<T> f)
//        {
//            foreach (var n in arr)
//                f(n);
//            Console.WriteLine();
//        }

//    public static IEnumerable<T> Select<T>(this IEnumerable<T> ie, Func<T, T> f)
//    {
//            List<T> lt = new List<T>();
//        foreach (var item in ie)
//            lt.Add(f(item));
//        return lt;
//    }
//    public static int Count<T>(this IEnumerable<T>ie)
//        {
//            IEnumerator<T> itor = ie.GetEnumerator();
//            int count = 0;
//            while (itor.MoveNext())
//                ++count;
//            return count;
//        }
//    public static bool Any<T> (this IEnumerable<T> ie, Func<T,bool>f)
//        {
//            bool flag = false;
//            foreach (T item in ie)
//                flag |= f(item);

//            return flag;

//        }
//}   
//    class Program
//    {
//        static void MyPrintString(string s)
//        {
//            Console.Write("{0},{0},{0}  ", s);
//        }
//        static void Main(string[] args)
//        {
//            int[] arr = Enumerable.Range(100, 101).ToArray();  ///100부터 시작해서 10개만 만들어봐
//            List<int> lt = Enumerable.Range(100, 101).ToList();
//            string[] sarr = { "ABC", "Hello!", "12345" };

//            IEnumerable<int> subArray = arr.Select((n) => n * 2);
//            foreach (var n in subArray)
//                Console.WriteLine("{0} ", n);
//            Console.WriteLine();

//            int count = arr.Count();
//            Console.WriteLine("Count : {0} ", count);

//            bool flag = arr.Any((n)=> n > 150 );
//            Console.WriteLine("Any : {0} ", flag);  //조건을 입력하게 되어있다
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void PrintCount<T>(this IEnumerable<T> arr,Action<T> f)
//        {
//            foreach (var n in arr)
//                f(n);
//            Console.WriteLine();
//        }
//    }
//    class Program
//    {
//        static void MyPrintString(string s)
//        {
//            Console.Write("{0},{0},{0}  " , s);
//        }
//        static void Main(string[] args)
//        {
//            int[] arr = Enumerable.Range(100, 101).ToArray();  ///100부터 시작해서 10개만 만들어봐
//            List<int> lt = Enumerable.Range(100, 101).ToList();
//            string[] sarr = { "ABC", "Hello!", "12345" };

//            arr.PrintCount((n) => Console.WriteLine("int : {0}",n));
//            lt.PrintCount((n) => Console.Write("int : {0}  ", n));
//            Console.WriteLine();
//            sarr.PrintCount((s) => Console.WriteLine("string : {0} ", s));
//            Console.WriteLine();
//            sarr.PrintCount(MyPrintString);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void PrintCount<T>(this IEnumerable<T> arr)
//        {
//            foreach (var n in arr)
//                Console.Write("{0} ", n);
//            Console.WriteLine();
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = Enumerable.Range(100, 101).ToArray();  ///100부터 시작해서 10개만 만들어봐
//            List<int> lt = Enumerable.Range(100, 101).ToList();
//            string[] sarr = { "ABC", "Hello!", "12345" };

//            arr.PrintCount();
//            lt.PrintCount();
//            sarr.PrintCount();
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void PrintCount(this IEnumerable<int> arr)
//        {
//            foreach (var n in arr)
//                Console.Write("{0} ", n);
//            Console.WriteLine();
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = Enumerable.Range(100, 101).ToArray();  ///100부터 시작해서 10개만 만들어봐
//            List<int> lt = Enumerable.Range(100, 101).ToList();

//            arr.PrintCount();
//            lt.PrintCount();
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    static class MyEnumerable
//    {
//        public static void PrintCount(this int[] arr)
//        {
//            foreach (var n in arr)
//                Console.Write("{0} ", n);
//            Console.WriteLine();
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = Enumerable.Range(100, 101).ToArray();  ///100부터 시작해서 10개만 만들어봐
//            List<int> lt = Enumerable.Range(100, 101).ToList();

//            arr.PrintCount();
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int [] arr = Enumerable.Range(100, 101).ToArray();  ///100부터 시작해서 10개만 만들어봐
//            List<int> lt = Enumerable.Range(100, 101).ToList();
//            foreach (var n in arr)
//                Console.Write("{0} ", n);
//            Console.WriteLine();
//            foreach (var n in lt)
//                Console.Write("{0} ", n);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            IEnumerable<int> ie = Enumerable.Range(100, 10);  ///100부터 시작해서 10개만 만들어봐
//            Console.WriteLine(ie.GetType().Name);

//            foreach(var n in ie)
//                Console.Write("{0} ",n);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string s = "Hello!";
//            List<int> lt = new List<int>();
//            lt.Add(10);
//            lt.Add(20);
//            lt.Add(30);

//            IEnumerable<char> subString = s as IEnumerable<char>;
//            IEnumerable<int> subList = lt as IEnumerable<int>;

//            IEnumerable<char> subString2 = subString.Select((char c) => (char)(c + 1));
//            IEnumerable<int> subList2 = subList.Select((int n) => n + 1);
//            Console.WriteLine(subString2.GetType().Name);
//            Console.WriteLine(subList2.GetType().Name);

//            foreach (char c in subString2)
//                Console.Write("{0}", c);
//            Console.WriteLine();

//            foreach (int n in subList2)
//                Console.Write("{0} ", n);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace ex220714
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string s = "Hello!";
//            List<int> lt = new List<int>();
//            lt.Add(10);
//            lt.Add(20);
//            lt.Add(30);

//            IEnumerable<char> subString = s as IEnumerable<char>;
//            IEnumerable<int> subList = lt as IEnumerable<int>;

//            IEnumerable<char> subString2 = subString.Select((char c) => (char)(c + 1));

//            IEnumerable<int> subList2 = subList.Select((int n) => n + 1);
//            Console.WriteLine(subString2.GetType().Name);
//            Console.WriteLine(subList2.GetType().Name);

//            foreach(char c in subString2)
//                Console.Write("{0}",c);
//            Console.WriteLine();

//            foreach (int n in subList2)
//                Console.Write("{0} ", n);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            string s = "Hello";

//            List(int) lt = new List<int>();
//            lt.Add(10);
//            lt.Add(20);
//            lt.Add(30);

//            Console.WriteLine(s);
//            Console.WriteLine(lt);

//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    class UserType
//    { }
//    class Program
//    {
//        static double Div(int data)
//        {
//            return (double)data / 3;
//        }
//        static void PrintString(string data)
//        {
//            Console.WriteLine(data);
//        }
//        static void Main(string[] args)

//        {
//            Func<int, double> f = null;
//            Action<string> a = null;
//        }
//    }


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//    {
//        class UserType
//        { }
//        class Program
//        {
//            delegate double Fun(int data);
//            delegate void Act(string data);
//            static void Main(string[] args)
//            {
//                Func<int, double> f = null;
//                Action<string> a = null;
//            }
//        }
//    }

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//    {
//        class UserType
//        { }
//        class Program
//        {
//            delegate double Fun(int data);
//            delegate void Act(string data);
//            static void Main(string[] args)
//            {
//                Func<int, double> f = null;
//                Action<string> a = null;
//            }
//        }
//    }

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    class UserType
//    { }
//    class Program
//    {
//        static void Print<T, U>(T data1, U data2)
//        {
//            Console.WriteLine("{0} : {1} ", data1, data2);
//        }
//        static void Main(string[] args)
//        {
//            Print<int, int>(10, 20);
//            Print(100, 200);
//            Print<int, string>(100, "Hello");
//            Print("Hello", 5.5);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    class UserType
//    { }
//    class Program
//    {
//        static void Print<T,U>(T data1, U data2)
//        {
//            Console.WriteLine("{0} : {1} ", data1, data2);
//        }
//        static void Main(string[] args)
//        {
//            Print<int, int>(10, 20);
//            Print(100, 200);
//            Print<int, string>(100, "Hello");
//            Print("Hello",5.5);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    class UserType
//    { }
//    class Program
//    {
//        static void Print<T>(T data1, T data2)
//        {
//            Console.WriteLine("{0} : {1} ", data1,data2);
//        }
//        static void Main(string[] args)
//        {
//            Print<int>(10, 20);
//            Print(100, 200);
//            Print("abcd", "Hello");
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220714
//{
//    class UserType
//    { }
//    class Program
//    {
//        static void Print<T>(T data)
//        {
//            Console.WriteLine("{1} : {0} ", data, data.GetType().Name);
//        }
//        static void Main(string[] args)
//        {
//            Print<int>(10);
//            Print<string>("hello");
//            Print<UserType>(new UserType());
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

////namespace ex220714
////{
////    class Program
////    {
////        static void Print(int data)
////        {
////            Console.WriteLine("{1} : {0} ", data, data.GetType().Name);
////        }
////        static void Print(string data)
////        {
////            Console.WriteLine("{1} : {0} ", data, data.GetType().Name);
////        }

////        static void Main(string[] args)
////        {
////            Print<int>(10);
////            Print<string>("hello");
////            Print<UserType>(new UserType());
////        }
////    }
////}


