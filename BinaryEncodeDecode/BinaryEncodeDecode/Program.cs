using System;
using EDCodeCore;
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
            Parser.Default.ParseArguments<Options>(args)
                .WithNotParsed(error => throw new Exception("命令行参数解析错误"))
                .WithParsed(Run);
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
                Console.WriteLine($"not exists file: {file_path}");
                return;
            }
            try
            {
                string out_path = EDcodeHelper.Encode(file_path);
                Console.WriteLine($"successed to encode file: {file_path}, out: {out_path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"failed to encode file: {file_path}, error: {ex.Message}");
            }
        }

        static void DecodeFile(string file_path)
        {
            if (!File.Exists(file_path))
            {
                Console.WriteLine($"not exists file: {file_path}");
                return;
            }
            try
            {
                string out_path = EDcodeHelper.Decode(file_path);
                Console.WriteLine($"successed to decode file: {file_path}, out: {out_path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"failed to encode file: {file_path}, error: {ex.Message}");
            }
        }
    }
}
