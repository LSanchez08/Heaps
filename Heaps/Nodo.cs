using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> RightNode { get; set; }
        public Node<T> ParentNode { get; set; }
        public Node<T> LeftNode { get; set; }
        public int Height { get; }
    }
}
