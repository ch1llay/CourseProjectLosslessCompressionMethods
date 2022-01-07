using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLosslessCompressionMethods.Methods.LZ77
{
    public class BitList
    {
        List<byte> bits = new List<byte>();
        byte bit;
        byte sum;

        public BitList()
        {
            bit = 128;
            sum = 0;
        }

        public void Write(bool c)
        {
            if (c)
            {
                sum |= bit;
            }
            if (bit > 0)
            {
                bit >>= 1;
            }
            if (bit == 0)
            {
                bits.Add(sum);
                sum = 0;
                bit = 128;
            }

        }

        public void Write(byte n)
        {
            for (int i = 7; i >= 0; i--)
            {
                Write((n >> i & 1) > 0 ? true : false);
            }
        }
        public byte[] GetBytes()
        {
            if (sum > 0)
            {
                bits.Add(sum);
            }
            return bits.ToArray();
        }
    }
}
