using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio_Project.Data;

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

    public async Task OnGetAsync()
    {
        TotalProjects = await _context.Projects.CountAsync();

        FeaturedProjects = await _context.Projects
            .CountAsync(project => project.IsFeatured);

        ProjectsWithScreenshots = await _context.Projects
            .CountAsync(project => !string.IsNullOrWhiteSpace(project.ScreenshotUrl));
    }
}