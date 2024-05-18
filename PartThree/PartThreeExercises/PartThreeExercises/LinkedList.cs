using System;

namespace PartThreeExercises
{
    public class LinkedList
    {

        private Node _head;
        private Node _tail;
        private Node _maxNode;
        private Node _minNode;
        public LinkedList()
        {
            _head = null;
            _tail = null;
        }
        public void PrintList()
        {
            Node current = _head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
        public void Append (int number)
        {
            Node node = new Node(number, null);
            if (_head == null )
            {
                _head = node;
                _tail = node;
                _maxNode = node;
                _minNode = node;
            }
            else
            { 
                if (number < _minNode.Value)
                {
                    _minNode = node;
                } 
                if(number > _maxNode.Value)
                {
                    _maxNode = node; 
                }
                _tail.Next = node;
                _tail = node;
            }
        }
        public void Prepend (int number)
        {
            Node node = new Node(number, _head);
            _head = node;
        }
        public int Pop()
        { 
            if (_head == null)
            {
                throw new InvalidOperationException("Error - LinkedList is empty");
            }
            Node position = _head;
            if (position.Next == null)
            {
                _head = null; 
                return position.Value; 
            }
            while (position.Next != null && position.Next.Next != null)
            {
                position = position.Next;
            }
            int returnValue = position.Next.Value;
            position.Next = null;
            return returnValue;
        } 
        public int Unqueue()
        { 
            if (_head == null)
            {
                throw new InvalidOperationException("LinkedList is empty"); 
            }
            Node result = _head;
            _head = _head.Next;
            result.Next = null;
            return result.Value;
        }
        public IEnumerable<int> ToList()
        {
            List<int> values = new List<int>();
            Node current = _head;
            while(current != null)
            {
                values.Add(current.Value);
                current = current.Next;

            }
            return values;
        }
        public bool IsCircle()
        {
            Node current = _head;
            bool result = false;
            while(current != null)
            {
                if (current == _head)
                {
                    result = true;
                    break;
                }
                current = current.Next;
            }
            return result;
        }
        public void Sort()
        {
            IEnumerable<int> sorted = ToList().OrderBy(x => x);
            _head = null;
            _tail = null;
            foreach (int item in sorted)
            {
                Append(item);
            }
            _maxNode = _head;
            _minNode = _tail;
        } 
        public Node GetMaxNode()
        {
            return _maxNode; 
        }
        public Node GetMinNode()
        {
            return _minNode; 
        }
    }
}
