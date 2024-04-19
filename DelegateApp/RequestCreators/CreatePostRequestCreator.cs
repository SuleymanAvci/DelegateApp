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
        public PostModel CreatePost(PostModel model)
        {
            var responseContent = base.MakeRequest();
            return JsonSerializer.Deserialize<PostModel>(responseContent); 
        }

    }
}
