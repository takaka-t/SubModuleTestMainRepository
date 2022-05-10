using System;
using SubProject;
using MoreProject;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            var str1 = SubProject.Class1.TestFunction();
            Console.WriteLine("MoreProject " + str1);

            var str2 = MoreProject.Class1.Test();
            Console.WriteLine("MoreProject " + str2);

        }
    }
}
