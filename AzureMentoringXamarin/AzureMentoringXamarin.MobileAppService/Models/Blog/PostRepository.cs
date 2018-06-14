using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace AzureMentoringXamarin.Models
{
	public class PostRepository : IPostRepository
    {
		private static ConcurrentDictionary<string, Post> posts = new ConcurrentDictionary<string, Post>();

		public PostRepository()
		{
            Add(new Post { Id = Guid.NewGuid().ToString(), About = "First Post", Content = "This is a post content.", Tags = "First, Post, 1" });
            Add(new Post { Id = Guid.NewGuid().ToString(), About = "Second Post", Content = "This is a post content.", Tags = "2º, Second, 2" });
            Add(new Post { Id = Guid.NewGuid().ToString(), About = "Third Post", Content = "This is a post content.", Tags = "Third, 3, 3º, Post" });
		}

		public Post Get(string id)
		{
			return posts[id];
		}

		public IEnumerable<Post> GetAll()
		{
			return posts.Values;
		}

		public void Add(Post post)
		{
			post.Id = Guid.NewGuid().ToString();
			posts[post.Id] = post;
		}

		public Post Find(string id)
		{
            Post post;
			posts.TryGetValue(id, out post);

			return post;
		}

		public Post Remove(string id)
		{
            Post post;
			posts.TryRemove(id, out post);

			return post;
		}

		public void Update(Post post)
		{
			posts[post.Id] = post;
		}
	}
}
