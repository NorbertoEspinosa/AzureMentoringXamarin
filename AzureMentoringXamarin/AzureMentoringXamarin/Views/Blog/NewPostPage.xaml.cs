using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AzureXamarinBlog.Models;

namespace AzureXamarinBlog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPostPage : ContentPage
    {
        public Post Post { get; set; }

        public NewPostPage()
        {
            InitializeComponent();

            Post = new Post
            {
                About = "Post about",
                Content = "This is a post content description.",
                Tags = "Post, About, New"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPost", Post);
            await Navigation.PopModalAsync();
        }
    }
}