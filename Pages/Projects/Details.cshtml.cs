using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio_Project.Data;
using Portfolio_Project.Models;
using Markdig;

namespace Portfolio_Project.Pages.Projects;

public class DetailsModel : PageModel
{
    private readonly PortfolioDbContext _context;

    public DetailsModel(PortfolioDbContext context)
    {
        _context = context;
    }

    public PortfolioProject Project { get; set; } = new();
    public string DescriptionHtml { get; set; } = "";

    public async Task<IActionResult> OnGetAsync(string slug)
    {
        var project = await _context.Projects
            .FirstOrDefaultAsync(project => project.Slug == slug);

        if (project is null)
        {
            return NotFound();
        }

        Project = project;

        DescriptionHtml = Markdown.ToHtml(Project.DescriptionMarkdown ?? "");

        return Page();
    }
}