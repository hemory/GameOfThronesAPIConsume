using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class DAL
    {
        private static HttpClient client = null;
        private static HttpClient GetHttpClient()
        {
            // We're building a **SINGLETON** object of type HttpClient
            
            if (client == null)
            {
                // client instance hasn't been made yet, make it and initialize it
                client = new HttpClient();
                client.BaseAddress = new Uri("https://www.anapioficeandfire.com/api");
            }
            return client;
        }
        
        public static async Task<CharacterResponse> GetCharacters()
        {
            var connection = await GetHttpClient().GetAsync($"https://www.anapioficeandfire.com/api/characters");
            CharacterResponse resp = await connection.Content.ReadAsAsync<CharacterResponse>();
            return resp;
        }


        public static async Task<Character[]> GetAllCharacters()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://www.anapioficeandfire.com/api/");
            var responseTask = client.GetAsync("characters");
            responseTask.Wait();

            var result = responseTask.Result;
            
                var readTask = result.Content.ReadAsAsync<Character[]>();
                readTask.Wait();

                 var characters = readTask.Result;

                 return characters;
        }
        
        public static async Task<Character> GetCharacterById(int characterId)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://www.anapioficeandfire.com/api/");
            var responseTask = client.GetAsync($"characters/{characterId}");
            responseTask.Wait();

            var result = responseTask.Result;
            
            var readTask = result.Content.ReadAsAsync<Character>();
            readTask.Wait();

            var character = readTask.Result;

            return character;
        }
      
    }
}