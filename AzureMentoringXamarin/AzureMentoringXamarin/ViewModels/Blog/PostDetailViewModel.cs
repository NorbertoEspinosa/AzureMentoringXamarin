using System;

using AzureMentoringXamarin.Models;

namespace AzureMentoringXamarin.ViewModels
{
    public class PostDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public PostDetailViewModel(Item item = null)
        {
            Title = item?.Text + "*"; //Norberto
            Item = item;
        }
    }
}
