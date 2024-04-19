﻿using DelegateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DelegateApp.RequestCreators
{
    public class GetPostRequestCreator: BaseRequestCreator
    {

        public List<PostModel> GetPost()
        {
            var responseContent = base.MakeRequest();
            return JsonSerializer.Deserialize<List<PostModel>>(responseContent);
        }

    }
}
