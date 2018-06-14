using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using AzureXamarinBlog.Models;

namespace AzureXamarinBlog.Services
{
	public class AzureBlogDataStore : IDataStore<Post>
	{
		HttpClient client;
		IEnumerable<Post> posts;

		public AzureBlogDataStore()
		{
			client = new HttpClient();
			client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

			posts = new List<Post>();
		}

		public async Task<IEnumerable<Post>> GetItemsAsync(bool forceRefresh = false)
		{
			if (forceRefresh && CrossConnectivity.Current.IsConnected)
			{
				var json = await client.GetStringAsync($"api/post");
				posts = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Post>>(json));
			}

			return posts;
		}

		public async Task<Post> GetItemAsync(string id)
		{
			if (id != null && CrossConnectivity.Current.IsConnected)
			{
				var json = await client.GetStringAsync($"api/post/{id}");
				return await Task.Run(() => JsonConvert.DeserializeObject<Post>(json));
			}

			return null;
		}

		public async Task<bool> AddItemAsync(Post post)
		{
			if (post == null || !CrossConnectivity.Current.IsConnected)
				return false;

			var serializedPost = JsonConvert.SerializeObject(post);

			var response = await client.PostAsync($"api/post", new StringContent(serializedPost, Encoding.UTF8, "application/json"));

			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateItemAsync(Post post)
		{
			if (post == null || post.Id == null || !CrossConnectivity.Current.IsConnected)
				return false;

			var serializedPost = JsonConvert.SerializeObject(post);
			var buffer = Encoding.UTF8.GetBytes(serializedPost);
			var byteContent = new ByteArrayContent(buffer);

			var response = await client.PutAsync(new Uri($"api/post/{post.Id}"), byteContent);

			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
				return false;

			var response = await client.DeleteAsync($"api/Post/{id}");

			return response.IsSuccessStatusCode;
		}
    }
}