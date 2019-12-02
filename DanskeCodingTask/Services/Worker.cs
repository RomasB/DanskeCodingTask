using System;
using System.Threading.Tasks;

namespace DanskeCodingTask.Services
{
    public class Worker : IWorker
    {
        private readonly IFileReader _fileReader;

        public Worker(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public async Task Run(string fileName)
        {
            Console.WriteLine($"Filename '{fileName}'");

            var triangle = _fileReader.ReadInput(fileName);

            if (triangle.Success)
            {
                var pathHandler = new PathHandler(triangle.Result);
                var greaterPathSr = await pathHandler.FindGreaterPath();

                if (greaterPathSr.Success)
                {
                    Console.WriteLine($"Max sum: {greaterPathSr.Result.Sum}");
                    Console.Write($"Path: {string.Join<int>(", ", greaterPathSr.Result.Path)}");
                    Console.WriteLine();
                }
                else
                {
                    foreach (var error in greaterPathSr.Errors)
                    {
                        Console.WriteLine($"Error: {error.Key}");
                    }
                }
            }
            else
            {
                foreach (var error in triangle.Errors)
                {
                    Console.WriteLine($"Error: {error.Key}");
                }
            }

            Console.WriteLine();
        }

    }
}
