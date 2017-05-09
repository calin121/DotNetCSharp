using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PokeInfo
{
    public class WebRequest
    {
        public static async Task GetPokemonDataAsync(int PokeId, Action<Pokemon> Callback)
        {
            // Create a temporary HttpClient connection.
            using (var Client = new HttpClient())
            {
                try
                {
                    Client.BaseAddress = new Uri($"http://pokeapi.co/api/v2/pokemon/{PokeId}");
                    HttpResponseMessage Response = await Client.GetAsync(""); // Make the actual API call.
                    Response.EnsureSuccessStatusCode(); // Throw error if not successful.
                    string StringResponse = await Response.Content.ReadAsStringAsync(); // Read in the response as a string.
                    
                    JObject PokeObject = JsonConvert.DeserializeObject<JObject>(StringResponse);
                    
                    // System.Console.WriteLine("*******************************");
                    // System.Console.WriteLine("*******************************");
                    // System.Console.WriteLine(PokeObject);
                    // System.Console.WriteLine("*******************************");
                    // System.Console.WriteLine("*******************************");
                    
                    JArray TypeList = PokeObject["types"].Value<JArray>();

                    List<string> Types = new List<string>();

                    foreach(JObject TypeObject in TypeList)
                    {
                        Types.Add(TypeObject["type"]["name"].Value<string>());
                    }


                    // JArray ImageList = PokeObject["sprites"].Value<JArray>();

                    // string Images = "";
                    
                    // foreach(JObject Image in ImageList)
                    // {
                    //     Images.Add(Image["front_default"].Value<string>());
                    //     System.Console.WriteLine("*******************************");
                    //     System.Console.WriteLine("*******************************");
                    //     System.Console.WriteLine(Image);
                    //     System.Console.WriteLine("*******************************");
                    //     System.Console.WriteLine("*******************************");
                    // }

                    Pokemon PokeData = new Pokemon{
                        Name = PokeObject["name"].Value<string>(),
                        Weight = PokeObject["weight"].Value<long>(),
                        Height = PokeObject["height"].Value<long>(),
                        Types = Types,
                        Image1 = PokeObject["sprites"]["back_female"].Value<string>(),
                        Image2 = PokeObject["sprites"]["back_shiny_female"].Value<string>(),
                        Image3 = PokeObject["sprites"]["back_default"].Value<string>(),
                        Image4 = PokeObject["sprites"]["front_female"].Value<string>(),
                        Image5 = PokeObject["sprites"]["front_shiny_female"].Value<string>(),
                        Image6 = PokeObject["sprites"]["back_shiny"].Value<string>(),
                        Image7 = PokeObject["sprites"]["front_default"].Value<string>(),
                        Image8 = PokeObject["sprites"]["front_shiny"].Value<string>(),
                                                

                    };
                     
                    // Finally, execute our callback, passing it the response we got.
                    Callback(PokeData);
                }
                catch (HttpRequestException e)
                {
                    // If something went wrong, display the error.
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}