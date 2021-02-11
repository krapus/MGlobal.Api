using System.Net.Http;
using System.Threading.Tasks;

namespace MGlobal.Core.Domain.Contracts
{
    public interface IHttpService
    {
        HttpRequestMessage CreateHttpRequestMessage(string requestUri, HttpMethod method, HttpContent content);
        Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage request);
    }
}
