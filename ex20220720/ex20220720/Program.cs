using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ex220720
{
    interface IControllerIO
    {
        void Add();
        void Print();
        void Search();
        void Remove();
    }
    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public Person(string n = "", string ph = "")
        {
            Name = n;
            Phone = ph;
        }
        public Person(byte[] buf)
        {
            SetData(buf);
        }
        public override string ToString()
        {
            return $"name: {Name}, phone: {Phone}";
        }
        public byte[] ToBytes()
        {
            byte[] nameBytes = Encoding.Unicode.GetBytes(Name);
            int nameLen = nameBytes.Length;
            byte[] nameLenBytes = BitConverter.GetBytes(nameLen);
            byte[] phoneBytes = Encoding.Unicode.GetBytes(Phone);
            int phoneLen = phoneBytes.Length;
            byte[] phoneLenBytes = BitConverter.GetBytes(phoneLen);

            byte[] bytes = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();

            return bytes;
        }
        private void SetData(byte[] buf)
        {
            byte[] nameLenBytes = buf.Take(4).ToArray();
            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
            byte[] nameBytes = buf.Skip(4).Take(nameLen).ToArray();
            byte[] phoneLenBytes = buf.Skip(4 + nameLen).Take(4).ToArray();
            int phoneLen = BitConverter.ToInt32(phoneLenBytes, 0);
            byte[] phoneBytes = buf.Skip(4 + nameLen + 4).Take(phoneLen).ToArray();

            Name = Encoding.Unicode.GetString(nameBytes);
            Phone = Encoding.Unicode.GetString(phoneBytes);
        }
    }
    static class TelphoneBookEx
    {
        public static int ToInt(this FileStream fStream)
        {
            byte[] nameLenBytes = new byte[4];
            fStream.Read(nameLenBytes, 0, 4);
            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
            return nameLen;
        }
        public static string ToString(this FileStream fStream)
        {
            byte[] nameLenBytes = new byte[4];
            fStream.Read(nameLenBytes, 0, 4);
            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);

            byte[] nameBytes = new byte[nameLen];

            fStream.Read(nameBytes, 0, nameLen);

            return Encoding.Unicode.GetString(nameBytes);
        }
    }
    class TelphoneBook : IControllerIO, IDisposable/*, IFileIO*/
    {

        List<Person> phoneList = new List<Person>();

        public TelphoneBook()
        {
            try
            {
                using (FileStream fStream = new FileStream("TelPhoneBook.ati", FileMode.Open))
                {

                    int countPerson = fStream.ToInt();

                    for (int i = 0; i < countPerson; ++i)
                    {
                        string name = TelphoneBookEx.ToString(fStream);
                        string phone = TelphoneBookEx.ToString(fStream);

                        phoneList.Add(new Person(name,phone));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("파일열기 실패 : {0}", e.Message);
            }
        }
        public void Add()
        {
            try
            {
                Console.Write("이름 입력:");
                string name = Console.ReadLine();
                Console.Write("전화 입력:");
                string phone = Console.ReadLine();
                phoneList.Add(new Person(name, phone));
            }
            catch (Exception e)
            {
                Console.WriteLine("예외 : {0}", e.Message);
            }
        }
        public void Print()
        {
            phoneList.ForEach((per) =>
            {
                Console.WriteLine("{0}", per);
            });
        }
        public void Search()
        {
            var subList = phoneList.Where((per) => per.Name == "홍길동");
            Console.WriteLine("찾은 모든 전화 번호:");
            foreach (var per in subList)
                Console.WriteLine(per);
        }
        public void Remove()
        {
            Person per = phoneList.Where((p) => p.Name == "홍길동").FirstOrDefault();
            if (phoneList.Remove(per))
                Console.WriteLine("삭제 성공!");
            else
                Console.WriteLine("삭제 실패!");
        }
        public void Dispose()
        {
            using (FileStream fStream = new FileStream("TelPhoneBook.ati", FileMode.Create))
            {
                int countPerson = phoneList.Count;
                byte[] countBytes = BitConverter.GetBytes(countPerson);
                fStream.Write(countBytes, 0, 4);            //헤더
                foreach (var per in phoneList)
                {
                    byte[] writeBytes = per.ToBytes();
                    fStream.Write(writeBytes, 0, writeBytes.Length);        //데이터
                }

                Console.WriteLine("파일 저장완료");
            }
        }
    }

    static class Helper
    {
        public static void Menu()
        {
            Console.WriteLine("==================");
            Console.WriteLine("1. 전화번호 등록");
            Console.WriteLine("2. 전화번호 출력");
            Console.WriteLine("3. 전화번호 검색");
            Console.WriteLine("4. 전화번호 삭제");
            Console.WriteLine("0. 프로그램 종료");
            Console.WriteLine("==================");
            Console.WriteLine();
        }
    }
    class CUI       //open 확장에는 열려있고 수정에는 닫혀있다.
    {
        IControllerIO io;
        public CUI(IControllerIO io)
        {
            this.io = io;
        }

        public void Run()
        {
            Helper.Menu();
            bool run = true;
            while (run)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        io.Add();
                        break;
                    case "2":
                        io.Print();
                        break;
                    case "3":
                        io.Search();
                        break;
                    case "4":
                        io.Remove();
                        break;
                    case "0":
                        run = false;
                        break;
                }
            }

        }
    }
    //메인의 영역
    internal class Program
    {
        static void Main(string[] args)
        {
            using (TelphoneBook tpbook = new TelphoneBook())
            {
                CUI cui = new CUI(tpbook);
                cui.Run();
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }
//        public Person(string n = "", string ph = "")
//        {
//            Name = n;
//            Phone = ph;
//        }
//        public Person(byte[] buf)
//        {
//            SetData(buf);
//        }
//        public override string ToString()
//        {
//            return $"name: {Name}, phone: {Phone}";
//        }
//        public byte[] ToBytes()
//        {
//            byte[] nameBytes = Encoding.Unicode.GetBytes(Name);
//            int nameLen = nameBytes.Length;
//            byte[] nameLenBytes = BitConverter.GetBytes(nameLen);
//            byte[] phoneBytes = Encoding.Unicode.GetBytes(Phone);
//            int phoneLen = phoneBytes.Length;
//            byte[] phoneLenBytes = BitConverter.GetBytes(phoneLen);

//            byte[] bytes = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();

//            return bytes;
//        }
//        private void SetData(byte[] buf)
//        {
//            byte[] nameLenBytes = buf.Take(4).ToArray();
//            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
//            byte[] nameBytes = buf.Skip(4).Take(nameLen).ToArray();
//            byte[] phoneLenBytes = buf.Skip(4 + nameLen).Take(4).ToArray();
//            int phoneLen = BitConverter.ToInt32(phoneLenBytes, 0);
//            byte[] phoneBytes = buf.Skip(4 + nameLen + 4).Take(phoneLen).ToArray();

//            Name = Encoding.Unicode.GetString(nameBytes);
//            Phone = Encoding.Unicode.GetString(phoneBytes);
//        }
//    }
//    static class TelphoneBookEx
//    {
//        public static int ToInt(this FileStream fStream, out byte[] nameLenBytes)
//        {
//            nameLenBytes = new byte[4];
//            fStream.Read(nameLenBytes, 0, 4);
//            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
//            return nameLen;
//        }
//        public static string ToString(this FileStream fStream, out byte[] nameLenBytes, out byte[] nameBytes)
//        {
//            int nameLen = fStream.ToInt(out nameLenBytes);
//            nameBytes = new byte[nameLen];
//            fStream.Read(nameBytes, 0, nameLen);

//            return Encoding.Unicode.GetString(nameBytes);
//        }
//    }
//    class TelphoneBook : IControllerIO, IDisposable/*, IFileIO*/
//    {

//        List<Person> phoneList = new List<Person>();

//        public TelphoneBook()
//        {
//            try
//            {
//                using (FileStream fStream = new FileStream("TelPhoneBook.ati", FileMode.Open))
//                {
//                    byte[] countBytes = new byte[4];
//                    fStream.Read(countBytes, 0, 4);
//                    int countPerson = BitConverter.ToInt32(countBytes, 0);

//                    for (int i = 0; i < countPerson; ++i)
//                    {
//                        byte[] nameLenBytes = null;
//                        byte[] nameBytes = null;
//                        string name = fStream.ToString(out nameLenBytes, out nameBytes);

//                        byte[] phoneLenBytes = null;
//                        byte[] phoneBytes = null;
//                        string phone = fStream.ToString(out phoneLenBytes, out phoneBytes);


//                        byte[] buf = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();

//                        phoneList.Add(new Person(buf));
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("파일열기 실패 : {0}", e.Message);
//            }
//        }
//        public void Add()
//        {
//            try
//            {
//                Console.Write("이름 입력:");
//                string name = Console.ReadLine();
//                Console.Write("전화 입력:");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("예외 : {0}", e.Message);
//            }
//        }
//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine("{0}", per);
//            });
//        }
//        public void Search()
//        {
//            var subList = phoneList.Where((per) => per.Name == "홍길동");
//            Console.WriteLine("찾은 모든 전화 번호:");
//            foreach (var per in subList)
//                Console.WriteLine(per);
//        }
//        public void Remove()
//        {
//            Person per = phoneList.Where((p) => p.Name == "홍길동").FirstOrDefault();
//            if (phoneList.Remove(per))
//                Console.WriteLine("삭제 성공!");
//            else
//                Console.WriteLine("삭제 실패!");
//        }
//        public void Dispose()
//        {
//            using (FileStream fStream = new FileStream("TelPhoneBook.ati", FileMode.Create))
//            {
//                int countPerson = phoneList.Count;
//                byte[] countBytes = BitConverter.GetBytes(countPerson);
//                fStream.Write(countBytes, 0, 4);            //헤더
//                foreach (var per in phoneList)
//                {
//                    byte[] writeBytes = per.ToBytes();
//                    fStream.Write(writeBytes, 0, writeBytes.Length);        //데이터
//                }

//                Console.WriteLine("파일 저장완료");
//            }
//        }
//    }

//    static class Helper
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("==================");
//            Console.WriteLine("1. 전화번호 등록");
//            Console.WriteLine("2. 전화번호 출력");
//            Console.WriteLine("3. 전화번호 검색");
//            Console.WriteLine("4. 전화번호 삭제");
//            Console.WriteLine("0. 프로그램 종료");
//            Console.WriteLine("==================");
//            Console.WriteLine();
//        }
//    }
//    class CUI       //open 확장에는 열려있고 수정에는 닫혀있다.
//    {
//        IControllerIO io;
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }

//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        io.Add();
//                        break;
//                    case "2":
//                        io.Print();
//                        break;
//                    case "3":
//                        io.Search();
//                        break;
//                    case "4":
//                        io.Remove();
//                        break;
//                    case "0":
//                        run = false;
//                        break;
//                }
//            }

//        }
//    }
//    //메인의 영역
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            using (TelphoneBook tpbook = new TelphoneBook())
//            {
//                CUI cui = new CUI(tpbook);
//                cui.Run();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }
//        public Person(string n = "", string ph = "")
//        {
//            Name = n;
//            Phone = ph;
//        }
//        public Person(byte[] buf)
//        {
//            SetData(buf);
//        }
//        public override string ToString()
//        {
//            return $"name: {Name}, phone: {Phone}";
//        }
//        public byte[] ToBytes()
//        {
//            byte[] nameBytes = Encoding.Unicode.GetBytes(Name);
//            int nameLen = nameBytes.Length;
//            byte[] nameLenBytes = BitConverter.GetBytes(nameLen);
//            byte[] phoneBytes = Encoding.Unicode.GetBytes(Phone);
//            int phoneLen = phoneBytes.Length;
//            byte[] phoneLenBytes = BitConverter.GetBytes(phoneLen);

//            byte[] bytes = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();

//            return bytes;
//        }
//        private void SetData(byte[] buf)
//        {
//            byte[] nameLenBytes = buf.Take(4).ToArray();
//            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
//            byte[] nameBytes = buf.Skip(4).Take(nameLen).ToArray();
//            byte[] phoneLenBytes = buf.Skip(4 + nameLen).Take(4).ToArray();
//            int phoneLen = BitConverter.ToInt32(phoneLenBytes, 0);
//            byte[] phoneBytes = buf.Skip(4 + nameLen + 4).Take(phoneLen).ToArray();

//            Name = Encoding.Unicode.GetString(nameBytes);
//            Phone = Encoding.Unicode.GetString(phoneBytes);
//        }
//    }
//    static class TelphoneBookEx
//    {
//        public static int ToInt(this FileStream fStream, out byte[] nameLenBytes)
//        {
//            nameLenBytes = new byte[4];
//            fStream.Read(nameLenBytes, 0, 4);
//            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
//            return nameLen;
//        }
//        public static string ToString(this FileStream fStream, out byte[] nameLenBytes,out byte[] nameBytes)
//        {
//            int nameLen = fStream.ToInt(out nameLenBytes);
//            nameBytes = new byte[nameLen];
//            fStream.Read(nameBytes, 0, nameLen);

//            return Encoding.Unicode.GetString(nameBytes);
//        }
//    }
//    class TelphoneBook : IControllerIO, IDisposable/*, IFileIO*/
//    {

//        List<Person> phoneList = new List<Person>();

//        public TelphoneBook()
//        {
//            try
//            {
//                using (FileStream fStream = new FileStream("TelPhoneBook.ati", FileMode.Open))
//                {
//                    byte[] countBytes = new byte[4];
//                    fStream.Read(countBytes, 0, 4);
//                    int countPerson = BitConverter.ToInt32(countBytes, 0);

//                    for (int i = 0; i < countPerson; ++i)
//                    {
//                        byte[] nameLenBytes = null;
//                        byte[] nameBytes = null;
//                        string name = fStream.ToString(out nameLenBytes, out nameBytes);

//                        byte[] phoneLenBytes = new byte[4];
//                        fStream.Read(phoneLenBytes, 0, 4);
//                        int phoneLen = BitConverter.ToInt32(phoneLenBytes, 0);
//                        byte[] phoneBytes = new byte[phoneLen];
//                        fStream.Read(phoneBytes, 0, phoneLen);

//                        byte[] buf = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();

//                        phoneList.Add(new Person(buf));
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("파일열기 실패 : {0}", e.Message);
//            }
//        }
//        public void Add()
//        {
//            try
//            {
//                Console.Write("이름 입력:");
//                string name = Console.ReadLine();
//                Console.Write("전화 입력:");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("예외 : {0}", e.Message);
//            }
//        }
//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine("{0}", per);
//            });
//        }
//        public void Search()
//        {
//            var subList = phoneList.Where((per) => per.Name == "홍길동");
//            Console.WriteLine("찾은 모든 전화 번호:");
//            foreach (var per in subList)
//                Console.WriteLine(per);
//        }
//        public void Remove()
//        {
//            Person per = phoneList.Where((p) => p.Name == "홍길동").FirstOrDefault();
//            if (phoneList.Remove(per))
//                Console.WriteLine("삭제 성공!");
//            else
//                Console.WriteLine("삭제 실패!");
//        }
//        public void Dispose()
//        {
//            using (FileStream fStream = new FileStream("TelPhoneBook.ati", FileMode.Create))
//            {
//                int countPerson = phoneList.Count;
//                byte[] countBytes = BitConverter.GetBytes(countPerson);
//                fStream.Write(countBytes, 0, 4);            //헤더
//                foreach (var per in phoneList)
//                {
//                    byte[] writeBytes = per.ToBytes();
//                    fStream.Write(writeBytes, 0, writeBytes.Length);        //데이터
//                }

//                Console.WriteLine("파일 저장완료");
//            }
//        }
//    }

//    static class Helper
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("==================");
//            Console.WriteLine("1. 전화번호 등록");
//            Console.WriteLine("2. 전화번호 출력");
//            Console.WriteLine("3. 전화번호 검색");
//            Console.WriteLine("4. 전화번호 삭제");
//            Console.WriteLine("0. 프로그램 종료");
//            Console.WriteLine("==================");
//            Console.WriteLine();
//        }
//    }
//    class CUI       //open 확장에는 열려있고 수정에는 닫혀있다.
//    {
//        IControllerIO io;
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }

