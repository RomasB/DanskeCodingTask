using System.Threading.Tasks;

namespace DanskeCodingTask.Services
{
    public interface IWorker
    {
        Task Run(string fileName);
    }
}
