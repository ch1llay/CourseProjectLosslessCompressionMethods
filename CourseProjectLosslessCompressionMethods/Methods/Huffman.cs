using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLosslessCompressionMethods.Methods.Huffman
{
    class Node
    {
        public int Frequence { get; set; }
        private byte Symbol { get; set; }
        private Node leftChild;
        private Node rightChild;
        public Node() { }
        public Node(byte symbol, int frequence)
        {
            Symbol = symbol;
        }
        public void AddChild(Node newNode)
        {
            if (leftChild == null)
            {
                leftChild = newNode;
            }
            else
            {
                if (leftChild.Frequence <= newNode.Frequence)
                {
                    rightChild = newNode;
                }
                else
                {
                    rightChild = leftChild;
                    leftChild = newNode;
                }
                Frequence += newNode.Frequence;
            }
        }
    }
    class BinaryTree
    {
        private Node root;
        public BinaryTree()
        {
            root = new Node();
        }
        public BinaryTree(Node node)
        {
            root = node;
        }
    }
    class Huffman
    {
        Dictionary<byte, float> tabels = new Dictionary<byte, float>();
        Huffman(string path)
        {
            byte[] image = File.ReadAllBytes(path);
            PrepareDictionary();
            GetFreqSymbol(image);
        }
        void PrepareDictionary()
        {
            for (byte i = 0; i < byte.MaxValue; i++)
            {
                tabels.Add(i, 0);
            }
        }
        void GetFreqSymbol(byte[] bytes)
        {
            bytes = bytes.OrderBy(x => x).ToArray();
            for (int i = 0; i < bytes.Length; i++)
            {
                if (tabels.ContainsKey(bytes[i]))
                {
                    tabels[bytes[i]]++;
                }
            }
            foreach (var pair in tabels.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
        }
    }
}
