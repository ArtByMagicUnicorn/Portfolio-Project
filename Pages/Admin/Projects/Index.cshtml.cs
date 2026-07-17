using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio_Project.Data;
using Portfolio_Project.Models;

namespace Portfolio_Project.Pages.Admin.Projects;

public class IndexModel : PageModel
{
    private readonly PortfolioDbContext _context;

    public IndexModel(PortfolioDbContext context)
    {
        _context = context;
    }

    public IList<PortfolioProject> Projects { get; set; } = new List<PortfolioProject>();

    public async Task OnGetAsync()
    {
        Projects = await _context.Projects
            .OrderByDescending(project => project.CreatedAt)
            .ToListAsync();
    }
}