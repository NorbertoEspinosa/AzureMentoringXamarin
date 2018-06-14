using System;

using AzureXamarinBlog.Models;
using Xamarin.Forms;

namespace AzureXamarinBlog.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
