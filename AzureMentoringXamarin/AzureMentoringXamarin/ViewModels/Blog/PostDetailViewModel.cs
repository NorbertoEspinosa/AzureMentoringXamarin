using System;
using System.Collections.ObjectModel;
using AzureXamarinBlog.Models;
using AzureXamarinBlog.Views;
using Xamarin.Forms;

namespace AzureXamarinBlog.ViewModels
{
    public class PostDetailViewModel : BaseViewModel
    { 
        //public ObservableCollection<Post> BlogPosts { get; set; }

        public Post Post { get; set; }

        public PostDetailViewModel(Post post = null)
        {
            //BlogPosts = new ObservableCollection<Post>();

            Title = post?.About + "*"; //Norberto
            Post = post;

            MessagingCenter.Subscribe<PostDetailPage, Post>(this, "DeletePost", async (obj, item) =>
            {
                var _post = Post as Post;
                //BlogPosts.Remove(_post);
                await DataStore.DeleteItemAsync(_post.Id);
            });
        }
    }
}
