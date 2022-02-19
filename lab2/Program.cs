using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello World!";
            Console.WriteLine(text + "\n");
            MyDoubleLinkedList myList = new MyDoubleLinkedList();
            foreach(char c in text)
            {
                myList.Append(c);
            }
            Console.WriteLine(myList.GetChar(2).ToString() + myList.GetChar(7).ToString() + myList.GetChar(8).ToString() + myList.GetChar(10).ToString());
        }
    }
}
