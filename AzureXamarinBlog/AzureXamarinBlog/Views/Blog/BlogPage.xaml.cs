﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AzureXamarinBlog.Models;
using AzureXamarinBlog.ViewModels;

namespace AzureXamarinBlog.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BlogPage : ContentPage
	{
        BlogViewModel viewModel;

        public BlogPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new BlogViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Post;
            if (item == null)
                return;

            await Navigation.PushAsync(new PostDetailPage(new PostDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddPost_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPostPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.BlogPosts.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}