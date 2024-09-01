using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AcademyOnline.View.Services
{
    public class ServiceRepository
    {
        HttpClient _client;
        public ServiceRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://miguel503.somee.com/Api/");
        }

        public HttpResponseMessage GetResponse(string url)
        {
            return _client.GetAsync(url).Result;
        }

        public HttpResponseMessage PostResponse(string url, object entity)
        {
            return _client.PostAsJsonAsync(url,entity).Result;
        }

        public HttpResponseMessage PutResponse(string url, object entity)
        {
            return _client.PutAsJsonAsync(url,entity).Result;
        }

        public HttpResponseMessage DeleteResponse(string url)
        {
            return _client.DeleteAsync(url).Result;
        }
    }
}