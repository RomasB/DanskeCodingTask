using System;
using System.Collections.Generic;
using System.Linq;

namespace DanskeCodingTask.Infrastructure
{
    public class ServiceResult<T>
    {
        public T Result { get; set; }

        public List<KeyValuePair<ErrorKey, object[]>> Errors { get; set; }

        public bool Success => !Errors.Any();

        public ServiceResult()
        {
            if (typeof(T) != typeof(string))
            {
                Result = (T)Activator.CreateInstance(typeof(T));
            }
            Errors = new List<KeyValuePair<ErrorKey, object[]>>();
        }

        public void AddError(ErrorKey key, params object[] values)
        {
            Errors.Add(new KeyValuePair<ErrorKey, object[]>(key, values));
        }

    }
}
