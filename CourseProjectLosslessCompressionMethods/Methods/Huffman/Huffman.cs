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
        public readonly byte symbol;
        public readonly int freq;
        public readonly Node bit0;
        public readonly Node bit1;

        public Node(byte symbol, int freq)
        {
            this.symbol = symbol;
            this.freq = freq;
        }

        public Node(int freq, Node bit0, Node bit1)
        {
            this.freq = freq;
            this.bit0 = bit0;
            this.bit1 = bit1;
        }
    }


    class Huffman
    {
        List<Node> codeTreeNodes = new List<Node>();
        Node root;
        int[] freqs = new int[256]; // массив, он же словарь частот использования байт
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
            return data;
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
            return null;
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
