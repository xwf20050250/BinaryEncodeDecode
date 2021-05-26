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
        private static byte s_factor = 213;

        public static void Config(byte factor)
        {
            s_factor = factor;
        }

        public static byte Encode(byte in_byte)
        {
            in_byte = (byte)(0xff & ((in_byte >> 6) | (in_byte << 2)));
            return (byte)(in_byte ^ s_factor);
        }

        public static byte[] Encode(byte[] inout_bytes)
        {
            for (int i = 0; i < inout_bytes.Length; i++)
            {
                inout_bytes[i] = (byte)(0xff & ((inout_bytes[i] >> 6) | (inout_bytes[i] << 2)));
                inout_bytes[i] ^= s_factor;
            }
            return inout_bytes;
        }

        /// <summary> return out path </summary>
        public static string Encode(string in_path, string out_path = "")
        {
            if (!File.Exists(in_path))
            {
                throw new Exception($"file not exists: {in_path}");
            }
            if (string.IsNullOrEmpty(out_path))
            {
                out_path = in_path;
            }
            byte[] fbyts = File.ReadAllBytes(in_path);
            Encode(fbyts);
            File.WriteAllBytes(out_path, fbyts);
            return out_path;
        }

        public static byte Decode(byte in_byte)
        {
            in_byte ^= s_factor;
            return (byte)(0xff & ((in_byte << 6) | (in_byte >> 2)));
        }

        public static byte[] Decode(byte[] inout_bytes)
        {
            for (int i = 0; i < inout_bytes.Length; ++i)
            {
                inout_bytes[i] ^= s_factor;
                inout_bytes[i] = (byte)(0xff & ((inout_bytes[i] << 6) | (inout_bytes[i] >> 2)));
            }
            return inout_bytes;
        }

        /// <summary> return out path </summary>
        public static string Decode(string in_path, string out_path = "")
        {
            if (!File.Exists(in_path))
            {
                throw new Exception($"file not exists: {in_path}");
            }
            if (string.IsNullOrEmpty(out_path))
            {
                out_path = in_path;
            }
            byte[] fbyts = File.ReadAllBytes(in_path);
            Decode(fbyts);
            File.WriteAllBytes(out_path, fbyts);
            return out_path;
        }

        /// <summary> 直接返回解谜内容 </summary>
        public static string DecodeContent(string in_path)
        {
            if (!File.Exists(in_path))
            {
                throw new Exception($"file not exists: {in_path}");
            }
            byte[] fbyts = File.ReadAllBytes(in_path);
            Decode(fbyts);
            return Encoding.UTF8.GetString(fbyts);
        }
    }
}
