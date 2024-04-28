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
        public BaseRequestCreator()
        {
            makeReauestDelageMethod = MakeGetRequest;
            
        }

        protected delegate string GetBaseAddressDelegate();
        GetBaseAddressDelegate getBaseAddressDelegate;

        private delegate string MakeReauestDelageMethod();
        MakeReauestDelageMethod makeReauestDelageMethod;

        public delegate void RequestStartedDelegate();
        RequestStartedDelegate requestStartedDelegate;

        Func<int> requestCountFunc;

        private HttpMethod httpMethod;

        protected void SetRequestCount(int count)
        {
            requestCountFunc = ()=> count;
        }
        

        protected void SetBaseAddressMehtod(GetBaseAddressDelegate paramDelegateMethod)
        {
            getBaseAddressDelegate = paramDelegateMethod;
        }

        public void SetRequestStartedMethod(RequestStartedDelegate paramDelegateMethod)
        {
            requestStartedDelegate = paramDelegateMethod;
        }
        private string MakeGetRequest()
        {
            HttpClient client = new HttpClient();
            var baseAddress = getBaseAddressDelegate.Invoke();

            var msg = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(baseAddress + GetUrlPath()),
            };


            var httpRes = client.Send(msg);

            httpRes.EnsureSuccessStatusCode();

            var resultContent = httpRes.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return resultContent;
        }

        private string MakePostRequest()
        {
            HttpClient client = new HttpClient();
            var baseAddress = getBaseAddressDelegate.Invoke();

            var msg = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(baseAddress + GetUrlPath()),
            };

            var bodyContent = GetBodyObject();
            if (bodyContent != null)
                msg.Content = new StringContent(JsonSerializer.Serialize(bodyContent));

            var httpRes = client.Send(msg);

            httpRes.EnsureSuccessStatusCode();

            var resultContent = httpRes.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return resultContent;
        }
        protected string MakeRequest()
        {
            var requestCount = Math.Max(requestCountFunc.Invoke(),1);

            while ((requestCount--) > 0)
            {
                requestStartedDelegate.Invoke();
            }
            return makeReauestDelageMethod.Invoke();
        }

        protected virtual string GetBaseAddress()
        {
            return "";
        }

        protected virtual string GetUrlPath()
        {
            return "";
        }
        protected HttpMethod SetHttpMethod(HttpMethod method)
        {
            if (method == HttpMethod.Post)
                makeReauestDelageMethod = MakePostRequest;

            return httpMethod=method;
        }

        protected virtual object GetBodyObject() 
        {
            return default;
        }

    }
}
