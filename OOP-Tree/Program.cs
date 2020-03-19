using System;
using System.Collections.Generic;

namespace OOP_Tree
{
    class Tree
    {
        private readonly List<Node> _treeNodes;
        public Tree(Node root)
        {
            _treeNodes = new List<Node> {root};
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("index  | Left | Value | Right\n-----------------------------");
            for (int i = 0; i < _treeNodes.Count; i++)
            {
                string left = _treeNodes[i].GetLeft().ToString();
                if (left.Length == 1)
                {
                    left += " ";
                }
                string value = _treeNodes[i].GetValue().ToString("00");
                string right = _treeNodes[i].GetRight().ToString();
                string index = i.ToString("00");

                Console.WriteLine($"{index}:    |  {left}  |   {value}  |  {right}");
            }
        }

        public void AddNode(Node newNode)
        {
            _treeNodes.Add(newNode);
            int newNodeIndex = _treeNodes.Count - 1;
            
            bool searching = true;

            Node currentNode = _treeNodes[0];
            while (searching)
            {
                if (currentNode.GetLeft() == -1 && currentNode.GetRight() == -1)
                {
                    if (newNode.GetValue() > currentNode.GetValue())
                    {
                        currentNode.SetRight(newNodeIndex);
                        searching = false;
                    }
                    else
                    {
                        currentNode.SetLeft(newNodeIndex);
                        searching = false;
                    }
                }
                else
                {
                    if (newNode.GetValue() > currentNode.GetValue())
                    {
                        if (currentNode.GetRight() != -1)
                        {
                            currentNode = _treeNodes[currentNode.GetRight()];
                        }
                        else
                        {
                            currentNode.SetRight(newNodeIndex);
                            searching = false;
                        }
                    }
                    else
                    {
                        if (currentNode.GetLeft() != -1)
                        {
                            currentNode = _treeNodes[currentNode.GetLeft()];
                        }
                        else
                        {
                            currentNode.SetLeft(newNodeIndex);
                            searching = false;
                        }
                    }
                }
                
            }
        }

        public void InOrderTraversal()
        {
            Console.WriteLine("\n----- In Order Traversal -----");
            this.IOT(0);
        }
        public void IOT(int p)
        {
            if (_treeNodes[p].GetLeft() != -1)
            {
                IOT(_treeNodes[p].GetLeft());
            }
            Console.Write(_treeNodes[p].GetValue() + " - ");

            if (_treeNodes[p].GetRight() != -1)
            {
                IOT(_treeNodes[p].GetRight());
            }
        }
    }

    class Node
    {
        private readonly int _value;
        private int _leftPoint;
        private int _rightPoint;

        public Node(int newValue)
        {
            this._value = Convert.ToInt32(newValue);
            this._leftPoint = -1;
            this._rightPoint = -1;
        }

        public int GetLeft()
        {
            return this._leftPoint;
        }

        public int GetRight()
        {
            return this._rightPoint;
        }

        public int GetValue()
        {
            return this._value;
        }

        public void SetLeft(int value)
        {
            this._leftPoint = Convert.ToInt32(value);
        }

        public void SetRight(int value)
        {
            this._rightPoint = Convert.ToInt32(value);
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            
            Node N17 = new Node(17);
            Node N8 = new Node(8);
            Node N4 = new Node(4);
            Node N12 = new Node(12);
            Node N22 = new Node(22);
            Node N19 = new Node(19);
            Node N14 = new Node(14);
            Node N5 = new Node(5);
            Node N30 = new Node(30);
            Node N25 = new Node(25);
            Node N26 = new Node(26);

            Tree T = new Tree(N17);

            T.AddNode(N8);
            T.AddNode(N4);
            T.AddNode(N12);
            T.AddNode(N22);
            T.AddNode(N19);
            T.AddNode(N14);
            T.AddNode(N5);
            T.AddNode(N30);
            T.AddNode(N25);

            T.AddNode(N26);

            T.Show();
            
            T.InOrderTraversal();
            
        }
    }
}