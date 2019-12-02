using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DanskeCodingTask.Services;

namespace TestApp
{
    class Program
    {
        static readonly List<string> FileNames = new List<string>
        {
            "input1.txt", 
            "input2.txt", 
            "input3.txt", 
            "input4.txt", 
            "input5.txt", 
            "input6.txt", 
            "input7.txt",
            "input8.txt",
            "input9.txt"
        };

        static void Main(string[] args)
        {
            var fileReader = new FileReader();
            var worker = new Worker(fileReader);

            var tasks = new List<Task>(FileNames.Count);
            foreach (var fileName in FileNames)
            {
                tasks.Add(worker.Run(fileName));
            }
            Task.WaitAll(tasks.ToArray());
            Console.ReadLine();
        }

    }
}
