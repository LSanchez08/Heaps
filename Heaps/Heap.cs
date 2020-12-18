using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class Heap<T> : IHeap<T> 
    {
        private int size;
        private int height;
        private Node<T> rootNode;


        public int Size { get => size; set => size = value; }
        public int Height { get => height; set => height = value; }
        public Node<T> RootNode { get => rootNode; private set => rootNode = value; }
        

        public void Insert(T element)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public T Min()
        {
            throw new NotImplementedException();
        }

        public T RemoveMin()
        {
            throw new NotImplementedException();
        }
    }
}
