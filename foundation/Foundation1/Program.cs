using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear una lista de videos
        List<Video> videos = new List<Video>
        {
            new Video("Learning C# Basics", "John Smith", 600),
            new Video("Top 10 Programming Tips", "Jane Doe", 480),
            new Video("Understanding Abstraction", "Tech Guru", 720)
        };

        // Añadir comentarios a los videos
        videos[0].AddComment(new Comment("Alice", "Great explanation!"));
        videos[0].AddComment(new Comment("Bob", "Very helpful, thanks!"));

        videos[1].AddComment(new Comment("Charlie", "Good tips, learned a lot."));
        videos[1].AddComment(new Comment("Diana", "Amazing content!"));

        videos[2].AddComment(new Comment("Eve", "Clear and concise."));
        videos[2].AddComment(new Comment("Frank", "I love the examples used."));

        // Mostrar detalles de los videos
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Comment
{
    public string Name { get; private set; }
    public string Text { get; private set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}
