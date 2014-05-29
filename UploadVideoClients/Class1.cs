using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http; //here important about HttpClient!!!
using System.Threading.Tasks;

// HttpClient is a new HTTP-aware client and extremely flexible and extensible
// UserAgent - HttpClient doesn't send by default
// var client = new HttpClient();
// client.DefaultRequestHeaders.Add("User-Agent", "My cool Client");
// security - Not much new for HttpClient
namespace UploadVideoClients
{
    public class Class1
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();            
            var stream = File.Open("video.mp4", FileMode.Open);
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(stream), "\"video\"", "\"video.mp4\"");
            var task = client.PostAsync("http://localhost:65307/home/UploadVideo"
                , content).ContinueWith(response =>
                {
                    response.Result.EnsureSuccessStatusCode();
                }).ContinueWith(err =>
                {
                    if (err.Exception != null)
                    {
                        Console.WriteLine("Exception {0}", err.Exception.ToString());
                    }
                });
            task.Wait();
            Console.WriteLine("Video uploaded!!!");
            Console.ReadKey();
        }
    }
}
