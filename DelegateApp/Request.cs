using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateApp;

//PostDto dto = new PostDto()
//{
//    userId = 55,
//    title = "test",
//    body = "testBody"
//};

//HttpClient client = new HttpClient();
//var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
//var postDto = JsonConvert.SerializeObject(dto);
//var payload = new StringContent(postDto, Encoding.UTF8, "application/json");
//var result = await client.PostAsync(endpoint, payload);
//result.EnsureSuccessStatusCode();
//var ss = await result.Content.ReadAsStringAsync();
//var sonuc = JsonConvert.DeserializeObject<Dto>(ss);
//Console.WriteLine(sonuc.body);



//HttpClient client = new HttpClient();
//var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
//var result = await client.GetAsync(endpoint);
//var json = await result.Content.ReadAsStringAsync();
//var postList = JsonConvert.DeserializeObject<List<Dto>>(json);
//Console.WriteLine(json);


//using (var client = new HttpClient())
//{
//    var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
//    var result =await client.GetAsync(endpoint);
//    var json =await result.Content.ReadAsStringAsync();
//    var postList = JsonConvert.DeserializeObject<List<Dto>>(json);
//    Console.WriteLine(json);
//}



public class Dto
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class PostDto
{
    public int userId { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}
