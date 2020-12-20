using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDCodeCore;
using System.Text;
using System.IO;
using CommandLine;

namespace BinaryEncodeDecode
{
    class Program
    {
        public class Options
        {
            [Option('e', "encode", HelpText = "编码输入文件")]
            public string EncodeFile { get; set; }
            [Option('d', "decode", HelpText = "解码输入文件")]
            public string DecodeFile { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
            Console.Read();
        }

        static void Run(Options options)
        {
            if (!string.IsNullOrEmpty(options.EncodeFile))
            {
                EncodeFile(options.EncodeFile);
            }
            if (!string.IsNullOrEmpty(options.DecodeFile))
            {
                DecodeFile(options.DecodeFile);
            }
        }

        static void EncodeFile(string file_path)
        {
            if (!File.Exists(file_path))
            {
                return;
            }
            EDcodeHelper.Encode(file_path);
            Console.WriteLine($"success to encode file: {file_path}");
        }

        static void DecodeFile(string file_path)
        {
            if (!File.Exists(file_path))
            {
                return;
            }
            EDcodeHelper.Decode(file_path);
            Console.WriteLine($"success to decode file: {file_path}");
        }
    }
}
