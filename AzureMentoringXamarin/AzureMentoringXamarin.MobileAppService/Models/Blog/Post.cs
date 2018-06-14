using System;
using System.Collections.Generic;
using System.Text;

namespace AzureMentoringXamarin.Models
{
    public class Post : IPost
    {
        public Post(string title, string about, string content, string tags, int user, string createdAt)
        {
            Title = title;
            About = about;
            Content = content;
            Tags = tags;
            User = user;
            CreatedAt = createdAt;
        }

        public Post()
        { }

        public string Id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public int User { get; set; }
        public string CreatedAt { get; set; }
    }
}
