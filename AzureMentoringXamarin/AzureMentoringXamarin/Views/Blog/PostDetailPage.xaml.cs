using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AzureMentoringXamarin.Models;
using AzureMentoringXamarin.ViewModels;

namespace AzureMentoringXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostDetailPage : ContentPage
	{
        PostDetailViewModel viewModel;
        public Post Post { get; set; }

        public PostDetailPage(PostDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public PostDetailPage()
        {
            InitializeComponent();

            Post = new Post
            {
                About = "Post About 1 hardcoded",
                Content = "This is a post content description hardcoded."
            };

            viewModel = new PostDetailViewModel(Post);
            BindingContext = viewModel;
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeletePost", Post);
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "SavePost", Post);
            await Navigation.PopModalAsync();
        }
    }
}