using ARD.Delegates.Examples;
using System;

namespace ARD.Delegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            /* uncomment below code to work on delegates */
            GeneralExampleOfDelegate generalExampleOfDelegate = new GeneralExampleOfDelegate();
            generalExampleOfDelegate.GetFilteredValues();
            Console.ReadLine();
        }
    }
}
