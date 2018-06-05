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

        public PostDetailPage(PostDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public PostDetailPage()
        {
            InitializeComponent();

            var post = new Post
            {
                About = "Post About 1 hardcoded",
                Content = "This is a post content description hardcoded."
            };

            viewModel = new PostDetailViewModel(post);
            BindingContext = viewModel;
        }
    }
}