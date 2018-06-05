using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AzureMentoringXamarin.Models;

namespace AzureMentoringXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPostPage : ContentPage
    {
        public Item Item { get; set; }

        public NewPostPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Post name",
                Description = "This is a post content description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPost", Item);
            await Navigation.PopModalAsync();
        }
    }
}