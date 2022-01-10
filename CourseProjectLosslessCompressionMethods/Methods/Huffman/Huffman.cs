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
        byte[] data; //  входные данные
        
        
        public void CompressFile(string dataFilename)
        {
            byte[] data = File.ReadAllBytes(dataFilename);
            byte[] arhData = CompressBytes(data);

            File.WriteAllBytes($"{dataFilename}.huf", arhData);
        }
        public byte[] Compress(byte[] data)
        {
            GetFreqsSymbols(data);
            root = CreateHuffmanTree();
            CreateHuffmanCodes();
            byte[] compressedBytes = CompressBytes(data);
            // byte[] head = CreateHeader(data.Length);
            return compressedBytes;
        }

        //private byte[] CreateHeader(int dataLength)
        //{
        //    List<byte> head = new List<byte>();
        //    head.Add((byte)(dataLength        & 255));
        //    head.Add((byte)((dataLength  >> 8)& 255));
        //    head.Add((byte)((dataLength  >> 16)& 255));
        //    head.Add((byte)((dataLength  >> 24)& 255));
        //}

         byte[] CompressBytes(byte[] data)
        {
            List<byte> bits = new List<byte>();
            byte sum = 0;
            byte bit = 1;
            foreach(byte symbol in data)
            {
                foreach(char c in codes[symbol])
                {
                    if(c == '1')
                    {
                        sum |= bit;
                    }
                    if(bit < 128)
                    {
                        bit <<= 1;
                    }
                    else
                    {
                        bits.Add(sum);
                        sum = 0;
                        bit = 1;
                    }
                }
            }
            if (bit > 1)
            {
                bits.Add(sum);
            }
            return bits.ToArray();
        }
        private void CreateHuffmanCodes()
        {
            Next(root, "");
            void Next(Node node, string code)
            {
                if(node.bit0 == null)
                {
                    codes[node.symbol] = code;
                }
                else
                {
                    Next(node.bit0, code + '0');
                    Next(node.bit1, code + '1');
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
