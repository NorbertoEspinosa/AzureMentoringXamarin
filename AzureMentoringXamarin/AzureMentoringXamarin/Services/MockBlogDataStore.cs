using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AzureXamarinBlog.Models;

namespace AzureXamarinBlog.Services
{
    public class MockBlogDataStore : IDataStore<Post>
    {
        List<Post> posts;

        public MockBlogDataStore()
        {
            posts = new List<Post>();
            var mockPosts = new List<Post>
            {
                new Post { Id = Guid.NewGuid().ToString(), About = "First Post", Content="This is a post content.", Tags="First, Post, 1" },
                new Post { Id = Guid.NewGuid().ToString(), About = "Second Post", Content="This is a post content.", Tags="2º, Second, 2" },
                new Post { Id = Guid.NewGuid().ToString(), About = "Third Post", Content="This is a post content.", Tags="Third, 3, 3º, Post" },
                //new Post { Id = Guid.NewGuid().ToString(), About = "Fourth Post", Content="This is a post content.", Tags="First, Post, 1" },
                //new Post { Id = Guid.NewGuid().ToString(), About = "Fifth Post", Content="This is a post content.", Tags="First, Post, 1" },
                //new Post { Id = Guid.NewGuid().ToString(), About = "Sixth Post", Content="This is a post content.", Tags="First, Post, 1" },
            };

            foreach (var post in mockPosts)
            {
                posts.Add(post);
            }
        }

        public async Task<bool> AddItemAsync(Post post)
        {
            posts.Add(post);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Post post)
        {
            var _item = posts.Where((Post arg) => arg.Id == post.Id).FirstOrDefault();
            posts.Remove(_item);
            posts.Add(post);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = posts.Where((Post arg) => arg.Id == id).FirstOrDefault();
            posts.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Post> GetItemAsync(string id)
        {
            return await Task.FromResult(posts.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Post>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(posts);
        }
    }
}