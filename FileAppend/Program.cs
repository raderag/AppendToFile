using System;
using System.IO;

namespace FileAppend
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
                return;

            string fileName = args[0];

            bool empty = false;

            using (FileStream fs = (new FileStream(fileName, FileMode.Open)))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    empty = br.ReadByte() == 0;
                }

                fs.Close();
            }

            using (StreamWriter sr = new StreamWriter(fileName, !empty))
            {
                sr.WriteLine("\n" + args[1]);
                sr.Close();
            }
        }
    }
}
