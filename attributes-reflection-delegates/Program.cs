using System;
using System.Diagnostics;

namespace attributes_reflection_delegates
{
    public class Program
    {
        static void Main(string[] args)
        {

            using (var process1 = new Process())
            {
                process1.StartInfo.FileName = @"D:\Git\C#\attributes-reflection-delegates\ARD.Delegates\bin\Debug\net5.0\ARD.Delegates.exe";
                process1.StartInfo.UseShellExecute = true;
                process1.Start();
            }

            using (var process1 = new Process())
            {
                process1.StartInfo.FileName = @"D:\Git\C#\attributes-reflection-delegates\ARD.Reflections\bin\Debug\net5.0\ARD.Reflections.exe";
                process1.StartInfo.UseShellExecute = true;
                process1.Start();
            }

            Console.WriteLine("MainApp");
            Console.ReadKey();
        }

    }

}
