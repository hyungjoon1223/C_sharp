using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 객체지향_설계_원칙
{
     
    internal class Program
    {
        class FlowController
        {
            FileDataReader fdr;
            public FileDataReader _fdr
            {
                get { return fdr; }
                set { fdr = value; }
            }

            public FlowController(FileDataReader _fdr)
            {
                this.fdr = _fdr;
            }
            public void Flow()
            {
                Console.WriteLine("flow : {0}", fdr.Read());
            }
        }
        //저수준 모듈 클래스
        class FileDataReader
        {
            public string Read()
            {
                return "FileDataReader.Read()";
            }
        }
        static void Main(string[] args)
        {
            FlowController fc = new FlowController(new FileDataReader());
            fc.Flow();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace 객체지향_설계_원칙
//{
//    internal class Program
//    {
//        //고수준 모듈에 작성한 클래스
//        class FlowController
//        {
//            ByteSource bs;
//            public ByteSource BS
//            {
//                get { return bs; }
//                set { bs = value; }
//            }

//            public FlowController(ByteSource bs)
//            {
//                this.bs = bs;
//            }
//            public void Flow()
//            {
//                Console.WriteLine("flow : {0}", bs.Read());
//            }
//        }
//        interface ByteSource
//        {
//            string Read();
//        }
//        //저수준 모듈 클래스
//        class FileDataReader : ByteSource
//        {
//            public string Read()
//            {
//                return "FileDataReader.Read()";
//            }
//        }
//        static void Main(string[] args)
//        {
//            FlowController fc = new FlowController(new FileDataReader());
//            fc.Flow();
//        }
//    }
//}