//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        io.Add();
//                        break;
//                    case "2":
//                        io.Print();
//                        break;
//                    case "3":
//                        io.Search();
//                        break;
//                    case "4":
//                        io.Remove();
//                        break;
//                    case "0":
//                        run = false;
//                        break;
//                }
//            }

//        }
//    }
//    //메인의 영역
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            using (TelphoneBook tpbook = new TelphoneBook())
//            {
//                CUI cui = new CUI(tpbook);
//                cui.Run();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }
//        public Person(string n = "", string ph = "")
//        {
//            Name = n;
//            Phone = ph;
//        }
//        public Person(byte[] buf)
//        {
//            SetData(buf);
//        }
//        public override string ToString()
//        {
//            return $"name: {Name}, phone: {Phone}";
//        }
//        public byte[] ToBytes()
//        {
//            byte[] nameBytes = Encoding.Unicode.GetBytes(Name);
//            int nameLen = nameBytes.Length;
//            byte[] nameLenBytes = BitConverter.GetBytes(nameLen);
//            byte[] phoneBytes = Encoding.Unicode.GetBytes(Phone);
//            int phoneLen = phoneBytes.Length;
//            byte[] phoneLenBytes = BitConverter.GetBytes(phoneLen);

//            byte[] bytes = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();

//            return bytes;
//        }
//        private void SetData(byte[] buf)
//        {
//            byte[] nameLenBytes = buf.Take(4).ToArray();
//            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
//            byte[] nameBytes = buf.Skip(4).Take(nameLen).ToArray();
//            byte[] phoneLenBytes = buf.Skip(4 + nameLen).Take(4).ToArray();
//            int phoneLen = BitConverter.ToInt32(phoneLenBytes, 0);
//            byte[] phoneBytes = buf.Skip(4 + nameLen + 4).Take(phoneLen).ToArray();

