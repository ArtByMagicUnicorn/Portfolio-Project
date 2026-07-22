using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio_Project.Data;
using Portfolio_Project.Models;

namespace Portfolio_Project.Pages.Admin;

public class IndexModel : PageModel
{
    private readonly PortfolioDbContext _context;

    public IndexModel(PortfolioDbContext context)
    {
        _context = context;
    }

    public int TotalProjects { get; set; }
    public int FeaturedProjects { get; set; }
    public int ProjectsWithScreenshots { get; set; }
    public PortfolioProject? LatestProject { get; set; }
    public IList<PortfolioProject> ProjectsNeedingAttention { get; set; } = [];

    public async Task OnGetAsync()
    {
        TotalProjects = await _context.Projects.CountAsync();

        FeaturedProjects = await _context.Projects
            .CountAsync(project => project.IsFeatured);

        ProjectsWithScreenshots = await _context.Projects
            .CountAsync(project => !string.IsNullOrWhiteSpace(project.ScreenshotUrl));

        LatestProject = await _context.Projects
    .OrderByDescending(project => project.CreatedAt)
    .FirstOrDefaultAsync();

        ProjectsNeedingAttention = await _context.Projects
    .Where(project =>
        string.IsNullOrWhiteSpace(project.ScreenshotUrl) ||
        string.IsNullOrWhiteSpace(project.GitHubUrl) ||
        string.IsNullOrWhiteSpace(project.DescriptionMarkdown))
    .OrderByDescending(project => project.CreatedAt)
    .ToListAsync();
    }
}