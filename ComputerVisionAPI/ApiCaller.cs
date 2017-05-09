using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;
namespace ApiCaller
{
    public static class WebRequest
    {
        public static async Task ComputerVisionExampleRequest(string ImgUrl, Action<Dictionary<string, object>> Callback)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    // Every Cognitive service API requires a key
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "415854549be441a6acd5eab0f10c80d1" );
                    
                    // We use this dictionary to add parameters to our API request
                    var QueryParameters = new Dictionary();
                    
                    // Here we're adding a parameter called "visualFeatures" with a value of "Color, Tags"
                    QueryParameters.Add("visualFeatures","Color, Tags");
                    
                    // Not every API will require an HttpContent object
                    // StringContent is a way to define Http request values using a string 
                    // Here we set the url of the image that we want to analyze
                    HttpContent content = new StringContent($"{{\"url\":\"{ImgUrl}\"}}");
                    
                    // Defines the Datatype of the content being sent with the Http request
                    content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    
                    // This methods appends our query parameters to the base url of the API to create the target uri
                    string QueryUrl = QueryHelpers.AddQueryString("https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze", QueryParameters);
                                     
                    // Here we actually make our Http request and await the response
                    HttpResponseMessage Response = await client.PostAsync(QueryUrl, content);
                    
                    // Ensure that a success code was returned
                    Response.EnsureSuccessStatusCode();
                    
                    // Parse the response into a usable object
                    // Dictionary ParsedResponse = ...
                    CallBack(ParsedResponse);
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}