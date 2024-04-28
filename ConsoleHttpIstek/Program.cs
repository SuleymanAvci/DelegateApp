using Newtonsoft.Json;
using System.Text;

PostDto dto = new PostDto()
{
    userId = 55,
    title = "test",
    body = "testBody"
};

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
var httpRes  =await client.GetAsync("posts");
var content=await httpRes.Content.ReadAsStringAsync();
var liste=JsonConvert.DeserializeObject<List<Dto>>(content);

var Lis =liste.Where(x => x.title.EndsWith("as"));
Console.WriteLine(Lis.Count());

foreach (var l in Lis)
{
    Console.WriteLine(l.title);
}


//HttpClient client = new HttpClient();
//var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
//var postDto = JsonConvert.SerializeObject(dto);
//var payload = new StringContent(postDto, Encoding.UTF8, "application/json");
//var result = await client.PostAsync(endpoint, payload);
//result.EnsureSuccessStatusCode();
//var ss = await result.Content.ReadAsStringAsync();
//var sonuc = JsonConvert.DeserializeObject<Dto>(ss);
//Console.WriteLine(sonuc.body);



//using Newtonsoft.Json;

//HttpClient client = new HttpClient();
//client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
//var result = await client.GetAsync("posts");
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