using System;

using AzureMentoringXamarin.Models;

namespace AzureMentoringXamarin.ViewModels
{
    public class PostDetailViewModel : BaseViewModel
    {
        public Post Post { get; set; }
        public PostDetailViewModel(Post post = null)
        {
            Title = post?.About + "*"; //Norberto
            Post = post;
        }
    }
}
