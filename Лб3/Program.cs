using System;

namespace Лб3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Console.OutputEncoding = System.Text.Encoding.Unicode;

            Parser parser = new Parser();
            parser.Instruction();
            parser.Parse();
            parser.GetResult();

            Console.ReadKey();
        }
    }
}