//            Name = Encoding.Unicode.GetString(nameBytes);
//            Phone = Encoding.Unicode.GetString(phoneBytes);
//        }
//    }
//    static class TelphoneBookEx
//    {
//        public static int ToInt(this FileStream fStream, out byte[] nameLenBytes)
//        {
//            nameLenBytes = new byte[4];
//            fStream.Read(nameLenBytes, 0, 4);
//            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
//            return nameLen;
//        }
//        public static string ToString(this FileStream fStream, out byte[] nameBytes, int nameLen)
//        {
//            nameBytes = new byte[nameLen];
//            fStream.Read(nameBytes, 0, nameLen);

//            return Encoding.Unicode.GetString(nameBytes);
//        }
//    }
//    class TelphoneBook : IControllerIO, IDisposable/*, IFileIO*/
//    {

//        List<Person> phoneList = new List<Person>();

//        public TelphoneBook()
//        {
//            try
//            {
//                using (FileStream fStream = new FileStream("TelPhoneBook.ati", FileMode.Open))
//                {
//                    byte[] countBytes = new byte[4];
//                    fStream.Read(countBytes, 0, 4);
//                    int countPerson = BitConverter.ToInt32(countBytes, 0);

//                    for (int i = 0; i < countPerson; ++i)
//                    {
//                        byte[] nameLenBytes = null;
//                        int nameLen = fStream.ToInt(out nameLenBytes);
//                        byte[] nameBytes = null;
//                        string name = fStream.ToString(out nameBytes, nameLen);

//                        byte[] phoneLenBytes = new byte[4];
//                        fStream.Read(phoneLenBytes, 0, 4);
//                        int phoneLen = BitConverter.ToInt32(phoneLenBytes, 0);
//                        byte[] phoneBytes = new byte[phoneLen];
//                        fStream.Read(phoneBytes, 0, phoneLen);

//                        byte[] buf = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();

//                        phoneList.Add(new Person(buf));
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("파일열기 실패 : {0}", e.Message);
//            }
//        }
//        public void Add()
//        {
//            try
//            {
//                Console.Write("이름 입력:");
//                string name = Console.ReadLine();
//                Console.Write("전화 입력:");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("예외 : {0}", e.Message);
//            }
//        }
//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine("{0}", per);
//            });
//        }
//        public void Search()
//        {
//            var subList = phoneList.Where((per) => per.Name == "홍길동");
//            Console.WriteLine("찾은 모든 전화 번호:");
//            foreach (var per in subList)
//                Console.WriteLine(per);
//        }
//        public void Remove()
//        {
//            Person per = phoneList.Where((p) => p.Name == "홍길동").FirstOrDefault();
//            if (phoneList.Remove(per))
//                Console.WriteLine("삭제 성공!");
//            else
//                Console.WriteLine("삭제 실패!");
//        }
//        public void Dispose()
//        {
//            using (FileStream fStream = new FileStream("TelPhoneBook.ati", FileMode.Create))
//            {
//                int countPerson = phoneList.Count;
//                byte[] countBytes = BitConverter.GetBytes(countPerson);
//                fStream.Write(countBytes, 0, 4);            //헤더
//                foreach (var per in phoneList)
//                {
//                    byte[] writeBytes = per.ToBytes();
//                    fStream.Write(writeBytes, 0, writeBytes.Length);        //데이터
//                }

//                Console.WriteLine("파일 저장완료");
//            }
//        }
//    }

//    static class Helper
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("==================");
//            Console.WriteLine("1. 전화번호 등록");
//            Console.WriteLine("2. 전화번호 출력");
//            Console.WriteLine("3. 전화번호 검색");
//            Console.WriteLine("4. 전화번호 삭제");
//            Console.WriteLine("0. 프로그램 종료");
//            Console.WriteLine("==================");
//            Console.WriteLine();
//        }
//    }
//    class CUI       //open 확장에는 열려있고 수정에는 닫혀있다.
//    {
//        IControllerIO io;
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }

//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        io.Add();
//                        break;
//                    case "2":
//                        io.Print();
//                        break;
//                    case "3":
//                        io.Search();
//                        break;
//                    case "4":
//                        io.Remove();
//                        break;
//                    case "0":
//                        run = false;
//                        break;
//                }
//            }

//        }
//    }
//    //메인의 영역
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            using (TelphoneBook tpbook = new TelphoneBook())
//            {
//                CUI cui = new CUI(tpbook);
//                cui.Run();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }
//        public Person(string n = "", string ph = "")
//        {
//            Name = n;
//            Phone = ph;
//        }
//        public Person(byte[] buf)
//        {
//            SetData(buf);
//        }
//        public override string ToString()
//        {
//            return $"name: {Name}, phone: {Phone}";
//        }
//        public byte[] ToBytes()
//        {
//            byte[] nameBytes = Encoding.Unicode.GetBytes(Name);
//            int nameLen = nameBytes.Length;
//            byte[] nameLenBytes = BitConverter.GetBytes(nameLen);
//            byte[] phoneBytes = Encoding.Unicode.GetBytes(Phone);
//            int phoneLen = phoneBytes.Length;
//            byte[] phoneLenBytes = BitConverter.GetBytes(phoneLen);

//            byte[] bytes = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();

//            return bytes;
//        }
//        private void SetData(byte[] buf)
//        {
//            byte[] nameLenBytes = buf.Take(4).ToArray();
//            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
//            byte[] nameBytes = buf.Skip(4).Take(nameLen).ToArray();
//            byte[] phoneLenBytes = buf.Skip(4 + nameLen).Take(4).ToArray();
//            int phoneLen = BitConverter.ToInt32(phoneLenBytes, 0);
//            byte[] phoneBytes = buf.Skip(4 + nameLen + 4).Take(phoneLen).ToArray();

//            Name = Encoding.Unicode.GetString(nameBytes);
//            Phone = Encoding.Unicode.GetString(phoneBytes);
//        }
//    }
//    class TelphoneBook : IControllerIO, IDisposable/*, IFileIO*/
//    {
//        List<Person> phoneList = new List<Person>();

