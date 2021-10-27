using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using merchandise_service.HttpModels;

namespace merchandise_service.HttpClient
{
    public class MerchHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MerchResponse>> GetAll(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}