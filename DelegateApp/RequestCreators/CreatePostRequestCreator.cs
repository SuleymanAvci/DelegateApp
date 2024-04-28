 using DelegateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DelegateApp.RequestCreators
{
    public class CreatePostRequestCreator:BaseRequestCreator
    {

        private PostModel postModel;
        public CreatePostRequestCreator()
        {
            base.SetBaseAddressMehtod(() =>
            {
                return "https://jsonplaceholder.typicode.com/";
            });

            SetHttpMethod(HttpMethod.Post);
        }

        public PostModel CreatePost(PostModel post)
        {
            postModel = post;
            var responseContent = base.MakeRequest();
            return JsonSerializer.Deserialize<PostModel>(responseContent); 
        }

        protected override object GetBodyObject()
        {
            return postModel;
        }



        protected override string GetUrlPath()
        {
            return "posts";
        }

    }
}