//        public TelphoneBook()
//        {
//            try
//            {
//                using (FileStream fStream = new FileStream("TelPhoneBook.ati", FileMode.Open))
//                {
//                    byte[] countBytes = new byte[4];
//                    fStream.Read(countBytes, 0, 4);
//                    int countPerson = BitConverter.ToInt32(countBytes, 0);

//                    for (int i = 0; i < countPerson; ++i)
//                    {
//                        byte[] nameLenBytes = new byte[4];
//                        fStream.Read(nameLenBytes, 0, 4);
//                        int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
//                        byte[] nameBytes = new byte[nameLen];
//                        fStream.Read(nameBytes, 0, nameLen);

//                        byte[] phoneLenBytes = new byte[4];
//                        fStream.Read(phoneLenBytes, 0, 4);
//                        int phoneLen = BitConverter.ToInt32(phoneLenBytes, 0);
//                        byte[] phoneBytes = new byte[phoneLen];
//                        fStream.Read(phoneBytes, 0, phoneLen);

//                        byte[] buf = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();

//                        phoneList.Add(new Person(buf));
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("파일열기 실패 : {0}", e.Message);
//            }
//        }
//        public void Add()
//        {
//            try
//            {
//                Console.Write("이름 입력:");
//                string name = Console.ReadLine();
//                Console.Write("전화 입력:");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("예외 : {0}", e.Message);
//            }
//        }
//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine("{0}", per);
//            });
//        }
//        public void Search()
//        {
//            var subList = phoneList.Where((per) => per.Name == "홍길동");
//            Console.WriteLine("찾은 모든 전화 번호:");
//            foreach (var per in subList)
//                Console.WriteLine(per);
//        }
//        public void Remove()
//        {
//            Person per = phoneList.Where((p) => p.Name == "홍길동").FirstOrDefault();
//            if (phoneList.Remove(per))
//                Console.WriteLine("삭제 성공!");
//            else
//                Console.WriteLine("삭제 실패!");
//        }
//        public void Dispose()
//        {
//            using (FileStream fStream = new FileStream("TelPhoneBook.ati", FileMode.Create))
//            {
//                int countPerson = phoneList.Count;
//                byte[] countBytes = BitConverter.GetBytes(countPerson);
//                fStream.Write(countBytes, 0, 4);            //헤더
//                foreach (var per in phoneList)
//                {
//                    byte[] writeBytes = per.ToBytes();
//                    fStream.Write(writeBytes, 0, writeBytes.Length);        //데이터
//                }

//                Console.WriteLine("파일 저장완료");
//            }
//        }
//    }

//    static class Helper
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("==================");
//            Console.WriteLine("1. 전화번호 등록");
//            Console.WriteLine("2. 전화번호 출력");
//            Console.WriteLine("3. 전화번호 검색");
//            Console.WriteLine("4. 전화번호 삭제");
//            Console.WriteLine("0. 프로그램 종료");
//            Console.WriteLine("==================");
//            Console.WriteLine();
//        }
//    }
//    class CUI       //open 확장에는 열려있고 수정에는 닫혀있다.
//    {
//        IControllerIO io;
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }

//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        io.Add();
//                        break;
//                    case "2":
//                        io.Print();
//                        break;
//                    case "3":
//                        io.Search();
//                        break;
//                    case "4":
//                        io.Remove();
//                        break;
//                    case "0":
//                        run = false;
//                        break;
//                }
//            }

//        }
//    }
//    //메인의 영역
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            using (TelphoneBook tpbook = new TelphoneBook())
//            {
//                CUI cui = new CUI(tpbook);
//                cui.Run();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;


////2-4번  TelphoneBook   IDisposable
//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    interface IFileIO
//    {
//        void WriteFile();
//        void ReadFile();
//    }
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }

//        public Person(string Name = "", string Phone = "")
//        {
//            this.Name = Name;
//            this.Phone = Phone;
//        }
//        public Person(byte[] buf)
//        {
//            SetData(buf);
//        }
//        public override string ToString()
//        {
//            return $"{Name} , {Phone}";
//        }
//        public byte[] ToBytes()
//        {
//            byte[] nameBytes = Encoding.Unicode.GetBytes(Name);
//            int nameLen = nameBytes.Length;
//            byte[] nameLenBytes = BitConverter.GetBytes(nameLen);
//            byte[] phoneBytes = Encoding.Unicode.GetBytes(Phone);
//            int phoneLen = phoneBytes.Length;
//            byte[] phoneLenBytes = BitConverter.GetBytes(phoneLen);
//            byte[] bytes = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();
//            return bytes;
//        }
//        public void SetData(byte[] buf)
//        {
//            byte[] nameLenBytes = buf.Take(4).ToArray();
//            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
//            byte[] nameBytes = buf.Skip(4).Take(nameLen).ToArray();
//            byte[] phoneLenBytes = buf.Skip(4 + nameLen).Take(4).ToArray();
//            int phoneLen = BitConverter.ToInt32(phoneLenBytes, 0);
//            byte[] phoneBytes = buf.Skip(4 + nameLen + 4).Take(phoneLen).ToArray();

//            Name = Encoding.Unicode.GetString(nameBytes);
//            Phone = Encoding.Unicode.GetString(phoneBytes);
//        }

//    }
//    class TelphoneBook : IControllerIO, IDisposable
//    {
//        List<Person> phoneList = new List<Person>();
//        public TelphoneBook()
//        {
//            try
//            {
//                BinaryFormatter formatter = new BinaryFormatter();
//                using (FileStream fstream = new FileStream("Telphonbook.ati", FileMode.Open))
//                {
//                    phoneList = (List<Person>)formatter.Deserialize(fstream); //as List<Person>;
//                    Console.WriteLine("Data 복원 완료");
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//        public void Add()    //public static void Add() --> 인스턴스 : tpbook tpbook2  --> Add를 중복해서 만들수있기에 static 으로 쓰면 안된다 
//        {
//            try
//            {
//                Console.Write("이름 입력:");
//                string name = Console.ReadLine();
//                Console.WriteLine("전화 입력");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//                Console.WriteLine("등록되었습니다");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine($"예외 발생 :{e} ");
//            }
//        }
//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine($"{per}");
//            });
//        }
//        public void Search()   //linq 메서드 사용
//        {
//            Console.Write("이름 입력:");
//            string name = Console.ReadLine();
//            var subList = phoneList.Where((per) => per.Name == name);
//            Console.WriteLine("찾은 모든 결과");
//            foreach (var per in subList)
//            {
//                Console.WriteLine($"{per}");
//            }
//        }
//        public void Remove()
//        {
//            Console.Write("이름 입력:");
//            string name = Console.ReadLine();

//            Person per = phoneList.Where((p) => p.Name == name).FirstOrDefault();
//            if (phoneList.Remove(per))
//                Console.WriteLine("삭제완료");
//            else
//                Console.WriteLine("삭제실패");
//        }
//        public void Dispose()
//        {
//            Console.WriteLine("파일출력");
//            BinaryFormatter formatter = new BinaryFormatter();
//            using (FileStream fstream = new FileStream("Telphonbook.ati", FileMode.Create))
//            {
//                formatter.Serialize(fstream, phoneList);
//                Console.WriteLine("파일 데이터 저장 완료");
//            }
//        }
//    }
//    static class Helper // 인수가 없으면 static으로 생성
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("===============");
//            Console.WriteLine("1.전화번호 등록");
//            Console.WriteLine("2.전화번호 출력");
//            Console.WriteLine("3.전화번호 검색");
//            Console.WriteLine("4.전화번호 삭제");
//            Console.WriteLine("0.프로그램 종료");
//            Console.WriteLine("===============");
//            Console.WriteLine();
//        }
//    }
//    class CUI
//    {
//        IControllerIO io;       //확장에는 열려있고 수정에는 닫혀있다.
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }
//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        {
//                            io.Add();
//                        }
//                        break;
//                    case "2":
//                        {
//                            io.Print();
//                        }
//                        break;
//                    case "3":
//                        {
//                            io.Search();
//                        }
//                        break;
//                    case "4":
//                        {
//                            io.Remove();
//                        }
//                        break;
//                    case "0":
//                        {
//                            run = false;
//                        }
//                        break;

