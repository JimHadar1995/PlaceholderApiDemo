using FrameWork.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameWork.Extensions {
    public static class CacheWrapperExtensions {
        public static T GetOrAdd<T>(this ICacheWrapper cache, string key, object locker, Func<T> func) where T : class {
            var result = cache[key] as T;
            if (result != null)
                return result;
            lock (locker) {
                result = cache[key] as T;
                if (result != null)
                    return result;
                result = func.Invoke();
                cache[key] = result;
                return result;
            }
        }

        public static async Task<T> GetOrAddAsync<T>(this ICacheWrapper cache,
            string key,
            SemaphoreSlim semaphore,
            Func<Task<T>> func) where T : class {
            var result = cache[key] as T;
            if (result != null)
                return result;
            await semaphore.WaitAsync().ConfigureAwait(false);
            try {
                result = cache[key] as T;
                if (result != null)
                    return result;
                result = await func.Invoke();
                cache[key] = result;
                return result;
            }
            finally {
                semaphore.Release();
            }
        }
    }
}
