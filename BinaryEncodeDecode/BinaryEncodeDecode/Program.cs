using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDCodeCore;
using System.Text;
using System.IO;

namespace BinaryEncodeDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            //*
            byte[] cfbyts = File.ReadAllBytes(@"C:\Users\c_iro\Desktop\cf.txt");
            EDcodeHelper.Encode(cfbyts);
            File.WriteAllBytes(@"C:\Users\c_iro\Desktop\cf_ed.txt", cfbyts);
            //*/
            /*
            byte[] cfbyts = File.ReadAllBytes(@"C:\Users\c_iro\Desktop\cf_ed.txt");
            EDcodeHelper.Decode(cfbyts);
            File.WriteAllBytes(@"C:\Users\c_iro\Desktop\cf_dd.txt", cfbyts);
            //*/
            Console.Read();
        }
    }
}
