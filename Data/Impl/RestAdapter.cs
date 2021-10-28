﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DNP2.Models;

namespace DNP2.Data.Impl
{
    public class RestAdapter : IDataAdapter
    {
        private readonly HttpClient client;

        public RestAdapter()
        {
            client = new HttpClient();
        }
        public async Task<List<Family>> GetAllFamiliesAsync()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/families");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<Family> families = JsonSerializer.Deserialize<List<Family>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return families;
        }

        public async Task<Family> GetFamilyWithAdultAsync(int adultId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5001/families/adult/{adultId}");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            Family family = JsonSerializer.Deserialize<Family>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return family;
            
        }

        public async Task<Family> GetFamilyWithChildAsync(int childId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5001/families/child/{childId}");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            Family family = JsonSerializer.Deserialize<Family>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return family;
        }

        public async Task<List<Adult>> GetAllAdultsAsync()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/adults");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return adults;
        }

        public async Task<Adult> GetAdultByIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5001/adults/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Adult adult = JsonSerializer.Deserialize<Adult>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return adult;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            StringContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:5001/adults", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task RemoveAdultAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:5001/adults/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error:{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task EditAdultAsync(Adult editedAdult)
        {
            string adultAsJson = JsonSerializer.Serialize(editedAdult);
            StringContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PatchAsync("https://localhost:5001/adults", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task<List<Child>> GetAllChildrenAsync()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/children");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<Child> children = JsonSerializer.Deserialize<List<Child>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return children;
        }

        public async Task<Child> GetChildByIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5001/children/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Child child = JsonSerializer.Deserialize<Child>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return child;
        }

        public async Task RemoveChildAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:5001/children/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error:{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task EditChildAsync(Child editedChild)
        {
            string adultAsJson = JsonSerializer.Serialize(editedChild);
            StringContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PatchAsync("https://localhost:5001/children", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/jobs");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<Job> jobs = JsonSerializer.Deserialize<List<Job>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return jobs;
        }
    }
}