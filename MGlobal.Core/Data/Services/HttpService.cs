﻿using MGlobal.Core.Domain.Contracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MGlobal.Core.Data.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;
        private readonly TimeSpan TimeOut = new TimeSpan(0, 0, 10);

        public HttpService(HttpClient client)
        {
            _client = client;
        }
        public HttpRequestMessage CreateHttpRequestMessage(string requestUri, HttpMethod method, HttpContent content)
        {
            return new HttpRequestMessage
            {
                RequestUri = new Uri(requestUri),
                Method = method,
                Content = content
            };
        }

        public async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage request)
        {
            _client.Timeout = this.TimeOut;
            return await _client.SendAsync(request);
        }
    }
}