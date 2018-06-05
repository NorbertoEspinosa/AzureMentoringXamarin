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

            var item = new Item
            {
                Text = "Item 1 hardcoded",
                Description = "This is post hardcoded description."
            };

            viewModel = new PostDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}