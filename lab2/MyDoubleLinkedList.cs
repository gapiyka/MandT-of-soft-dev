using System;

namespace lab2
{
    public class Node
    {
        private char _element;
        private int _index;
        private Node _next;
        private Node _prev;

        //constructor
        public Node(char Element, int Index)
        {
            this._element = Element;
            this._index = Index;
        }
        //public acces to element
        public char Character
        {
            get { return _element; }
            set { _element = value; }
        }
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        public Node Next
        {
            get { return this._next; }
            set { this._next = value; }
        }
        public Node Prev
        {
            get { return this._prev; }
            set { this._prev = value; }
        }
    }

    public class MyDoubleLinkedList
    {
        private Node _head;
        private Node _tail;
        private int _listSize;

        public MyDoubleLinkedList()
        {
            _listSize = 0;
            _head = _tail = null;
        }

        public Node GetHeadNode()
        {
            return _head;
        }
        
        public Node GetTailNode()
        {
            return _tail;
        }

        public int Length()
        {
            return _listSize;
        }

        public void Append(char newElement)
        {
            Node newNode = new Node(newElement, _listSize);
            if (_head == null) _head = _tail = newNode;
            else
            {
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
            _listSize++;
        }

        public void Insert(char newElement, int index)
        {
            if (index < 0 || index >= _listSize)
            {
                throw new ArgumentException("Index is out of range. It should be greater than 0 and less than list size!");
            }
            else
            {
                Node tempNode = _head;
                while (tempNode.Index != index)
                {
                    tempNode = tempNode.Next;
                }
                tempNode.Character = newElement;
            }
        }

        public char Delete(int index)
        {
            if (index < 0 || index >= _listSize)
            {
                throw new ArgumentException("Index is out of range. It should be greater than 0 and less than list size!");
            }
            else
            {
                Node tempNode = _head;

                while (tempNode.Index != index)
                {
                    tempNode = tempNode.Next;
                }
                if (tempNode.Index != _head.Index) tempNode.Prev.Next = tempNode.Next;
                else _head = tempNode.Next;//check on head
                if (tempNode.Index != _tail.Index) tempNode.Next.Prev = tempNode.Prev;
                else _tail = tempNode.Prev;//check on tail
                _listSize--;
                ReorderIndex();
                return tempNode.Character;
            }
        }

        public void DeleteAll(char character)
        {
            Node tempNode = _head;

            while (tempNode.Index != _listSize)
            {
                if (tempNode.Character == character)
                {
                    if (tempNode.Index != _head.Index) tempNode.Prev.Next = tempNode.Next;
                    else _head = tempNode.Next;//check on head
                    if (tempNode.Index != _tail.Index) tempNode.Next.Prev = tempNode.Prev;
                    else _tail = tempNode.Prev;//check on tail
                    _listSize--;
                    ReorderIndex();
                }
                tempNode = tempNode.Next;
            }
        }

        public char GetChar(int index)
        {
            if (index < 0 || index >= _listSize)
            {
                throw new ArgumentException("Index is out of range. It should be greater than 0 and less than list size!");
            }
            else
            {
                Node tempNode = _head;

                while (tempNode.Index != index)
                {
                    tempNode = tempNode.Next;
                }
                return tempNode.Character;
            }
        }

        public MyDoubleLinkedList Clone()
        {
            MyDoubleLinkedList duplicate = new MyDoubleLinkedList();
            Node tempNode = _head;

            while (tempNode.Index != _listSize)
            {
                duplicate.Append(tempNode.Character);
                tempNode = tempNode.Next;
            }

            return duplicate;
        }

        public void Reverse()
        {
            Node tempNodeStart = _head;
            Node tempNodeEnd = _tail;
            int tempCounter = 0;
            char tempChar;

            while (tempCounter != MathF.Floor(_listSize / 2))
            {
                tempChar = tempNodeStart.Character;
                tempNodeStart.Character = tempNodeEnd.Character;
                tempNodeEnd.Character = tempChar;
                tempCounter++;
            }
        }

        public int FindFirst(char character)
        {
            Node tempNode = _head;
            int index = -1;
            while (tempNode.Index != _listSize)
            {
                if (tempNode.Character == character)
                {
                    index = tempNode.Index;
                    break;
                }
                tempNode = tempNode.Next;
            }
            return index;
        }

        public int FindLast(char character)
        {
            Node tempNode = _tail;
            int index = -1;
            while (tempNode.Prev != null)
            {
                if (tempNode.Character == character)
                {
                    index = tempNode.Index;
                    break;
                }
                tempNode = tempNode.Prev;
            }
            return index;
        }

        public void Clear()
        {
            Node tempNode = _tail;
            while (tempNode.Prev != null)
            {
                tempNode.Next = null;
                tempNode = tempNode.Prev;
            }
            _listSize = 0;
        }

        public void Extend(MyDoubleLinkedList list)
        {
            Node tempNode = _tail;
            while (list._listSize != 0)
            {
                Append(list.Delete(0));
            }
        }

        private void ReorderIndex()
        {
            Node tempNode = _head;
            int tempCounter = 0;
            while (tempNode.Index != _listSize)
            {
                tempNode.Index = tempCounter;
                tempNode = tempNode.Next;
                tempCounter++;
            }
        }
    }
}