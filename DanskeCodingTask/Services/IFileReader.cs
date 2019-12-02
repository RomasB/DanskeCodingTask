using DanskeCodingTask.Infrastructure;
using System.Collections.Generic;

namespace DanskeCodingTask.Services
{
    public interface IFileReader
    {
        ServiceResult<List<List<int>>> ReadInput(string fileName);
    }
}
