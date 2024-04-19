using DelegateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DelegateApp.RequestCreators
{
    public class BaseRequestCreator
    {
        protected string MakeRequest()
        {
            HttpClient client = new HttpClient();

            var msg = new HttpRequestMessage
            {
                Method = GetHttpMethod(),
                RequestUri = new Uri(GetBaseAddress() + GetUrlPath()),
      
                
            };
            var bodyContent = GetBodyObject();
            if (bodyContent != null)
                msg.Content = new StringContent(JsonSerializer.Serialize(bodyContent));
            var httpRes=client.Send(msg);
            httpRes.EnsureSuccessStatusCode();

            var resultContent = httpRes.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return resultContent;
        }

        protected virtual string GetBaseAddress()
        {
            return "";
        }

        protected virtual string GetUrlPath()
        {
            return "";
        }
        protected virtual HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }

        protected virtual object GetBodyObject() 
        {
            return default;
        }

    }
}
