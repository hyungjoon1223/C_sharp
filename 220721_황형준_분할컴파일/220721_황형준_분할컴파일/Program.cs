using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _220721_황형준_분할컴파일
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
