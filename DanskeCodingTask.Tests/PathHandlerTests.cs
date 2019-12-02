using DanskeCodingTask.Infrastructure;
using DanskeCodingTask.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace DanskeCodingTask.Tests
{
    public class PathHandlerTests
    {
        [Test]
        public void FindGreaterPath_Scenario1()
        {
            var triangle = new List<List<int>>()
            {
                new List<int>() { 1 },
                new List<int>() { 8, 9 },
                new List<int>() { 1, 5, 9 },
                new List<int>() { 4, 5, 2, 3 },
            };

            var pathHandler = new PathHandler(triangle);
            var sr = pathHandler.FindGreaterPath().Result;

            Assert.AreEqual(sr.Result.Path, new List<int>() { 1, 8, 5, 2 });
            Assert.AreEqual(sr.Result.Sum, 16);
            Assert.IsEmpty(sr.Errors);
        }

        [Test]
        public void FindGreaterPath_No_Proper_Path_Exists()
        {
            var triangle = new List<List<int>>()
            {
                new List<int>() { 1 },
                new List<int>() { 2, 3 },
                new List<int>() { 4, 4, 4 }
            };

            var pathHandler = new PathHandler(triangle);
            var sr = pathHandler.FindGreaterPath().Result;

            Assert.That(sr.Errors, Has.Exactly(1).Property("Key").EqualTo(ErrorKey.NoProperPathExists));
            Assert.IsEmpty(sr.Result.Path);
            Assert.Zero(sr.Result.Sum);
        }

    }
}