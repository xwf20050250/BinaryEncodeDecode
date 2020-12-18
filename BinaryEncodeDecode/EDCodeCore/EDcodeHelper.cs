using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCodeCore
{
    public static class EDcodeHelper
    {
        private static byte s_factor = 123;

        public static void Config(byte factor)
        {
            s_factor = factor;
        }

        public static byte Encode(byte inbyte)
        {
            inbyte = (byte)(0xff & ((inbyte >> 6) | (inbyte << 2)));
            return (byte)(inbyte ^ s_factor);
        }

        public static byte Decode(byte inbyte)
        {
            inbyte ^= s_factor;
            return (byte)(0xff & ((inbyte << 6) | (inbyte >> 2)));
        }

        public static void Decode(byte[] inoutbyte)
        {
            for (int i = 0; i < inoutbyte.Length; ++i)
            {
                inoutbyte[i] ^= s_factor;
                inoutbyte[i] = (byte)(0xff & ((inoutbyte[i] << 6) | (inoutbyte[i] >> 2)));
            }
        }
    }
}
