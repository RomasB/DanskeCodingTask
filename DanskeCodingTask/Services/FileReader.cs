using DanskeCodingTask.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DanskeCodingTask.Services
{
    public class FileReader : IFileReader
    {
        public ServiceResult<List<List<int>>> ReadInput(string fileName)
        {
            var result = new ServiceResult<List<List<int>>>();
            try
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        var file = new StreamReader(fileName);
                        string line;
                        int row = 1;

                        while ((line = file.ReadLine()) != null)
                        {
                            var rowList = GetListFromString(line);

                            if (rowList.Count != row)
                            {
                                result.AddError(ErrorKey.WrongDataFormat);
                            }
                            row += 1;

                            result.Result.Add(rowList);
                        }
                        file.Close();
                    }
                    catch (Exception e)
                    {
                        result.AddError(ErrorKey.InvalidFileContent);
                    }
                }
                else
                {
                    result.AddError(ErrorKey.FileNotFound);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        private List<int> GetListFromString(string text)
        {
            var values = text.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            return values.Select(arg => int.Parse(arg)).ToList();
        }

    }
}
