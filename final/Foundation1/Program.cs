using System;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>
        {
            new Video("C# Tutorial", "CodeMaster", 3600),
            new Video("Cooking Tips", "Chef Emily", 1800),
            new Video("Product Review", "Tech Enthusiast", 900)
        };

        videos[0].Comments.Add(new Comment("Alice", "Great tutorial!"));
        // ... Add more comments to each video

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Author}: {comment.Text}");
            }
        }
    }
}