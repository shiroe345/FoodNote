using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using RestSharp;
using static System.Net.WebRequestMethods;

namespace Final_Project.src
{
    internal class KeywordSearchService
    {
        public KeywordSearchService() { }

        private static Dictionary<string, string> ParseKeyword(string keyword= "成功大學,1000,牛排")
        {
            string input = keyword;
            Dictionary<string, string> result = new Dictionary<string, string>();
            // 使用逗號分隔字串
            string[] parts = input.Split(',');
            Console.WriteLine(input);
            // 存取各個部分
            result.Add("loc", parts[0]); // "成功大學"
            result.Add("rad", parts[1]); // 1000
            string[] keywords = parts.Skip(2).ToArray();
            result.Add("keywords", string.Join(",", keywords)); // "牛排"
            //result.Add("rad", parts[2]); // 1000
            return result;
        }
        public static List<Dictionary<string, object>> RecommendRestaurant(string keyword)
        {
            Dictionary<string, string> parsedKeyword = ParseKeyword(keyword);

            List<Dictionary<string, object>> recommendedRest = new List<Dictionary<string, object>>();

            //var key = Environment.GetEnvironmentVariable("GOOGLE_MAP_API_KEY");
            var key = "AIzaSyA-48Dsd5h277-wLOrJj0iChDFjPnUGFpk";
            var baseUrl = $"https://maps.googleapis.com/maps/api/place/findplacefromtext/json?fields=formatted_address%2Cname%2Cgeometry&input={parsedKeyword["loc"]}&inputtype=textquery&key={key}";
            RestClientOptions options = new RestClientOptions(baseUrl)
            { UseDefaultCredentials = true };
            var client = new RestClient(options);
            // Create a RestRequest for the GET method
            var request = new RestRequest();
            // Execute the request and get the response
            var response = client.Get(request);
            // Check if the request was successful
            if (!response.IsSuccessful)
            {
                Console.WriteLine($"Error: {response.ErrorMessage}");
                recommendedRest.Add(
                    new Dictionary<string, object> {
                        { "error", $"{response.ErrorMessage}" }
                    }
                );
                return recommendedRest;
            }

            // Output the response body content
            var json = JsonDocument.Parse(response.Content);

            // 提取特定欄位
            if (json.RootElement.GetProperty("candidates").GetArrayLength()<1)
            {
                Console.WriteLine($"Error: No search result!");
                Console.WriteLine(response.Content);
                recommendedRest.Add(
                    new Dictionary<string, object> {
                        { "error", $"Error: No search result!" }
                    }
                );
                throw new Exception("Error: No search result!");
            }
            var address = json.RootElement.GetProperty("candidates")[0].GetProperty("formatted_address").GetString();
            var lat = json.RootElement.GetProperty("candidates")[0].GetProperty("geometry").GetProperty("location").GetProperty("lat").GetSingle();
            var lng = json.RootElement.GetProperty("candidates")[0].GetProperty("geometry").GetProperty("location").GetProperty("lng").GetSingle();

            Console.WriteLine($"add: {address}, lat: {lat}, lng: {lng}");
            //Console.WriteLine(response.Content);

            int rad = int.Parse(parsedKeyword["rad"]);
            string k = parsedKeyword["keywords"];
            baseUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={lat}%2C{lng}&radius={rad}&keyword={k}&type=restaurant&language=zh-TW&key={key}";
            //baseUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=25.0338,121.5646&radius=100&keyword=牛排&language=zh-TW&key={key}";
            request = new RestRequest(baseUrl, Method.Get);
            response = client.Execute(request);

            // 處理回應
            if (!response.IsSuccessful)
            {
                Console.WriteLine($"Error: {response.ResponseStatus}, {response.ErrorMessage}");
            }

            //Console.WriteLine(response.Content);
            json = JsonDocument.Parse(response.Content);

            // 提取特定欄位
            if (json.RootElement.GetProperty("results").GetArrayLength() < 1)
            {
                Console.WriteLine($"Error: No search result!");
                Console.WriteLine(response.Content);
                recommendedRest.Add(
                    new Dictionary<string, object> {
                        { "error", $"Error: No search result!" }
                    }
                );
                throw new Exception("Error: No search result!");
            }
            var rest_num = json.RootElement.GetProperty("results").GetArrayLength();
            Console.WriteLine($"rest_num: {rest_num}");

            for (int i = 0; i < rest_num && i < 6; ++i)
            {
                string place_id = json.RootElement.GetProperty("results")[i].GetProperty("place_id").GetString();
                string name = json.RootElement.GetProperty("results")[i].GetProperty("name").GetString();
                lat = json.RootElement.GetProperty("results")[i].GetProperty("geometry").GetProperty("location").GetProperty("lat").GetSingle();
                lng = json.RootElement.GetProperty("results")[i].GetProperty("geometry").GetProperty("location").GetProperty("lng").GetSingle();

                baseUrl = $"https://maps.googleapis.com/maps/api/place/details/json?place_id={place_id}&language=zh-TW&key={key}";
                request = new RestRequest(baseUrl, Method.Get);
                response = client.Execute(request);
                var _ = JsonDocument.Parse(response.Content);
                // 提取特定欄位
                string url = _.RootElement.GetProperty("result").GetProperty("url").GetString();

                string review = "";
                JsonElement ele = _.RootElement.GetProperty("result").GetProperty("reviews");
                for (int j=0; j < Math.Min(10,ele.GetArrayLength()); ++j)
                {
                    review += ele[j].GetProperty("text").ToString();
                }

                recommendedRest.Add(
                    new Dictionary<string, object> {
                        { "name", name},
                        { "url", url },
                        { "lat", lat },
                        { "lng", lng },
                        { "review", review }
                    }
                );
            }


            return recommendedRest;
        }
    }
}