//                    default:
//                        break;
//                }
//            }
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Person per = new Person("ABC", "123");
//            byte[] buf = per.ToBytes();
//            foreach (var x in buf)
//                Console.WriteLine("{0:X2}", x);
//            Console.WriteLine();

//            Person per2 = new Person(buf);
//            Console.WriteLine("Person : {0}", per2);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;


////2-4번  TelphoneBook   IDisposable
//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    interface IFileIO
//    {
//        void WriteFile();
//        void ReadFile();
//    }
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }

//        public Person(string Name = "", string Phone = "")
//        {
//            this.Name = Name;
//            this.Phone = Phone;
//        }
//        public override string ToString()
//        {
//            return $"{Name} , {Phone}";
//        }
//        public byte[] ToBytes()
//        {
//            byte[] nameBytes = Encoding.Unicode.GetBytes(Name);
//            int nameLen = nameBytes.Length;
//            byte[] nameLenBytes = BitConverter.GetBytes(nameLen);
//            byte[] phoneBytes = Encoding.Unicode.GetBytes(Phone);
//            int phoneLen = phoneBytes.Length;
//            byte[] phoneLenBytes = BitConverter.GetBytes(phoneLen);
//            byte[] bytes = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();
//            return bytes;
//        }
//        public void SetData(byte[] buf)
//        {
//            byte[] nameLenBytes = buf.Take(4).ToArray();
//            int nameLen = BitConverter.ToInt32(nameLenBytes, 0);
//            byte[] nameBytes = buf.Skip(4).Take(nameLen).ToArray();
//            byte[] phoneLenBytes = buf.Skip(4 + nameLen).Take(4).ToArray();
//            int phoneLen = BitConverter.ToInt32(phoneLenBytes, 0);
//            byte[] phoneBytes = buf.Skip(4 + nameLen + 4).Take(phoneLen).ToArray();

//            Name = Encoding.Unicode.GetString(nameBytes);
//            Phone = Encoding.Unicode.GetString(phoneBytes);
//        }

//    }
//    class TelphoneBook : IControllerIO, IDisposable
//    {
//        List<Person> phoneList = new List<Person>();
//        public TelphoneBook()
//        {
//            try
//            {
//                BinaryFormatter formatter = new BinaryFormatter();
//                using (FileStream fstream = new FileStream("Telphonbook.ati", FileMode.Open))
//                {
//                    phoneList = (List<Person>)formatter.Deserialize(fstream); //as List<Person>;
//                    Console.WriteLine("Data 복원 완료");
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//        public void Add()    //public static void Add() --> 인스턴스 : tpbook tpbook2  --> Add를 중복해서 만들수있기에 static 으로 쓰면 안된다 
//        {
//            try
//            {
//                Console.Write("이름 입력:");
//                string name = Console.ReadLine();
//                Console.WriteLine("전화 입력");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//                Console.WriteLine("등록되었습니다");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine($"예외 발생 :{e} ");
//            }
//        }
//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine($"{per}");
//            });
//        }
//        public void Search()   //linq 메서드 사용
//        {
//            Console.Write("이름 입력:");
//            string name = Console.ReadLine();
//            var subList = phoneList.Where((per) => per.Name == name);
//            Console.WriteLine("찾은 모든 결과");
//            foreach (var per in subList)
//            {
//                Console.WriteLine($"{per}");
//            }
//        }
//        public void Remove()
//        {
//            Console.Write("이름 입력:");
//            string name = Console.ReadLine();

//            Person per = phoneList.Where((p) => p.Name == name).FirstOrDefault();
//            if (phoneList.Remove(per))
//                Console.WriteLine("삭제완료");
//            else
//                Console.WriteLine("삭제실패");
//        }
//        public void Dispose()
//        {
//            Console.WriteLine("파일출력");
//            BinaryFormatter formatter = new BinaryFormatter();
//            using (FileStream fstream = new FileStream("Telphonbook.ati", FileMode.Create))
//            {
//                formatter.Serialize(fstream, phoneList);
//                Console.WriteLine("파일 데이터 저장 완료");
//            }
//        }
//    }
//    static class Helper // 인수가 없으면 static으로 생성
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("===============");
//            Console.WriteLine("1.전화번호 등록");
//            Console.WriteLine("2.전화번호 출력");
//            Console.WriteLine("3.전화번호 검색");
//            Console.WriteLine("4.전화번호 삭제");
//            Console.WriteLine("0.프로그램 종료");
//            Console.WriteLine("===============");
//            Console.WriteLine();
//        }
//    }
//    class CUI
//    {
//        IControllerIO io;       //확장에는 열려있고 수정에는 닫혀있다.
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }
//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        {
//                            io.Add();
//                        }
//                        break;
//                    case "2":
//                        {
//                            io.Print();
//                        }
//                        break;
//                    case "3":
//                        {
//                            io.Search();
//                        }
//                        break;
//                    case "4":
//                        {
//                            io.Remove();
//                        }
//                        break;
//                    case "0":
//                        {
//                            run = false;
//                        }
//                        break;

//                    default:
//                        break;
//                }
//            }
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Person per = new Person("ABC", "123");
//            byte[] buf = per.ToBytes();
//            foreach (var x in buf)
//                Console.WriteLine("{0:X2}", x);
//            Console.WriteLine();

//            Person per2 = new Person();
//            per2.SetData(buf);
//            Console.WriteLine("Person : {0}", per2);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;


////2-4번  TelphoneBook   IDisposable
//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    interface IFileIO
//    {
//        void WriteFile();
//        void ReadFile();
//    }
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }

//        public Person(string Name = "", string Phone = "")
//        {
//            this.Name = Name;
//            this.Phone = Phone;
//        }
//        public override string ToString()
//        {
//            return $"{Name} , {Phone}";
//        }
//        public byte[] ToBytes()
//        {
//            byte[] nameBytes = Encoding.Unicode.GetBytes(Name);
//            int nameLen = nameBytes.Length;
//            byte[] nameLenBytes = BitConverter.GetBytes(nameLen);
//            byte[] phoneBytes = Encoding.Unicode.GetBytes(Phone);
//            int phoneLen = phoneBytes.Length;
//            byte[] phoneLenBytes = BitConverter.GetBytes(phoneLen);
//            byte[] bytes = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();
//            return bytes;
//        }
//        public void SetData(byte[] buf)
//        {

//        }

//    }
//    class TelphoneBook : IControllerIO, IDisposable
//    {
//        List<Person> phoneList = new List<Person>();
//        public TelphoneBook()
//        {
//            try
//            {
//                BinaryFormatter formatter = new BinaryFormatter();
//                using (FileStream fstream = new FileStream("Telphonbook.ati", FileMode.Open))
//                {
//                    phoneList = (List<Person>)formatter.Deserialize(fstream); //as List<Person>;
//                    Console.WriteLine("Data 복원 완료");
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//        public void Add()    //public static void Add() --> 인스턴스 : tpbook tpbook2  --> Add를 중복해서 만들수있기에 static 으로 쓰면 안된다 
//        {
//            try
//            {
//                Console.Write("이름 입력:");
//                string name = Console.ReadLine();
//                Console.WriteLine("전화 입력");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//                Console.WriteLine("등록되었습니다");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine($"예외 발생 :{e} ");
//            }
//        }
//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine($"{per}");
//            });
//        }
//        public void Search()   //linq 메서드 사용
//        {
//            Console.Write("이름 입력:");
//            string name = Console.ReadLine();
//            var subList = phoneList.Where((per) => per.Name == name);
//            Console.WriteLine("찾은 모든 결과");
//            foreach (var per in subList)
//            {
//                Console.WriteLine($"{per}");
//            }
//        }
//        public void Remove()
//        {
//            Console.Write("이름 입력:");
//            string name = Console.ReadLine();

