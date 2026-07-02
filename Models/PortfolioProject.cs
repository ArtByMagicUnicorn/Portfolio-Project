namespace Portfolio_Project.Models;

public class PortfolioProject
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Slug { get; set; } = "";
    public string Summary { get; set; } = "";
    public string DescriptionMarkdown { get; set; } = "";
    public string TechStack { get; set; } = "";
    public string? GitHubUrl { get; set; }
    public string? LiveUrl { get; set; }
    public bool IsFeatured { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}