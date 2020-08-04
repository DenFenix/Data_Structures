using Data_Structures.UsersLinkedList;
using System;


namespace Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {

            LinkedList<int> ll = new LinkedList<int>();
            ll.Add(1);
            ll.Add(2);
            Console.WriteLine(ll.Head.Value);
            Console.WriteLine(ll.Tail.Value);
        }
    }
}