//            Person per = phoneList.Where((p) => p.Name == name).FirstOrDefault();
//            if (phoneList.Remove(per))
//                Console.WriteLine("삭제완료");
//            else
//                Console.WriteLine("삭제실패");
//        }
//        public void Dispose()
//        {
//            Console.WriteLine("파일출력");
//            BinaryFormatter formatter = new BinaryFormatter();
//            using (FileStream fstream = new FileStream("Telphonbook.ati", FileMode.Create))
//            {
//                formatter.Serialize(fstream, phoneList);
//                Console.WriteLine("파일 데이터 저장 완료");
//            }
//        }
//    }
//    static class Helper // 인수가 없으면 static으로 생성
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("===============");
//            Console.WriteLine("1.전화번호 등록");
//            Console.WriteLine("2.전화번호 출력");
//            Console.WriteLine("3.전화번호 검색");
//            Console.WriteLine("4.전화번호 삭제");
//            Console.WriteLine("0.프로그램 종료");
//            Console.WriteLine("===============");
//            Console.WriteLine();
//        }
//    }
//    class CUI
//    {
//        IControllerIO io;       //확장에는 열려있고 수정에는 닫혀있다.
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }
//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        {
//                            io.Add();
//                        }
//                        break;
//                    case "2":
//                        {
//                            io.Print();
//                        }
//                        break;
//                    case "3":
//                        {
//                            io.Search();
//                        }
//                        break;
//                    case "4":
//                        {
//                            io.Remove();
//                        }
//                        break;
//                    case "0":
//                        {
//                            run = false;
//                        }
//                        break;

//                    default:
//                        break;
//                }
//            }
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Person per = new Person("ABC", "123");
//            byte[] buf = per.ToBytes();
//            foreach(var x in buf)
//                Console.WriteLine("{0:X2}", x);
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;


////2-4번  TelphoneBook   IDisposable
//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    interface IFileIO
//    {
//        void WriteFile();
//        void ReadFile();
//    }
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }

//        public Person(string Name = "", string Phone = "")
//        {
//            this.Name = Name;
//            this.Phone = Phone;
//        }
//        public override string ToString()
//        {
//            return $"{Name} , {Phone}";
//        }
//        public byte[] ToBytes()
//        {
//            byte[] nameBytes = Encoding.Unicode.GetBytes(Name); 
//            int nameLen = nameBytes.Length;
//            byte[] nameLenBytes = BitConverter.GetBytes(nameLen);
//            byte[] phoneBytes = Encoding.Unicode.GetBytes(Phone);
//            int phoneLen = phoneBytes.Length;
//            byte[] phoneLenBytes = BitConverter.GetBytes(phoneLen);
//            byte[] bytes = nameLenBytes.Concat(nameBytes).Concat(phoneLenBytes).Concat(phoneBytes).ToArray();
//            return bytes;
//        }
//        public void SetData(byte[] buf)
//        {

//        }

//    }
//    class TelphoneBook : IControllerIO, IDisposable
//    {
//        List<Person> phoneList = new List<Person>();
//        public TelphoneBook()
//        {
//            try
//            {
//                BinaryFormatter formatter = new BinaryFormatter();
//                using (FileStream fstream = new FileStream("Telphonbook.ati", FileMode.Open))
//                {
//                    phoneList = (List<Person>)formatter.Deserialize(fstream); //as List<Person>;
//                    Console.WriteLine("Data 복원 완료");
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//        public void Add()    //public static void Add() --> 인스턴스 : tpbook tpbook2  --> Add를 중복해서 만들수있기에 static 으로 쓰면 안된다 
//        {
//            try
//            {
//                Console.Write("이름 입력:");
//                string name = Console.ReadLine();
//                Console.WriteLine("전화 입력");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//                Console.WriteLine("등록되었습니다");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine($"예외 발생 :{e} ");
//            }
//        }
//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine($"{per}");
//            });
//        }
//        public void Search()   //linq 메서드 사용
//        {
//            Console.Write("이름 입력:");
//            string name = Console.ReadLine();
//            var subList = phoneList.Where((per) => per.Name == name);
//            Console.WriteLine("찾은 모든 결과");
//            foreach (var per in subList)
//            {
//                Console.WriteLine($"{per}");
//            }
//        }
//        public void Remove()
//        {
//            Console.Write("이름 입력:");
//            string name = Console.ReadLine();

//            Person per = phoneList.Where((p) => p.Name == name).FirstOrDefault();
//            if (phoneList.Remove(per))
//                Console.WriteLine("삭제완료");
//            else
//                Console.WriteLine("삭제실패");
//        }
//        public void Dispose()
//        {
//            Console.WriteLine("파일출력");
//            BinaryFormatter formatter = new BinaryFormatter();
//            using (FileStream fstream = new FileStream("Telphonbook.ati", FileMode.Create))
//            {
//                formatter.Serialize(fstream, phoneList);
//                Console.WriteLine("파일 데이터 저장 완료");
//            }
//        }
//    }
//    static class Helper // 인수가 없으면 static으로 생성
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("===============");
//            Console.WriteLine("1.전화번호 등록");
//            Console.WriteLine("2.전화번호 출력");
//            Console.WriteLine("3.전화번호 검색");
//            Console.WriteLine("4.전화번호 삭제");
//            Console.WriteLine("0.프로그램 종료");
//            Console.WriteLine("===============");
//            Console.WriteLine();
//        }
//    }
//    class CUI
//    {
//        IControllerIO io;       //확장에는 열려있고 수정에는 닫혀있다.
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }
//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        {
//                            io.Add();
//                        }
//                        break;
//                    case "2":
//                        {
//                            io.Print();
//                        }
//                        break;
//                    case "3":
//                        {
//                            io.Search();
//                        }
//                        break;
//                    case "4":
//                        {
//                            io.Remove();
//                        }
//                        break;
//                    case "0":
//                        {
//                            run = false;
//                        }
//                        break;

//                    default:
//                        break;
//                }
//            }
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            using (TelphoneBook tpb = new TelphoneBook())        //using 뒤 () -> 파일 복원, 파일출력하는 작업만
//            {
//                CUI cui = new CUI(tpb);
//                cui.Run();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Remove();
//        void Print();
//        void Search();

//    }
//    interface IFileIO
//    {
//        void WriteFile();
//        void ReadFile();
//    }
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }
//        public Person(string n = "", string ph = "")
//        {
//            Name = n;
//            Phone = ph;
//        }
//        public override string ToString()
//        {
//            return $"name:{Name} , phone:{Phone}";
//        }
//    }
//    class TelPhoneBook : IControllerIO, IDisposable
//    {
//        List<Person> phoneList = new List<Person>();
//        public TelPhoneBook()
//        {
//            try
//            {
//                BinaryFormatter bFormat = new BinaryFormatter();
//                using (FileStream fstream = new FileStream("TelPhoneBook.ati", FileMode.Open))
//                {
//                    phoneList = (List<Person>)bFormat.Deserialize(fstream);
//                    Console.WriteLine("데이터 복원 완료 !");
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("파이 열기 실패 : {0}", e);
//            }
//        }
//        public void Add()
//        {
//            Console.WriteLine("이름입력 : ");
//            string name = Console.ReadLine();
//            Console.WriteLine("전화번호입력 : ");
//            string pho = Console.ReadLine();
//            phoneList.Add(new Person(name, pho));

//        }

//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine(per);
//            });

//        }

//        public void Search()
//        {
//            var sublist = phoneList.Where((per) => per.Name == "홍길동");
//            foreach (var per in sublist)
//            {
//                Console.WriteLine(per);
//            }

//        }

//        public void Remove()
//        {
//            Person per = phoneList.Where((p) => p.Name == "홍길동").ToList().FirstOrDefault();
//            if (phoneList.Remove(per))
//            {
//                Console.WriteLine("삭제 성공 !");
//            }
//            else
//            {
//                Console.WriteLine("삭제 실패 !");
//            }
//        }

//        public void Dispose()
//        {
//            BinaryFormatter bFormat = new BinaryFormatter();
//            using (FileStream fstream = new FileStream("TelPhoneBook.ati", FileMode.Create))
//            {
//                bFormat.Serialize(fstream, phoneList);
//                Console.WriteLine("파일 저장 완료 !");
//            }

