using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio_Project.Data;
using Portfolio_Project.Models;

namespace Portfolio_Project.Pages;

public class IndexModel : PageModel
{
    private readonly PortfolioDbContext _context;

    public IndexModel(PortfolioDbContext context)
    {
        _context = context;
    }

    public IList<PortfolioProject> FeaturedProjects { get; set; } = new List<PortfolioProject>();

    public async Task OnGetAsync()
    {
        FeaturedProjects = await _context.Projects
            .Where(project => project.IsFeatured)
            .OrderByDescending(project => project.CreatedAt)
            .Take(3)
            .ToListAsync();
    }
}