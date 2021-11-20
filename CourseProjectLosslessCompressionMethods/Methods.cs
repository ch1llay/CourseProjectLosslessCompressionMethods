using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLosslessCompressionMethods
{
    class Methods
    {
        static Dictionary<byte, float> HuffmansCodes = new Dictionary<byte, float>();
        static void Main()
        {
            byte[] image = File.ReadAllBytes("image.jpg");
            PrepareDictionary();
            GetFreqSymbol(image);

        }

        static void PrepareDictionary()
        {
            for (byte i = 0; i < byte.MaxValue; i++)
            {
                HuffmansCodes.Add(i, 0);
            }
        }
        static void GetFreqSymbol(byte[] bytes)
        {
            bytes = bytes.OrderBy(x => x).ToArray();
            for (int i = 0; i < bytes.Length; i++)
            {
                if (HuffmansCodes.ContainsKey(bytes[i]))
                {
                    HuffmansCodes[bytes[i]]++;
                }
            }
            for (int i = 0; i < bytes.Length; i++)
            {
                if (HuffmansCodes.ContainsKey(bytes[i]))
                {
                    HuffmansCodes[bytes[i]] /= bytes.Length;
                }
            }
            foreach (var pair in HuffmansCodes.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
        }
    }
}
