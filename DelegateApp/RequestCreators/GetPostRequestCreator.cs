using DelegateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DelegateApp.RequestCreators
{
    public class GetPostRequestCreator
    {
        public void MakeRequest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress=new Uri("https://jsonplaceholder.typicode.com");

            var httpRes=client.GetAsync("posts").GetAwaiter().GetResult();

            httpRes.EnsureSuccessStatusCode();

            var resultContent=httpRes.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            JsonSerializer.Deserialize<List<PostModel>>(resultContent);
        }
    }
}
