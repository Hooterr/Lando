using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lando.Async
{
    public static class AsyncAwaiter
    {
        #region Private Members

        private static readonly SemaphoreSlim SelfLock = new SemaphoreSlim(1, 1);

        private static readonly Dictionary<string, SemaphoreSlim> Semaphores = new Dictionary<string, SemaphoreSlim>();

        #endregion

        public static async Task<T> AwaitResultAsync<T>(string key, Func<Task<T>> task, int maxAccessCount = 1)
        {

            await SelfLock.WaitAsync();

            try
            {
                if (!Semaphores.ContainsKey(key))
                    Semaphores.Add(key, new SemaphoreSlim(maxAccessCount, maxAccessCount));
            }
            finally
            {

                SelfLock.Release();
            }

            var semaphore = Semaphores[key];

            await semaphore.WaitAsync();

            try
            {
                return await task();
            }
            finally
            {
                semaphore.Release();
            }
        }

        public static async Task AwaitAsync(string key, Func<Task> task, int maxAccessCount = 1)
        {
            await SelfLock.WaitAsync();

            try
            {
                if (!Semaphores.ContainsKey(key))
                    Semaphores.Add(key, new SemaphoreSlim(maxAccessCount, maxAccessCount));
            }
            finally
            {
                SelfLock.Release();
            }

            var semaphore = Semaphores[key];

            await semaphore.WaitAsync();

            try
            {
                await task();
            }
            catch 
            {
                throw;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
