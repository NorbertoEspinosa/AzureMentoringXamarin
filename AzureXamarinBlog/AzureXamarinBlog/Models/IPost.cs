namespace AzureXamarinBlog.Models
{
    public interface IPost
    {
        string Id { get; set; }
        string About { get; set; }
        string Content { get; set; }
        string CreatedAt { get; set; }
        string Tags { get; set; }
        string Title { get; set; }
        int User { get; set; }
    }
}
