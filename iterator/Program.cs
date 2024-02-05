using System.Collections.Generic;
//using static iterator.linkedlist<T>;

namespace iterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in NumberIterator(20))
            {
                //  arg.Dumb();
                // Console.WriteLine(arg);
            }
            linkedlist<int> list = new linkedlist<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Dump();
           var iterator= list.Iterator ;
            while (!iterator.complete)
            {
                var n= iterator.Next() ;
                Console.WriteLine(n);
                n.Dump() ;
              //   iterator.Next() ;
            }

        }
        static public IEnumerable<int> NumberIterator(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return i;
            }
        }
    }
    public class linkedlist<T>
    {
        public Node _node { get; set; }
        public class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
            public void Append(T value)
            {
                if (Next == null)
                {
                    Next = new Node { Value = value };//public property
                    return;
                }
                Next.Append(value);
            }
            public T Get(int i) => i == 0 ? Value : Next.Get(--i);

           
        }

        public void Add(T value)
        {
            if (_node == null)
            {
                _node = new Node { Value = value };
                return;
            }
            _node.Append(value);
            }
        public T Get(int i)=>_node.Get(i);
          public linkedIterator Iterator => new linkedIterator(_node);
        public class linkedIterator
        {
            Node _root;
            Node _current;
            public linkedIterator(Node root) => _root = _current = root;
            public T Next()
            {
                var value = _current.Value;
                _current=_current.Next;
                return value;
            }

            public bool complete => _current == null;

            public void Reset()
            {
                _current = _root;
            }
        }
    }

  
}