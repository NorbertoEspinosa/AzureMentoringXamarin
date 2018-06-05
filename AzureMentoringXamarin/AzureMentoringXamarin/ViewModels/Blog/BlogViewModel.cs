using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using AzureMentoringXamarin.Models;
using AzureMentoringXamarin.Views;

namespace AzureMentoringXamarin.ViewModels
{
    public class BlogViewModel : BlogBaseViewModel
    {
        public ObservableCollection<Post> BlogPosts { get; set; }
        public Command LoadItemsCommand { get; set; }

        public BlogViewModel()
        {
            Title = "Browse posts";
            BlogPosts = new ObservableCollection<Post>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewPostPage, Post>(this, "AddPost", async (obj, item) =>
            {
                var _post = item as Post;
                BlogPosts.Add(_post);
                await DataStore.AddItemAsync(_post);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                BlogPosts.Clear();
                var posts = await DataStore.GetItemsAsync(true);
                foreach (var post in posts)
                {
                    BlogPosts.Add(post);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}