//        }
//    }
//    static class Helper
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("====================");
//            Console.WriteLine("1, 전화번호 등록");
//            Console.WriteLine("2, 전화번호 출력");
//            Console.WriteLine("3, 전화번호 검색");
//            Console.WriteLine("4, 전화번호 삭제");
//            Console.WriteLine("0, 프로그램종료");
//            Console.WriteLine("====================");
//            Console.WriteLine();
//        }
//    }
//    class CUI
//    {
//        IControllerIO io;
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }

//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        {
//                            io.Add();
//                        }
//                        break;
//                    case "2":
//                        {
//                            io.Print();
//                        }
//                        break;
//                    case "3":
//                        {
//                            io.Search();
//                        }
//                        break;
//                    case "4":
//                        {
//                            io.Remove();
//                        }
//                        break;
//                    case "0":
//                        {
//                            run = false;
//                        }
//                        break;
//                }
//            }
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            using (TelPhoneBook tpbook = new TelPhoneBook())
//            {
//                CUI cui = new CUI(tpbook);
//                cui.Run();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;


////2-4번  TelphoneBook   IDisposable
//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    interface IFileIO
//    {
//        void WriteFile();
//        void ReadFile();
//    }
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }

//        public Person(string Name = "", string Phone = "")
//        {
//            this.Name = Name;
//            this.Phone = Phone;
//        }
//        public override string ToString()
//        {
//            return $"{Name} , {Phone}";
//        }

//    }
//    class TelphoneBook : IControllerIO, IDisposable
//    {
//        List<Person> phoneList = new List<Person>();
//        public TelphoneBook()
//        {
//            try
//            {
//                BinaryFormatter formatter = new BinaryFormatter();
//                using (FileStream fstream = new FileStream("Telphonbook.ati", FileMode.Open))
//                {
//                    phoneList = (List<Person>)formatter.Deserialize(fstream); //as List<Person>;
//                    Console.WriteLine("Data 복원 완료");
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//        public void Add()    //public static void Add() --> 인스턴스 : tpbook tpbook2  --> Add를 중복해서 만들수있기에 static 으로 쓰면 안된다 
//        {
//            try
//            {
//                Console.Write("이름 입력:");
//                string name = Console.ReadLine();
//                Console.WriteLine("전화 입력");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//                Console.WriteLine("등록되었습니다");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine($"예외 발생 :{e} ");
//            }
//        }
//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine($"{per}");
//            });
//        }
//        public void Search()   //linq 메서드 사용
//        {
//            Console.Write("이름 입력:");
//            string name = Console.ReadLine();
//            var subList = phoneList.Where((per) => per.Name == name);
//            Console.WriteLine("찾은 모든 결과");
//            foreach (var per in subList)
//            {
//                Console.WriteLine($"{per}");
//            }
//        }
//        public void Remove()
//        {
//            Console.Write("이름 입력:");
//            string name = Console.ReadLine();

//            Person per = phoneList.Where((p) => p.Name == name).FirstOrDefault();
//            if (phoneList.Remove(per))
//                Console.WriteLine("삭제완료");
//            else
//                Console.WriteLine("삭제실패");
//        }
//        public void Dispose()
//        {
//            Console.WriteLine("파일출력");
//            BinaryFormatter formatter = new BinaryFormatter();
//            using (FileStream fstream = new FileStream("Telphonbook.ati", FileMode.Create))
//            {
//                formatter.Serialize(fstream, phoneList);
//                Console.WriteLine("파일 데이터 저장 완료");
//            }
//        }
//    }
//    static class Helper // 인수가 없으면 static으로 생성
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("===============");
//            Console.WriteLine("1.전화번호 등록");
//            Console.WriteLine("2.전화번호 출력");
//            Console.WriteLine("3.전화번호 검색");
//            Console.WriteLine("4.전화번호 삭제");
//            Console.WriteLine("0.프로그램 종료");
//            Console.WriteLine("===============");
//            Console.WriteLine();
//        }
//    }
//    class CUI
//    {
//        IControllerIO io;       //확장에는 열려있고 수정에는 닫혀있다.
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }
//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        {
//                            io.Add();
//                        }
//                        break;
//                    case "2":
//                        {
//                            io.Print();
//                        }
//                        break;
//                    case "3":
//                        {
//                            io.Search();
//                        }
//                        break;
//                    case "4":
//                        {
//                            io.Remove();
//                        }
//                        break;
//                    case "0":
//                        {
//                            run = false;
//                        }
//                        break;

//                    default:
//                        break;
//                }
//            }
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            using (TelphoneBook tpb = new TelphoneBook())        //using 뒤 () -> 파일 복원, 파일출력하는 작업만
//            {
//                CUI cui = new CUI(tpb);
//                cui.Run();
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;

//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    //interface IFileIO
//    //{
//    //    void writeFile();
//    //    void ReadFilee();
//    //}
//    [Serializable]
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }
//        public Person(string n = "", string ph = "")
//        {
//            Name = n;
//            Phone = ph;
//        }
//        public override string ToString()
//        {
//            return $"name : {Name}, phone : {Phone}";
//        }
//    }

//    class TelphoneBook : IControllerIO/*, IFileIO*/ , IDisposable
//    {
//        List<Person> phoneList = new List<Person>();

//        public TelphoneBook()
//        {
//            //파일 만드는 작업 완성하는 작업
//            BinaryFormatter bFormat = new BinaryFormatter();
//            using(FileStream fStream = new FileStream("telphonebook.ati",FileMode.Open)
//            {
//                phoneList = (List<Person>)bFormat.Deserialize(fStream);
//                Console.WriteLine("데이터 복원 완료!");
//            }
//        }
//        public void Add()
//        {
//            try
//            {
//                Console.WriteLine("이름 입력:");
//                string name = Console.ReadLine();
//                Console.WriteLine("전화 입력:");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("예외 : {0}", e.Message);
//            }
//        }

//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine("{0}", per);
//            });
//        }

//        public void Search()
//        {
//            var subList = phoneList.Where((per) => per.Name == "홍길동");
//            Console.WriteLine("찾은 모든 전화 번호 : ");
//            foreach (var per in subList)
//                Console.WriteLine(per);
//        }

//        public void Remove()
//        {
//            Person per = phoneList.Where((p) => p.Name == "홍길동").FirstOrDefault();
//            if (phoneList.Remove(per))
//                Console.WriteLine("삭제 성공 !");
//            else
//                Console.WriteLine("삭제 실패 !");
//        }

//        public void Dispose()
//        {
//        BinaryFormatter bFormat = new BinaryFormatter();
//            using(FileStream fStream = new FileStream("telphonebook.ati", FileMode.Create))
//        {
//            bFormat.Serialize(fStream, phoneList);
//            Console.WriteLine("데이터 저장 완료 !");
//        }
//        }
//    }

//    static class Helper
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("==================");
//            Console.WriteLine("1. 전화번호 등록");
//            Console.WriteLine("2. 전화번호 출력");
//            Console.WriteLine("3. 전화번호 검색");
//            Console.WriteLine("4. 전화번호 삭제");
//            Console.WriteLine("0. 프로그램 종료");
//            Console.WriteLine("==================");
//            Console.WriteLine();
//        }
//    }
//    class CUI       //open 확장에는 열려있고 수정에는 닫혀있다.
//    {
//        IControllerIO io;
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }

//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        io.Add();
//                        break;
//                    case "2":
//                        io.Print();
//                        break;
//                    case "3":
//                        io.Search();
//                        break;
//                    case "4":
//                        io.Remove();
//                        break;
//                    case "0":
//                        run = false;
//                        break;
//                } 
//            }

//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//        using (TelphoneBook tpbook = new TelphoneBook())
//        {
//            CUI cui = new CUI(tpbook);

