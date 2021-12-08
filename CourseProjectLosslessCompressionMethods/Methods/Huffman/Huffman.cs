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
        public readonly byte? symbol;
        public readonly int freq;
        public readonly Node bit0;
        public readonly Node bit1;
        public byte? _01;

        public Node(byte symbol, int freq)
        {
            this.symbol = symbol;
            this.freq = freq;
        }

        public Node(Node bit0, Node bit1, int freq)
        {
            this.bit0 = bit0;
            this.bit1 = bit1;
            this.freq = freq;
        }
    }


    class Huffman
    {
        int[] freqs = new int[256]; // массив, он же словарь частот использования байт
        Node root;
        string[] codes = new string[256]; // массив кодов для каждого байта
        public void CompressFile(string dataFilename)
        {
            byte[] data = File.ReadAllBytes(dataFilename);
            byte[] arhData = CompressBytes(data);

            File.WriteAllBytes($"{dataFilename}.huf", arhData);
        }
        byte[] CompressBytes(byte[] data)
        {
            GetFreqsSymbols(data);
            root = CreateHuffmanTree();
            CreateHuffmanCodes();
            return data;
        }

        private void CreateHuffmanCodes()
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            StringBuilder currentCode = new StringBuilder();

            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                if (node._01 != null)
                {
                    if (node._01 == 0)
                        {
                        currentCode.Append('0');
                    }
                    else
                    {
                        currentCode.Append('1');
                    }
                }

                if (node.bit0 == null)
                {
                    codes[(int)node.symbol] = currentCode.ToString();
                    currentCode.Clear();
                }
                else
                {
                    stack.Push(node.bit1);
                    stack.Push(node.bit0);
                }

            }


        }

        void GetFreqsSymbols(byte[] data)
        {
            foreach (byte d in data)
            {
                freqs[d]++;
            }
        }

        private Node CreateHuffmanTree()
        {
            PriorityQueue<Node> pq = new PriorityQueue<Node>();
            for (int j = 0; j < 256; j++)
            {
                if (freqs[j] > 0)
                {
                    pq.Enqueue(freqs[j], new Node((byte)j, freqs[j]));
                }
            }
            while (pq.Size > 1)
            {
                Node bit0 = pq.Dequeue();
                Node bit1 = pq.Dequeue();
                bit0._01 = 0;
                bit1._01 = 1;
                int freqSum = bit0.freq + bit1.freq;
                Node parent = new Node(bit0, bit1, freqSum);
                pq.Enqueue(freqSum, parent);
            }
            return pq.Dequeue();
        }

        //void PushNodesToList()
        //{
        //    foreach(var pair in tabelsFrequencySymbols)
        //    {
        //        codeTreeNodes.Add(new CodeTreeNode(pair.Key, pair.Value));
        //    }
        //}
        //void BuildTreeForEncode()
        //{
        //    while(codeTreeNodes.Count > 1)
        //    {
        //        codeTreeNodes = codeTreeNodes.OrderByDescending(x => x).ToList();

        //        CodeTreeNode right = codeTreeNodes[codeTreeNodes.Count-1]; 
        //        codeTreeNodes.RemoveAt(codeTreeNodes.Count - 1);

        //        CodeTreeNode left = codeTreeNodes[codeTreeNodes.Count - 1];
        //        codeTreeNodes.RemoveAt(codeTreeNodes.Count - 1);

        //        CodeTreeNode parent = new CodeTreeNode(null, left.Frequence + right.Frequence, left, right);
        //        codeTreeNodes.Add(parent);

        //    }
        //    tree = codeTreeNodes[0];
        //}

        //void Decode(List<byte> encoded)
        //{
        //    List<byte> decoded = new List<byte>();


        //}

    }
}
