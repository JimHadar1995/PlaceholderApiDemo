using FrameWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderApiDemo.Library.Services
{
    public class ApiQueryService
    {
        private HttpClient httpClient;
        private ILogService logService;
        public ApiQueryService(ILogService _logService, HttpClient _httpClient) {
            logService = _logService;
            httpClient = _httpClient;
        }
        public async Task<TResult> GetAsync<TResult>(string url)
            where TResult: class, new() {
            var res = new TResult();
            try {
                var response = await httpClient.GetAsync(url).ConfigureAwait(false);
                if (response.IsSuccessStatusCode) {
                    var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    res = JsonConvert.DeserializeObject<TResult>(responseString);
                }
            }
            catch(Exception e) {
                logService.LogFatal(e);
#if DEBUG
                throw e;
#endif
            }
            return res;
        }
    }
}
