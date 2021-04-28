using System;
using System.Threading.Tasks;

namespace GitTracker.Domain.Helpers.Extensions
{
    public static class TaskExtensions
    {
        public static async Task<T> RunWithErrorHandler<T>(this Task<T> task, Action<Exception> errorHandler)
        {
            try
            {
                return await task;
            }
            catch (AggregateException agrEx)
            {
                foreach (var innerException in agrEx.InnerExceptions)
                {
                    errorHandler?.Invoke(innerException);
                }
            }
            catch (Exception ex)
            {
                errorHandler?.Invoke(ex);
            }

            return default;
        }
    }
}