//            cui.Run();
//        }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    //interface IFileIO
//    //{
//    //    void writeFile();
//    //    void ReadFilee();
//    //}
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }
//        public Person(string n = "", string ph = "")
//        {
//            Name = n;
//            Phone = ph;
//        }
//        public override string ToString()
//        {
//            return $"name : {Name}, phone : {Phone}";
//        }
//    }
//    class TelphoneBook : IControllerIO/*, IFileIO*/
//    {
//        List<Person> phoneList = new List<Person>();
//        public void Add()
//        {
//            try
//            {
//                Console.WriteLine("이름 입력:");
//                string name = Console.ReadLine();
//                Console.WriteLine("전화 입력:");
//                string phone = Console.ReadLine();
//                phoneList.Add(new Person(name, phone));
//            }
//            catch(Exception e)
//            {
//                Console.WriteLine("예외 : {0}", e.Message);
//            }
//        }

//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine("{0}", per);
//            });
//        }

//        public void Search()
//        {
//            var subList = phoneList.Where((per) => per.Name == "홍길동");
//            Console.WriteLine("찾은 모든 전화 번호 : ");
//            foreach (var per in subList)
//                Console.WriteLine(per);
//        }

//        public void Remove()
//        {
//            Person per = phoneList.Where((p) => p.Name == "홍길동").FirstOrDefault();
//            if(phoneList.Remove(per))
//                Console.WriteLine("삭제 성공 !");
//            else
//                Console.WriteLine("삭제 실패 !");
//        }
//    }

//    static class Helper
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("==================");
//            Console.WriteLine("1. 전화번호 등록");
//            Console.WriteLine("2. 전화번호 출력");
//            Console.WriteLine("3. 전화번호 검색");
//            Console.WriteLine("4. 전화번호 삭제");
//            Console.WriteLine("0. 프로그램 종료");
//            Console.WriteLine("==================");
//            Console.WriteLine();
//        }
//    }
//    class CUI       //open 확장에는 열려있고 수정에는 닫혀있다.
//    {
//        IControllerIO io;
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }

//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        io.Add();
//                        break;
//                    case "2":
//                        io.Print();
//                        break;
//                    case "3":
//                        io.Search();
//                        break;
//                    case "4":
//                        io.Remove();
//                        break;
//                    case "0":
//                        run = false;
//                        break;
//                }
//            }

//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            TelphoneBook tpbook = new TelphoneBook();
//            CUI cui = new CUI(tpbook);

//            cui.Run();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    //interface IFileIO
//    //{
//    //    void writeFile();
//    //    void ReadFilee();
//    //}
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }
//        public Person(string n = "", string ph = "")
//        {
//            Name = n;
//            Phone = ph;
//        }
//        public override string ToString()
//        {
//            return $"name : {Name}, phone : {Phone}";
//        }
//    }
//    class TelphoneBook : IControllerIO/*, IFileIO*/
//    {
//        List<Person> phoneList = new List<Person>();
//        public void Add()
//        {
//            phoneList.Add(new Person("홍길동", "010-1122-3456"));
//        }

//        public void Print()
//        {
//            phoneList.ForEach((per) =>
//            {
//                Console.WriteLine("{0}", per);
//            });
//        }

//        public void Search()
//        {
//            var subList = phoneList.Where((per) => per.Name == "홍길동");
//            Console.WriteLine("찾은 모든 전화 번호 : ");
//            foreach(var per in subList)
//                Console.WriteLine(per);
//        }

//        public void Remove()
//        {
//            Person per = phoneList.Where((p) => p.Name == "홍길동").FirstOrDefault();
//            phoneList.Remove(per);
//        }
//    }

//    static class Helper
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("==================");
//            Console.WriteLine("1. 전화번호 등록");
//            Console.WriteLine("2. 전화번호 출력");
//            Console.WriteLine("3. 전화번호 검색");
//            Console.WriteLine("4. 전화번호 삭제");
//            Console.WriteLine("0. 프로그램 종료");
//            Console.WriteLine("==================");
//            Console.WriteLine();
//        }
//    }
//    class CUI       //open 확장에는 열려있고 수정에는 닫혀있다.
//    {
//        IControllerIO io;
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }

//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        io.Add();
//                        break;
//                    case "2":
//                        io.Print();
//                        break;
//                    case "3":
//                        io.Search();
//                        break;
//                    case "4":
//                        io.Remove();
//                        break;
//                    case "0":
//                        run = false;
//                        break;
//                }
//            }

//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            TelphoneBook tpbook = new TelphoneBook();
//            CUI cui = new CUI(tpbook);

//            cui.Run();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    //interface IFileIO
//    //{
//    //    void writeFile();
//    //    void ReadFilee();
//    //}
//    class Person
//    {
//        public string Name { get; set; }
//        public string Phone { get; set; }
//        public Person(string n ="", string ph ="")
//        {
//            Name = n;
//            Phone = ph;
//        }
//        public override string ToString()
//        {
//            return $"name : {Name}, phone : {Phone}";
//        }
//    }
//    class TelphoneBook : IControllerIO/*, IFileIO*/
//    {
//        List<Person> phoneList = new List<Person>();
//        public void Add()
//        {
//            Console.WriteLine("등록");
//        }

//        public void Print()
//        {
//            Console.WriteLine("출력");
//        }

//        public void Search()
//        {
//            Console.WriteLine("검색");
//        }

//        public void Remove()
//        {
//            Console.WriteLine("삭제");
//        }
//    }

//    static class Helper
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("==================");
//            Console.WriteLine("1. 전화번호 등록");
//            Console.WriteLine("2. 전화번호 출력");
//            Console.WriteLine("3. 전화번호 검색");
//            Console.WriteLine("4. 전화번호 삭제");
//            Console.WriteLine("0. 프로그램 종료");
//            Console.WriteLine("==================");
//            Console.WriteLine();
//        }
//    }
//    class CUI       //open 확장에는 열려있고 수정에는 닫혀있다.
//    {
//        IControllerIO io;
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }

//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        io.Add();
//                        break;
//                    case "2":
//                        io.Print();
//                        break;
//                    case "3":
//                        io.Search();
//                        break;
//                    case "4":
//                        io.Remove();
//                        break;
//                    case "0":
//                        run = false;
//                        break;
//                }
//            }

//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            TelphoneBook tpbook = new TelphoneBook();
//            CUI cui = new CUI(tpbook);

//            cui.Run();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ex220720
//{
//    interface IControllerIO
//    {
//        void Add();
//        void Print();
//        void Search();
//        void Remove();
//    }
//    //interface IFileIO
//    //{
//    //    void writeFile();
//    //    void ReadFilee();
//    //}
//    class TelphoneBook : IControllerIO/*, IFileIO*/
//    {
//        public void Add()
//        {
//            Console.WriteLine("등록");
//        }

//        public void Print()
//        {
//            Console.WriteLine("출력");
//        }

//        public void Search()
//        {
//            Console.WriteLine("검색");
//        }

//        public void Remove()
//        {
//            Console.WriteLine("삭제");
//        }
//    }

//    static class Helper
//    {
//        public static void Menu()
//        {
//            Console.WriteLine("==================");
//            Console.WriteLine("1. 전화번호 등록");
//            Console.WriteLine("2. 전화번호 출력");
//            Console.WriteLine("3. 전화번호 검색");
//            Console.WriteLine("4. 전화번호 삭제");
//            Console.WriteLine("0. 프로그램 종료");
//            Console.WriteLine("==================");
//            Console.WriteLine();
//        }
//    }
//    class CUI       //open 확장에는 열려있고 수정에는 닫혀있다.
//    {
//        IControllerIO io;
//        public CUI(IControllerIO io)
//        {
//            this.io = io;
//        }

//        public void Run()
//        {
//            Helper.Menu();
//            bool run = true;
//            while (run)
//            {
//                switch (Console.ReadLine())
//                {
//                    case "1":
//                        io.Add();
//                        break;
//                    case "2":
//                        io.Print();
//                        break;
//                    case "3":
//                        io.Search();
//                        break;
//                    case "4":
//                        io.Remove();
//                        break;
//                    case "0":
//                        run = false;
//                        break;
//                }
//            }

//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            TelphoneBook tpbook = new TelphoneBook();
//            CUI cui = new CUI(tpbook);

//            cui.Run();
//        }
//    }
//}
