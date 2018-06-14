using System.Collections.Generic;

namespace AzureXamarinBlog.Models
{
	public interface IPostRepository
    {
		void Add(Post item);
		void Update(Post item);
        Post Remove(string key);
        Post Get(string id);
		IEnumerable<Post> GetAll();
	}
}
