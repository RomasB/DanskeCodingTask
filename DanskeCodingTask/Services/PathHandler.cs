using DanskeCodingTask.Infrastructure;
using DanskeCodingTask.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanskeCodingTask.Services
{
    public class PathHandler : IPathHandler
    {
        private readonly List<List<int>> _triangle;

        private List<int> _greaterPath = new List<int>();

        public PathHandler(List<List<int>> triangle)
        {
            _triangle = triangle;
        }

        public async Task<ServiceResult<PathInfo>> FindGreaterPath()
        {
            var sr = new ServiceResult<PathInfo>();

            if (_triangle.Any() && _triangle.First().Any())
            {
                bool isEven = _triangle.First().First() % 2 == 0; // first number

                var rowNo = 0;
                var index = 0;
                var pathResult = new List<int>();

                await FindNext(rowNo, index, isEven, pathResult);

                if (!_greaterPath.Any())
                {
                    sr.AddError(ErrorKey.NoProperPathExists);
                }
            }
            else
            {
                sr.AddError(ErrorKey.NoDataProvided);
            }

            sr.Result = GetPathInfo(_greaterPath);

            return sr;
        }

        private async Task FindNext(int rowNo, int index, bool isEven, List<int> path)
        {
            if (rowNo < _triangle.Count())
            {
                var list = _triangle[rowNo];
                var numbers = list.Select((item, i) => new { item, i }) // select primary index and value
                    .Where(x => x.i >= index && x.i <= index + 1 && (isEven ? x.item % 2 == 0 : x.item % 2 != 0)) // filter position and proper number types
                    .ToList();

                foreach (var number in numbers)
                {
                    path.Add(number.item); // step down
                    await FindNext(rowNo + 1, number.i, !isEven, path);
                    path.RemoveAt(path.Count - 1); // step up
                }
            }
            else // last row reached
            {
                if (path.Sum() > _greaterPath.Sum()) // if greater result found 
                {
                    _greaterPath = new List<int>(path); // save - initialize new result reference
                }
            }
        }

        private static PathInfo GetPathInfo(List<int> path) =>
            new PathInfo
            {
                Path = path,
                Sum = path.Sum()
            };
    }
}
