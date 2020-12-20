using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public static void Encode(byte[] inoutbytes)
        {
            for (int i = 0; i < inoutbytes.Length; i++)
            {
                inoutbytes[i] = (byte)(0xff & ((inoutbytes[i] >> 6) | (inoutbytes[i] << 2)));
                inoutbytes[i] ^= s_factor;
            }
        }

        public static string Encode(string in_path)
        {
            string out_path = "";
            if (File.Exists(in_path))
            {
                throw new Exception($"file not exists: {in_path}");
            }
            out_path = $"{in_path}_encode";
            byte[] fbyts = File.ReadAllBytes(in_path);
            Encode(fbyts);
            File.WriteAllBytes(out_path, fbyts);
            return out_path;
        }

        public static byte Decode(byte inbyte)
        {
            inbyte ^= s_factor;
            return (byte)(0xff & ((inbyte << 6) | (inbyte >> 2)));
        }

        public static void Decode(byte[] inoutbytes)
        {
            for (int i = 0; i < inoutbytes.Length; ++i)
            {
                inoutbytes[i] ^= s_factor;
                inoutbytes[i] = (byte)(0xff & ((inoutbytes[i] << 6) | (inoutbytes[i] >> 2)));
            }
        }

        public static string Decode(string in_path)
        {
            string out_path = "";
            if (File.Exists(in_path))
            {
                throw new Exception($"file not exists: {in_path}");
            }
            out_path = $"{in_path}_decode";
            byte[] fbyts = File.ReadAllBytes(in_path);
            Decode(fbyts);
            File.WriteAllBytes(out_path, fbyts);
            return out_path;
        }
    }
}
