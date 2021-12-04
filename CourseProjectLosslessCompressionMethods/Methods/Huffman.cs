using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLosslessCompressionMethods.Methods.Huffman
{
    class CodeTreeNode
    {
        public int Frequence { get; set; }
        private byte? Symbol { get; set; }
        private CodeTreeNode left;
        private CodeTreeNode right;
        public CodeTreeNode(byte? symbol, int frequence)
        {
            Symbol = symbol;
        }

        public CodeTreeNode(byte? symbol, int frequence, CodeTreeNode left, CodeTreeNode right)
        {
            Frequence = frequence;
            Symbol = symbol;
            this.left = left;
            this.right = right;
        }
    }

    class Huffman
    {
        Dictionary<byte, int> tabelsFrequencySymbols = new Dictionary<byte, int>();
        List<CodeTreeNode> codeTreeNodes = new List<CodeTreeNode>();
        CodeTreeNode tree;
        Huffman(string path)
        {
            byte[] file = File.ReadAllBytes(path);
            PrepareDictionary();
            GetFreqSymbol(file);
            PushNodesToList();
        }
        void PrepareDictionary()
        {
            for (Byte i = 0; i < Byte.MaxValue; i++)
            {
                tabelsFrequencySymbols.Add(i, 0);
            }
        }
        void GetFreqSymbol(byte[] bytes)
        {
            bytes = bytes.OrderBy(x => x).ToArray();
            for (int i = 0; i < bytes.Length; i++)
            {
                if (tabelsFrequencySymbols.ContainsKey(bytes[i]))
                {
                    tabelsFrequencySymbols[bytes[i]]++;
                }
            }
            foreach (var pair in tabelsFrequencySymbols.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
        }
        void PushNodesToList()
        {
            foreach(var pair in tabelsFrequencySymbols)
            {
                codeTreeNodes.Add(new CodeTreeNode(pair.Key, pair.Value));
            }
        }
        void BuildTreeForEncode()
        {
            while(codeTreeNodes.Count > 1)
            {
                codeTreeNodes = codeTreeNodes.OrderByDescending(x => x).ToList();

                CodeTreeNode right = codeTreeNodes[codeTreeNodes.Count-1]; 
                codeTreeNodes.RemoveAt(codeTreeNodes.Count - 1);

                CodeTreeNode left = codeTreeNodes[codeTreeNodes.Count - 1];
                codeTreeNodes.RemoveAt(codeTreeNodes.Count - 1);

                CodeTreeNode parent = new CodeTreeNode(null, left.Frequence + right.Frequence, left, right);
                codeTreeNodes.Add(parent);

            }
            tree = codeTreeNodes[0];
        }
        void Decode(List<byte> encoded)
        {
            List<byte> decoded = new List<byte>();

            
        }

    }
}
