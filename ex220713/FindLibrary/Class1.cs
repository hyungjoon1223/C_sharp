using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLibrary
{
    public static class Algorithm   //public을 써야 외부에서 사용가능 !!! internal이 되는거임 여기서만 쓸 수 있는
    {
        public static int Find<T>(T[] arr, Predicate<T> pred)
        {
            for (int i = 0; i < arr.Length; ++i)
                if (pred(arr[i]))
                    return i;
            return -1;
        }
    }
}