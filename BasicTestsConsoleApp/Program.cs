using BasicTests;
using System;

namespace BasicTestsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringTool stringTools = new StringTool();
            Console.WriteLine(stringTools.JoinStrings("Diego", "Gutierrez"));


            Console.ReadKey();
        }
    }
}
