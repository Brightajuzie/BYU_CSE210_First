using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create 3-4 videos
        videos.Add(new Video() { Title = "Amadioha", Author = "Kachis", LengthInSeconds = 300 });
        videos.Add(new Video() { Title = "Uto Nku", Author = "Dozies", LengthInSeconds = 450 });
        videos.Add(new Video() { Title = "Ulo Oma", Author = "Lizzies", LengthInSeconds = 270 });

        // Add comments to each video
        videos[0].Comments.Add(new Comment() { CommenterName = "User1", Text = "This video is awesome!" });
        videos[0].Comments.Add(new Comment() { CommenterName = "User2", Text = "I loved it!" });
        videos[1].Comments.Add(new Comment() { CommenterName = "User3", Text = "Great Movie." });
        videos[1].Comments.Add(new Comment() { CommenterName = "User4", Text = "Very informative." });
        videos[2].Comments.Add(new Comment() { CommenterName = "User5", Text = "Awesome  and Captivating" });

        // Iterate through videos and display information
        foreach (var video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.LengthInSeconds + " seconds");
            Console.WriteLine("Number of Comments: " + video.GetCommentCount());
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine("  - " + comment.CommenterName + ": " + comment.Text);
            }
            Console.WriteLine();
        }
    }
}
