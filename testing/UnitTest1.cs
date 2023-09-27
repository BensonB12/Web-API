using System.Net.Http.Json;
using static System.Net.Http.HttpClient;

namespace testing;


public class Tests
{
    HttpClient _client;
    string _url;

    [SetUp]
    public void Setup()
    {
        _client = new HttpClient();
        _url = "https://localhost:40443";
    }

    [Test]
    public async Task Testadd()
    {
        string answer = _client.GetFromJsonAsync<string>(_url + "/add?num1=1&num2=3").Result;
        Assert.AreEqual(answer, "3");
    }
}