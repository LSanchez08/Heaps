using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    interface IHeap<T>
    {
        int Size { get; }

        bool IsEmpty();

        T Min();

        void Insert(T element);

        T RemoveMin();
    }
}
