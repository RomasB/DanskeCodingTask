using DanskeCodingTask.Infrastructure;
using DanskeCodingTask.Model;
using System.Threading.Tasks;

namespace DanskeCodingTask.Services
{
    public interface IPathHandler
    {
        Task<ServiceResult<PathInfo>> FindGreaterPath();
    }
}
