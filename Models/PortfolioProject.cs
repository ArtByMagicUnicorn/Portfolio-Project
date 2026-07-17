using System.ComponentModel.DataAnnotations;


namespace Portfolio_Project.Models;

public class PortfolioProject
{
    public int Id { get; set; }

    [Required]
    [StringLength(120)]
    public string Title { get; set; } = "";

    [Required]
    [StringLength(160)]
    [RegularExpression(
        "^[a-z0-9]+(?:-[a-z0-9]+)*$",
        ErrorMessage = "Use lowercase letters, numbers, and hyphens only. Example: portfolio-engine")]
    public string Slug { get; set; } = "";

    [Required]
    [StringLength(300)]
    public string Summary { get; set; } = "";

    [Display(Name = "Description")]
    public string DescriptionMarkdown { get; set; } = "";

    [Required]
    [StringLength(200)]
    [Display(Name = "Tech stack")]
    public string TechStack { get; set; } = "";

    [Url]
    [Display(Name = "GitHub URL")]
    public string? GitHubUrl { get; set; }

    [Url]
    [Display(Name = "Live URL")]
    public string? LiveUrl { get; set; }

    [Display(Name = "Screenshot URL")]
    public string? ScreenshotUrl { get; set; }

    [Display(Name = "Featured")]
    public bool IsFeatured { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}